using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.Enumerator
{
    // An enumerator for the AssociativeArray class
    public class AssociativeArrayEnumerator : IEnumerator
    {
        public AssociativeArrayEnumerator(AssociativeArray ar)
        {
            _ar = ar;
            _currIndex = -1;
            _invalidated = false;
            // Subscribe to collection change events.
            AssociativeArray.ChangeEventHandler h;
            h = new AssociativeArray.ChangeEventHandler(InvalidatedHandler);
            ar.AddOnChanged(h);
        }
        // Property that retrieves the element in the associative array that this
        // enumerator instance is pointing to. If the enumerator has
        // been invalidated or isn't pointing to a valid item, throw
        // an InvalidOperationException exception.
        public object Current
        {
            get
            {
                AssociativeArray.KeyItemPair pair;
                if(_invalidated || 
                    _currIndex == -1 ||
                    _currIndex == _ar.Length)
                    throw new InvalidOperationException();
                pair = (AssociativeArray.KeyItemPair)_ar._items[_currIndex];
                return pair.item;
            }
        }
        // Move to the next item in the collection, returning true if the
        // enumerator refers to a valid item and returning false otherwise.
        public bool MoveNext()
        {
            if(_invalidated || _currIndex == _ar._items.Length)
                throw new InvalidOperationException();
            _currIndex++;
            if(_currIndex == _ar.Length)
                return false;
            else
                return true;
        }
        // Reset the enumerator to its initial position.
        public void Reset()
        {
            if(_invalidated)
                throw new InvalidOperationException();
            _currIndex = -1;
        }
        // Event handler for changes to the underlying collection. When
        // a change occurs, this enumerator is invalidated and must be
        // recreated.
        private void InvalidatedHandler(object sender, EventArgs e)
        {
            _invalidated = true;
        }
        // Flag that marks the collection as invalid after a change to
        // the associative array
        protected bool _invalidated;
        // The index of the item this enumerator applies to.
        protected int _currIndex;
        // A reference to this enumerator's associative array.
        protected AssociativeArray _ar;
    }
}
