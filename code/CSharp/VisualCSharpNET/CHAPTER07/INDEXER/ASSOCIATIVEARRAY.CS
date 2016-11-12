using System;

namespace MSPress.CSharpCoreRef.Indexer
{
    // An associative array that demonstrates custom indexers.
    public class AssociativeArray
    {
        // Create an array and specify its initial size.
        public AssociativeArray(int initialSize)
        {
            _items = new object[initialSize];
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
        // otherwise, return false.
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
        // Given a key in the array, returns the associated object, or
        // returns null if the key isn't found.
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
        // Increases the size of the item array.
        protected void IncreaseCapacity()
        {
            int size = _items.Length + 5;
            object [] oldArray = _items;
            _items = new object[size];
            oldArray.CopyTo(_items, 0);
        }
        // The array that stores items in the associative array
        protected object[] _items;
        // The number of items in the array
        protected int _count = 0;
        // A structure that contains the item and key pair stored in
        // each array element
        protected struct KeyItemPair
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
