using System;
namespace MSPress.CSharpCoreRef.Animals
{
    public class Orangutan: LandAnimal
    {
        public Orangutan(): base()
        {
			_bugCount = 100;
        }

        public Orangutan(int StartingBugCount): base()
        {
            _bugCount = StartingBugCount;
        }

        public Orangutan(string aName): base(aName)
        {
            _name= aName;
			_bugCount = 100;
        }
        
        ~Orangutan()
        {
            StopGrooming();
        }

        public void Groom(Orangutan other)
        {
            other.CleanFur();
            other.LookForBugs();
            other.EatBugs();
        }

        public void CleanFur()
        {
        }

        public void LookForBugs()
        {
        }

        public void EatBugs()
        {
        }

        public void StopGrooming()
        {
            Console.WriteLine("Orangutan: " + _name + " has stopped grooming."); 
        }

        protected int _bugCount = 100;
        
    }
}