using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.SkiLiftQueue
{
    public class SkiLift
    {
        public SkiLift()
        {
            _theLift = new Queue();
        }

        public void Run()
        {
            bool done = false;
            while(!done)
            {
                DisplayStatus();
                SkiAction choice = GetNextAction();
                switch(choice)
                {
                    case SkiAction.AddSkier:
                        string name;
                        do
                        {
                            Console.Write("Skier's name: ");
                            name = Console.ReadLine();
                        }while(name.Length == 0);
                        Skier newSkier = new Skier(name);
                        _theLift.Enqueue(newSkier);
                        break;

                    case SkiAction.RemoveSkier:
                        if(_theLift.Count == 0)
                        {
                            Console.WriteLine("The lift is empty.");
                        }
                        else
                        {
                            Skier nextSkier = (Skier)_theLift.Dequeue();
                            Console.WriteLine("{0} has left the ski lift.",
                                nextSkier.Name);
                        }
                    
                        break;

                    case SkiAction.Quit:
                        Console.WriteLine("Goodbye.");
                        done = true;
                        break;

                    default:
                        break;
                }
            }
        }

        protected void DisplayStatus()
        {
            Console.WriteLine("There are currently {0} skiers on the lift.",
                _theLift.Count);
            if(_theLift.Count > 0)
            {
                Skier nextSkier = (Skier)_theLift.Peek();
                Console.WriteLine("The next skier will be {0}.",
                    nextSkier.Name);

                Console.WriteLine("Skiers on the lift:");
                Array skiers = _theLift.ToArray();
                foreach(Skier aSkier in skiers)
                {
                    Console.WriteLine("\t" + aSkier.Name);
                }
            }
        }

        protected SkiAction GetNextAction()
        {
            SkiAction result = SkiAction.Quit;
            bool done = false;
            while(!done)
            {
                Console.WriteLine("A) Add a skier to the lift");
                Console.WriteLine("R) Remove a skier from the lift");
                Console.WriteLine("Q) Quit");
                Console.Write("Choice: ");

                switch(Console.ReadLine().ToUpper())
                {
                    case "A":
                        result = SkiAction.AddSkier;
                        done = true;
                        break;

                    case "R":
                        result = SkiAction.RemoveSkier;
                        done = true;
                        break;

                    case "Q":
                        result = SkiAction.Quit;
                        done = true;
                        break;

                    default:
                        break;
                }
            }
            return result;
        }
        protected enum SkiAction { AddSkier, RemoveSkier, Quit };
        protected Queue _theLift;
    }

}
