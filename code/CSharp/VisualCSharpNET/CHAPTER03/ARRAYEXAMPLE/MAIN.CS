using System;
using System.Text;

namespace MSPress.CSharpCoreRef.ArrayExample
{
    class ArrayExampleApp
    {
        static void Main(string[] args)
        {
            string [] months = { "January", "February", "March",
                                 "April", "May", "June", "July",
                                 "August", "September", "October",
                                 "November", "December"};
            Console.WriteLine("Start value:");
            PrintArray(months);

            Console.WriteLine("The array has a rank of {0}.",
                              months.Rank);

            int elements = months.Length;
            Console.WriteLine("There are {0} elements in the array.",
                              elements);

            Console.WriteLine("Reversing...");
            Array.Reverse(months);
            PrintArray(months);

            Console.WriteLine("Sorting...");
            Array.Sort(months);
            PrintArray(months);

            Console.WriteLine("Cloning...");
            string [] secondArray = (string[])months.Clone();
            Console.WriteLine("Cloned Array...");
            PrintArray(months);
            
            Console.WriteLine("Clearing...");
            Array.Clear(months, 0, months.Length);
            PrintArray(months);

            string [,] locations = FillLocations();
            DisplayLocations(locations);

            Console.WriteLine("Shape Information");
            double[][] shapes = FillShapes();
            DisplayShapeInfo(shapes);

			Console.WriteLine("Done");
        }

        /// <summary>
        /// Print each element in the names array.
        /// </summary>
        static void PrintArray(string[] names)
        {
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }

        static string [,] FillLocations()
        {
            string [,] locations = {{"San Diego", "CA"},
                                    {"Phoenix", "AZ"},
                                    {"New York", "NY"},
                                    {"Seattle", "WA"}};
            return locations;
        }
        static void DisplayLocations(string[,] names)
        {
            int locations = names.GetLength(0);
            for(int n = 0; n < locations; n++)
            {
                Console.WriteLine(names[n, 0] + ", " + names[n, 1]);
            }
        }

        static double[][] FillShapes()
        {
            double[][] shapes = new double[4][];
            shapes[0] = new double[1] {10};            // Circle
            shapes[1] = new double[4] {3, 4, 3, 4};    // Quadrilateral
            shapes[2] = new double[3] {3, 4, 5};       // Triangle
            shapes[3] = new double[5] {5, 5, 5, 5, 5}; // Pentagon
            return shapes;
        }

		static void DisplayShapeInfo(double[][] shapes)
		{
			int rankNumber = 0;
			foreach(double[] shape in shapes)
			{
				int totalLength = 0;
				foreach(int side in shape)
				{
					totalLength += side;
				}
				Console.WriteLine("Shape {0} perimeter length is {1}",
									rankNumber,
									totalLength);
				++rankNumber;
			}
		}
	}
}
