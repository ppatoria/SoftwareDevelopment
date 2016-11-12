using System;

namespace MSPress.CSharpCoreRef.Animals
{
    public class Whale: WaterAnimal
    {
        public Whale()
        {
        }

        public Whale(string aName)
        {
            _name = aName;
        }

        public void ChaseSailboats()
        {
            Console.WriteLine("Whale: " + _name + " is chasing sailboats."); 
        }
    }
}
