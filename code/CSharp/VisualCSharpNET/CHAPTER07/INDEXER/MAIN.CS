using System;

namespace MSPress.CSharpCoreRef.Indexer
{
    class AssociativeArrayApp
    {
        [STAThread]
        static void Main(string[] args)
        {
            AssociativeArray foodFavorites = new AssociativeArray(1);
            foodFavorites["Ali"] = "Plain Cheeseburger";
            foodFavorites["Mackenzie"] = "Macaroni and Cheese";
            foodFavorites["Mickey"] = "Risotto with Wild Mushrooms";
            foodFavorites["Rene"] = "Escargots";

            Console.WriteLine(foodFavorites["Ali"]);
            Console.WriteLine(foodFavorites["Mackenzie"]);
            Console.WriteLine(foodFavorites["Mickey"]);
            Console.WriteLine(foodFavorites["Rene"]);
        }
    }
}
