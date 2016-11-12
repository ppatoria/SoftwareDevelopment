using System;

namespace MSPress.CSharpCoreRef.DelegateSort
{
    class DelegateSortApp
    {
        static int [] sortTable = {5,4,6,2,8,9,1,3,7,0};
        static void Main(string[] args)
        {
            DelegateSortApp app = new DelegateSortApp();

            // Print array in original order.
            foreach(int i in sortTable)
                Console.WriteLine(i);

            Console.WriteLine("Sorting");
            BubbleSort sorter = new BubbleSort();
            BubbleSort.Order order = new BubbleSort.Order(SortOrder);
            sorter.Sort(sortTable, order);

            foreach(int i in sortTable)
                Console.WriteLine(i);
            Console.WriteLine("Done");
        }

        // Delegate method; returns true if first is less than second
        static public bool SortOrder(object first, object second)
        {
            int firstInt = (int)first;
            int secondInt = (int)second;
            return firstInt < secondInt;
        }
    }
}
