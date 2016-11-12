using System;

namespace MSPress.CSharpCoreRef.Animals
{
    public class Goldfish: WaterAnimal
	{
        public Goldfish()
        {
        }

        public Goldfish(string aName)
        {
            _name = aName;
        }

        public void HideFromCat()
        {
            Console.WriteLine("Goldfish: " + _name + " is hiding from the cat."); 
        }
    }
}
