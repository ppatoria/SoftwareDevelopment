using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.SafeStack
{
    public class SafeStack : Stack
    {
        public SafeStack() :base() {}
        public SafeStack(ICollection col) :base(col) {}
        public SafeStack(int initialCapacity) :base(initialCapacity) {}

        public override object Pop()
        {
            lock(SyncRoot)
            {
                return base.Pop();
            }
        }

        public override object Peek()
        {
            lock(SyncRoot)
            {
                return base.Peek();
            }
        }

        public override void Push(object obj)
        {
            lock(SyncRoot)
            {
                base.Push(obj);
            }
        }

        public override object[] ToArray()
        {
            lock(SyncRoot)
            {
                return base.ToArray();
            }
        }

        public override int Count
        {
            get
            {
                lock(SyncRoot)
                {
                    return base.Count;
                }
            }
        }

        public override void Clear()
        {
            lock(SyncRoot)
            {
                base.Clear();
            }
        }

        public override bool Contains(object obj)
        {
            lock(SyncRoot)
            {
                return base.Contains(obj);
            }
        }
    }
}
