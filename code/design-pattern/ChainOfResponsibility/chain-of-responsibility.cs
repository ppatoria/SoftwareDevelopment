using System;
using System.Collections.Generic;

class ChainPatternExample {

    // Chain of Responsibility Pattern Example         Judith Bishop  Sept 2007
    // Sets up the Handlers as level-based structure
    // Makes use of a user-defined exception if the end of the chain is reached

    class Handler {
        Levels level;
        int id;
        public Handler (int id, Levels level) {
            this.id = id;
            this.level = level;
        }
        public string HandleRequest(int data) {
            if (data < structure[level].Limit) {
                return "Request for " +data+" handled by "+level+ " "+id;
            }
            else if (level > First) {
                Levels nextLevel = --level;
                int which = choice.Next(structure[nextLevel].Positions);
                return handlersAtLevel[nextLevel][which].HandleRequest(data);
            }
            else {
                Exception chainException = new ChainException(  );
                chainException.Data.Add("Limit", data);
                throw chainException;
            }
        }
    }

    public class ChainException : Exception {
        public ChainException(  ) {}
    }

    void AdjustChain(  ) {}

    enum Levels {Manager, Supervisor, Clerk}
    static Random choice = new Random(11);
    static Levels First {
        get { return ((Levels[])Enum.GetValues(typeof(Levels)))[0]; }
    }

    static Dictionary  structure =
        new Dictionary  {
        {Levels.Manager, new Structure {Limit = 9000, Positions =1}},
        {Levels.Supervisor, new Structure {Limit = 4000, Positions =3}},
        {Levels.Clerk, new Structure {Limit = 1000, Positions =10}}};


    static Dictionary > handlersAtLevel =
        new Dictionary > {
        {Levels.Manager, new List (  )},
        {Levels.Supervisor, new List (  )},
        {Levels.Clerk, new List (  )}};

    class Structure {
        public int Limit {get; set;}
        public int Positions {get; set;}
    }

    void RunTheOrganization (  ) {

        Console.WriteLine("Trusty Bank opens with");
        foreach (Levels level in Enum.GetValues(typeof(Levels))) {
            for (int i=0; iamount in amounts) {
                try {
                    int which = choice.Next(structure[Levels.Clerk].Positions);
                    Console.Write("Approached Clerk "+which+". ");
                    Console.WriteLine(handlersAtLevel[Levels.Clerk][which].
                                      HandleRequest(amount));
                    AdjustChain(  );
                } catch (ChainException e) {
                    Console.WriteLine("\nNo facility to handle a request of "+
                                      e.Data["Limit"]+
                                      "\nTry breaking it down into smaller requests\n");
                }
            }
        }

        static void Main (  ) {
            new ChainPatternExample(  ).RunTheOrganization(  );
        }

    }
