using System;

class Animal
{
    public int Legs = 4;
}

class Dog : Animal
{     
}

class Cat : Animal
{
}

delegate T Factory <T> ();

class Program
{
    static Dog MakeDog ()
	{
	    return new Dog ();
	}
    static Cat MakeCat ()
	{
	    return new Cat ();
	}
    static void Main ()
	{
	    // Factory <Animal> animalMaker1 = MakeDog;
	    // Factory <Animal> animalMaker2 = 
	    // 	() => { return new Dog(); };
	    // Factory <Dog> dogMaker = MakeDog;
	    Factory <Dog>    dogMaker    = MakeCat;
	    Factory <Animal> animalMaker = dogMaker;

	    Console.WriteLine (animalMaker().Legs.ToString());
	}
}