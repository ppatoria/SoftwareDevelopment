using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgrammingCSharp
{
    public class FPCSharp
    {
        {
            if(from <= to) {
                var sumRest = SumNumbers(from + 1, to);
            }
        }


        {
            for(int i = from; i <= to; i++) {
            }
        }

        //public static void Main()
        //{
        //    Console.WriteLine(SumNumbers(1, 5));
        //    Console.WriteLine(Sum(1, 5));
        //}
    }


    public class LambdaExpression
    {
        //public static void Main()
        //{
        //    Func<string, string> convert = s => s.ToUpper();

        //    string name = "Dakota";
        //    Console.WriteLine(convert(name));
        //}
    }
    static class Func
    {
        static void Main1(string[] args)
        {
            // Declare a Func variable and assign a lambda expression to the  
            // variable. The method takes a string and converts it to uppercase.
            Func<string, string> selector = str => str.ToUpper();

            // Create an array of strings.
            string[] words = { "orange", "apple", "Article", "elephant" };
            // Query the array and select strings according to the selector method.
            IEnumerable<String> aWords = words.Select(selector);

            foreach(String word in aWords)
                Console.WriteLine(word);
        }
        public static class FunctionalExtensions
        {
            public static void ForEach<T>(IEnumerable<T> items, Action<T> pPerfomAction)
            {
                foreach(T item in items)
                    pPerfomAction(item);
            }
        }

        public static class Enumerable
        {
            {
                for(int i = from; i < to; i++)
                    yield return i;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                FunctionalExtensions.ForEach(Enumerable.Range(0, 10), Display);
            }

            public void Display(Int32 i)
            {
                Console.WriteLine(i);
            }
        }
    }      
}
