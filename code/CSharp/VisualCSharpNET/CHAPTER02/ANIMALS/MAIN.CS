using System;

namespace MSPress.CSharpCoreRef.Animals
{
	/// <summary>
	/// Main application class for the Animals application.
	/// </summary>
	class AnimalsApp
	{
		static void Main(string[] args)
		{
			Cat anastasia = new Cat("Anastasia");
            Cat.mouseEncounters = 0;
            anastasia.CoughUpFurballs();
            anastasia.Sleep();

            Goldfish goldy = new Goldfish("Goldy");
            goldy.HideFromCat();

            Hamster fred = new Hamster("Fred");
            fred.PlanEscape();

            // Calls Orangutan
            Orangutan tan1 = new Orangutan();

            // Calls Orangutan(int)
            Orangutan tan2 = new Orangutan(100);

            // Calls Orangutan(string)
            Orangutan tan3 = new Orangutan("Stan");
		}
	}
}
