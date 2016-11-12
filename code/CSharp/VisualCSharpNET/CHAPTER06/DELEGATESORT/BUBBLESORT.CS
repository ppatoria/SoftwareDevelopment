using System;

namespace MSPress.CSharpCoreRef.DelegateSort
{
    public class BubbleSort
    {
        /// <summary>
        /// A delegate is used to define the sort order for two
        /// elements in the table.
        /// </summary>
        public delegate bool Order(object first, object second);

        /// <summary>
        /// Sort elements in an Array object, using the Order
        /// delegate to determine how items should be sorted.
        /// </summary>
        /// <param name="table">Array to be sorted</param>
        /// <param name="sortHandler">Delegate to manage
        /// sort order.</param>
        public void Sort(Array table, Order sortHandler)
        {
            if(sortHandler == null)
                throw new ArgumentNullException();
            
            bool nothingSwapped = false;
            int pass = 1;
            while(nothingSwapped == false)
            {
                nothingSwapped = true;
                for(int index = 0; index < table.Length - pass; ++index)
                {
                    // Use an Order delegate to determine the sort order.
                    if(sortHandler(table.GetValue(index),
                        table.GetValue(index + 1)) == false)
                    {
                        nothingSwapped = false;
                        object temp = table.GetValue(index);
                        table.SetValue(table.GetValue(index + 1), index);
                        table.SetValue(temp, index + 1);
                    }
                }
                ++pass;
            }
        }
    }
}
