using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.Enumerator
{
    // An associative array that demonstrates custom indexers, and
    // includes support for standard .NET enumeration.
    public class AssociativeArray: IEnumerable
    {
        // Event delegate 
        public delegate void ChangeEventHandler(object sender, EventArgs e);
        // Create an array and specify its initial size.
        public AssociativeArray(int initialSize)
        {
            _count = 0;
            _items = new object[initialSize];
            _eventArgs = new EventArgs();
        }
        // Declare the indexer used to access individual array items.
        public object this[string key]
        {
            get{ return KeyToObject(key); }
            set{ AddToArray(key, value); }
        }
        // Mimic the Length property found in other .NET arrays.
        public int Length
        {
            get { return _count; }
        }
        // Expose the enumerator for the associative array.
        public IEnumerator GetEnumerator()
        {
            return new AssociativeArrayEnumerator(this);
        }
        // Add an event handler for the changed event.
        public void AddOnChanged(ChangeEventHandler handler)
        {
            Changed += handler;
        }
        // Remove an event handler for the changed event.
        public void RemoveOnChanged(ChangeEventHandler handler)
        {
            Changed -= handler;
        }
        // Raise a changed event to subscribed enumerators.
        protected void OnChanged()
        {
            if(Changed != null)
                Changed(this, _eventArgs);
        }
        // Helper method used to add an item to the array. If the
        // key already exists, the existing item is replaced. If the
        // array is full, the array size is increased.
        protected void AddToArray(string key, object item)
        {
            if(KeyExists(key))
            {
                // Scroll through the item array, and replace the
                // existing item associated with the key with the
                // new item.
                for(int n = 0; n < _count; ++n)
                {
                    KeyItemPair pair = (KeyItemPair)_items[n];
                    if(key == pair.key)
                        _items[n] = new KeyItemPair(key, item);
                }
            }
            else
            {
                if(_count == _items.Length)
                {
                    IncreaseCapacity();
                }
                _items[_count] = new KeyItemPair(key, item);
                _count++;
            }
        }
        // Returns true if a specific key exists in the array;
        // otherwise, returns false.
        protected bool KeyExists(string key)
        {
            for(int n = 0; n < _count; ++n)
            {
                KeyItemPair pair = (KeyItemPair)_items[n];
                if(key == pair.key)
                    return true;
            }
            return false;
        }

        protected object KeyToObject(string key)
        {
            for(int n = 0; n < _count; ++n)
            {
                KeyItemPair pair = (KeyItemPair)_items[n];
                if(key == pair.key)
                    return pair.item;
            }
            return null;
        }
        // Given a key in the array, returns the associated object, or
        // returns null if the key isn't found.
        protected int KeyToIndex(string key)
        {
            for(int n = 0; n < _count; ++n)
            {
                KeyItemPair pair = (KeyItemPair)_items[n];
                if(key == pair.key)
                    return n;
            }
            return -1;
        }
        // Increases the size of the item array.
        protected void IncreaseCapacity()
        {
            int size = _items.Length + 5;
            object [] oldArray = _items;
            _items = new object[size];
            oldArray.CopyTo(_items, 0);
        }
        // Event handler for distributing change events to enumerators
        public event ChangeEventHandler Changed;
        // A member that holds change event arguments
        protected EventArgs _eventArgs;
        // The array that stores items in the associative array
        internal object[] _items;
        // The number of items in the array
        protected int _count;
        // A structure that contains the item and key pair stored in
        // each array element
        internal struct KeyItemPair
        {
            public KeyItemPair(string k, object obj)
            {
                key = k;
                item = obj;
            }
            public object item;
            public string key;
        }
    }
}
