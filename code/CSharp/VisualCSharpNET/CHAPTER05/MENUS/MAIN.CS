using System;

namespace MSPress.CSharpCoreRef.Menus
{
	class MenuApp
	{
		static void Main(string[] args)
		{
            MenuApp theApp = new MenuApp();
            bool done = false;
            while(!done)
            {
                theApp.DisplayMenu();
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        theApp.DisplayHelp();
                        break;

                    case "2":
                        theApp.SayHello();
                        break;

                    case "3":
                        theApp.DisplayTime();
                        break;

                    case "4":
                        theApp.SayGoodbye();
                        done = true;
                        break;

                    default:
                        Console.WriteLine("Invalid selection");
                        theApp.DisplayHelp();
                        break;
                }
                while(true)
                {
                    try
                    {
                        Console.WriteLine("foo");
                    }
                    finally
                    {
                        throw new InvalidCastException("foo");
                        Console.WriteLine("bar");
                    }
                }
            }
		}

        private void DisplayMenu()
        {
            Console.WriteLine("\nSimple Menu");
            Console.WriteLine("1) Help");
            Console.WriteLine("2) Hello");
            Console.WriteLine("3) Date and Time");
            Console.WriteLine("4) Goodbye");
            Console.Write("Selection:");
        }

        private void DisplayHelp()
        {
            Console.WriteLine("Enter a number from 1-4, and press <return>");
        }

        private void SayHello()
        {
            Console.Write("Please enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
        }

        private void DisplayTime()
        {
            Console.WriteLine("The time is " + DateTime.Now + ".");
        }

        private void SayGoodbye()
        {
            Console.WriteLine("Goodbye!");
        }

	}
}
