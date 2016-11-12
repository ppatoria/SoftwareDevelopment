#define LOCK_TRACING

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace LockLeveling {

    public sealed class LeveledLock
    {
        // Shared fields
        private static LocalDataStoreSlot lockLevelTlsSlot;

        // Fields
        private object _lock = new object();
        private int _level;
        private string _name;
        private bool _reentrant;

        // Class constructor
        static LeveledLock()
        {
#if LOCK_TRACING
            lockLevelTlsSlot = Thread.AllocateNamedDataSlot("__current#lockLevel__");
#endif
        }

        // Constructor
        public LeveledLock(int level) : this(level, true) {}
        public LeveledLock(int level, bool reentrant) : this(level, reentrant, null) {}

        public LeveledLock(int level, bool reentrant, string name)
        {
            this._level = level;
            this._reentrant = reentrant;
            this._name = name;
        }

        // Properties
        public int Level
        {
            get { return _level; }
        }

        public bool Reentrant
        {
            get { return _reentrant; }
        }

        public string Name
        {
            get { return _name; }
        }

        // Methods
        public IDisposable Enter()
        {
            return Enter(false, 0);
        }

        public IDisposable Enter(bool permitIntraLevel)
        {
            return Enter(permitIntraLevel, 0);
        }

        public IDisposable Enter(int millisecondsTimeout)
        {
            return Enter(false, millisecondsTimeout);
        }

        public IDisposable Enter(bool permitIntraLevel, int millisecondsTimeout)
        {
            Thread.BeginThreadAffinity();
            Thread.BeginCriticalRegion();
            bool taken = false;
            try
            {
                PushLevel(permitIntraLevel);
                taken = Monitor.TryEnter(_lock, millisecondsTimeout);
                if (!taken)
                    throw new TimeoutException("Timeout occurred while attempting to acquire monitor");
            }
            finally
            {
                if (!taken)
                {
                    Thread.EndCriticalRegion();
                    Thread.EndThreadAffinity();
                }
            }

            return new LeveledLockCookie(this);
        }

        public void Exit()
        {
            Monitor.Exit(_lock);
            try
            {
                PopLevel();
            }
            finally
            {
                Thread.EndCriticalRegion();
                Thread.EndThreadAffinity();
            }
        }

        [Conditional("LOCK_TRACING")]
        private void PushLevel(bool permitIntraLevel)
        {
            Stack<LeveledLock> currentLevelStack = Thread.GetData(lockLevelTlsSlot) as Stack<LeveledLock>;

            if (currentLevelStack == null)
            {
                // We've never accessed the TLS data yet; construct a new Stack for our levels
                // and stash it away in TLS.
                currentLevelStack = new Stack<LeveledLock>();
                Thread.SetData(lockLevelTlsSlot, currentLevelStack);
            }
            else if (currentLevelStack.Count > 0)
            {
                // If the stack in TLS already recorded a lock, validate that we are not violating
                // the locking protocol. A violation occurs when our lock is higher level than the
                // current lock, or equal to the level (when the reentrant bit has not been set on
                // at least one of the locks involved).
                LeveledLock currentLock = currentLevelStack.Peek();
                int currentLevel = currentLock._level;

                if (_level > currentLevel ||
                    (currentLock == this && !_reentrant) ||
                    (_level == currentLevel && !permitIntraLevel))
                {
                    throw new LockLevelException(currentLock, this);
                }
            }

            // If we reached here, we are OK to proceed with locking. Stash the current level in TLS.
            currentLevelStack.Push(this);
        }

        [Conditional("LOCK_TRACING")]
        private void PopLevel()
        {
            Stack<LeveledLock> currentLevelStack = Thread.GetData(lockLevelTlsSlot) as Stack<LeveledLock>;

            // Just pop the latest level placed into TLS.
            if (currentLevelStack != null)
            {
                if (currentLevelStack.Peek() != this)
                    throw new InvalidOperationException("You released a lock out of order. This is illegal with leveled locks.");
                currentLevelStack.Pop();
            }
        }

        public override string ToString()
        {
            return string.Format("<level={0}, reentrant={1}, name={2}>", _level, _reentrant, _name);
        }

        class LeveledLockCookie : IDisposable
        {
            // Fields
            private LeveledLock _lck;

            // Constructor
            internal LeveledLockCookie(LeveledLock lck)
            {
                this._lck = lck;
            }

            // Methods
            void IDisposable.Dispose()
            {
                _lck.Exit();
            }
        }

    }

    public class LockLevelException : Exception
    {
        public LockLevelException() : base() {}
        public LockLevelException(string m) : base(m) {}
        public LockLevelException(string m, Exception innerException) : base(m, innerException) {}
        public LockLevelException(LeveledLock currentLock, LeveledLock newLock) :
            base(string.Format("You attempted to violate the locking protocol by acquiring lock {0} " +
            "while the thread already owns lock {1}.", currentLock, newLock)) {}
    }

}