using System;
using System.Xml;

namespace MSPress.CSharpCoreRef.Average
{
    // Convert command line arguments to decimal values,
    // and calculate their average value.
    class AverageApp
    {
        static void Main(string[] args)
        {
            decimal total = 0;
            foreach(string arg in args)
            {
                total += Convert.ToDecimal(arg);
            }
            if(args.Length > 0)
            {
                decimal average = total / args.Length;
                Console.WriteLine("Average is {0}", average);
            }
        }
    }
}
