using System;

namespace MSPress.CSharpCoreRef.BattingAverageExample
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class BattingAverageApp
	{
        static void Main(string[] args)
        {
            BattingAverage ba = new BattingAverage(30, 10);
            Console.WriteLine(ba);

            BattingAverage ba1 = new BattingAverage();
            BattingAverage ba2 = new BattingAverage();

            if(ba1 && ba2)
                Console.WriteLine("Tested not OK");
            else
                Console.WriteLine("Tested OK");

            if(ba1 || ba2)
                Console.WriteLine("Tested not OK");
            else
                Console.WriteLine("Tested OK");

          
            ba1.AtBats = 5;
            ba1.Hits = 2;

            Console.WriteLine(5.ToString("C"));

            if(ba1 && ba2)
                Console.WriteLine("Tested not OK");
            else
                Console.WriteLine("Tested OK");

            if(ba1 || ba2)
                Console.WriteLine("Tested OK");
            else
                Console.WriteLine("Tested not OK");

            ba2.AtBats = 3;
            ba2.Hits = 2;

            if(ba1 && ba2)
                Console.WriteLine("Tested OK");
            else
                Console.WriteLine("Tested not OK");

            if(ba1 || ba2)
                Console.WriteLine("Tested OK");
            else
                Console.WriteLine("Tested not OK");

            ba1.Hits = 0;
            ba1.AtBats = 0;

            if(ba1 && ba2)
                Console.WriteLine("Tested not OK");
            else
                Console.WriteLine("Tested OK");

            if(ba1 || ba2)
                Console.WriteLine("Tested not OK");
            else
                Console.WriteLine("Tested OK");

            Console.WriteLine("Done");
        }
    }
}
