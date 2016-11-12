using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.Enumerator
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class EnumeratorApp
	{
        [STAThread]
        static void Main(string[] args)
        {
            AssociativeArray foodFavorites = new AssociativeArray(5);
            foodFavorites["Mickey"] = "Risotto with Wild Mushrooms";
            foodFavorites["Ali"] = "Plain Cheeseburger";
            foodFavorites["Mackenzie"] = "Macaroni and Cheese";
            foodFavorites["Rene"] = "Escargots";

            IEnumerator enumerator = foodFavorites.GetEnumerator();
            enumerator.MoveNext();

            foreach(string food in foodFavorites)
            {
                Console.WriteLine(food);
            }
            Iterate(foodFavorites);
            Console.WriteLine("done");
        }

        static void Iterate(object obj)
        {
            IEnumerable enumerable = obj as IEnumerable;
            if(enumerable != null)
            {
                IEnumerator enumerator = enumerable.GetEnumerator();
                while(enumerator.MoveNext())
                {
                    object theObject = enumerator.Current;
                    Console.WriteLine(theObject.ToString());
                }
            }
        }
    }
}
