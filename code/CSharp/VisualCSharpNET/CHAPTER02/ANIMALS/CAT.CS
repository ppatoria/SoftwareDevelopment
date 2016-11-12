using System;
namespace MSPress.CSharpCoreRef.Animals
{
    public class Cat: LandAnimal
    {
        public Cat()
        {
        }

        public Cat(string aName)
        {
            _name = aName;
        }

        public void OverthrowHumans()
        {
            Console.WriteLine("Cat: " + _name + " is planning to overthrow the humans."); 
        }

        public void CoughUpFurballs()
        {
            Console.WriteLine("Cat: " + _name + " is coughing up furballs."); 
        }

        // Fields are normally protected or private. This field is public
        // in order to describe the syntax.
        public static int mouseEncounters;
    }
}