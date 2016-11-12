using System;

namespace MSPress.CSharpCoreRef.Animals
{
    public class Hamster: LandAnimal
    {
        public Hamster()
        {
        }

        public Hamster(string aName)
        {
            _name = aName;
        }

        public void PlanEscape()
        {
            Console.WriteLine("Hamster: " + _name + " is planning an escape."); 
        }

    }
}
