using System;

namespace MSPress.CSharpCoreRef.UnsafeSort
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            int [] ar = {3,7,2,1,6,8,5,4,9,12,6,3,14,7,2,2,13,10,11,1,1,1,11,2};
            Sorter s = new Sorter();
            s.Sort(ar);

            Console.WriteLine("Array contents:");
            foreach(int n in ar)
            {
                Console.WriteLine(n.ToString());
            }
            Console.WriteLine("Done");
        }
	}
}
