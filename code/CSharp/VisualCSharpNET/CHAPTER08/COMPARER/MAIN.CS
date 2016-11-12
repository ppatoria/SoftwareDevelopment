using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.ch08Comparer
{
    class ComparerApp
    {
        static void Main(string[] args)
        {
            ZipCode lagunaHills = new ZipCode("92653", "8204");
            ZipCode redmond = new ZipCode("98052");
            ZipCode phoenix = new ZipCode("85044");

            int comparison = lagunaHills.CompareTo(redmond);

            Console.WriteLine(lagunaHills);
            Console.WriteLine(redmond);
            Console.WriteLine(phoenix);

            ZipCode [] codes = { lagunaHills, redmond, phoenix };
            Array.Sort(codes);
            foreach(ZipCode code in codes)
            {
                Console.WriteLine(code);
            }

            Array.Sort(codes, new AscendingComparer());
            foreach(ZipCode code in codes)
            {
                Console.WriteLine(code);
            }
            Array.Sort(codes, new DescendingComparer());
            foreach(ZipCode code in codes)
            {
               Console.WriteLine(code);
            }

            string [] places = { "Kista", "Älvsjö", "Stockholm" };
            Array.Sort(places);
            //Array.Sort(places, new SwedishNameComparer());
            foreach(string place in places)
            {
                Console.WriteLine(place);
            }


            Console.WriteLine("Done");
        }
    }
}
