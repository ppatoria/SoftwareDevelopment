using System;

namespace MSPress.CSharpCoreRef.Animals
{
	public class Dog: LandAnimal
	{
        public Dog()
        {
        }

        public Dog(string aName)
        {
            _name = aName;
        }

        public void ChaseCars(int quantityToChase)
        {
            Console.WriteLine("Dog: " + _name + " is chasing " + quantityToChase.ToString() + " cars."); 
        }

        public void Drool(int liters)
        {
            Console.WriteLine("Dog: " + _name + " is drooling " + liters.ToString() + " liters."); 
        }
    }
}
