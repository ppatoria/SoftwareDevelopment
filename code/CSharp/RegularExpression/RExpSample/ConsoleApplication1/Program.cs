using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    //class Program
    //{        

    //    static long DirectorySize (string directory)
    //    {
    //        long result = 0;
    //        Directory.GetFiles (directory, "*.*", SearchOption.TopDirectoryOnly)
    //        .Aggregate ((x,y) => {
    //            result +=  new FileInfo (x).Length + new FileInfo (y).Length;
    //            return x;
    //        });
    //        return result;
    //    }

    //    static void Main (string[] args)
    //    {
    //        long result = DirectorySize("c:\\users\\pralay\\documents");
    //        Console.WriteLine("result: {0}",result);
    //    }



    //}


    class Program
    {
        static void Main()
        {
            // Input string.
//            const string example = @"This string
//            has two lines";

            StreamReader sr = new StreamReader("c:\\users\\pralay\\documents\\multiline.txt");
            string example = sr.ReadToEnd();
            sr.Close();

            // Get a collection of matches with the Multiline option.
            MatchCollection matches = Regex.Matches(example, "^(.+)$", RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                // Loop through captures.
                foreach (Capture capture in match.Captures)
                {
                    // Display them.
                    Console.WriteLine("--" + capture.Value);
                }
            }
        }
    }
}
