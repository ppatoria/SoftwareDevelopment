using System;

namespace MSPress.CSharpCoreRef.Animals
{
    public class Animal
    {
        public Animal()
        {
        }

        public Animal(string aName)
        {
            _name = aName;
        }

        public void Eat()
        {
        }

        public void Sleep()
        {
            _sleeping = true;
        }
        
        public void Wake()
        {
            _sleeping = false;
        }

        // Member fields
        protected bool   _sleeping;
        protected string _name= "Unknown";
	}
}
