using System;

public static class Lambda
{
    public static Action<object> cout = Console.WriteLine;
    //static Action<string> cout = Console.WriteLine;

    // public delegate 
    // void ParamAction<T>       (params T[] obj);

    // static ParamAction<object> cout = Console.WriteLine;

    public delegate 
    T1 Function<T1,T2> (params T2[] args);


    public static 
    Function<T1,T2>  Curry<T1,T2> (Function<T1,T2> func, 
                                   params T2[] curriedArgs) 
    {
        return  delegate(T2[] funcArgs){
            //Create a final array of parameters, 
            //having the curried parameters at the beginning, followed
            //by the arguments at the time the generated delegate is called
            T2[] actualArgs = new T2[funcArgs.Length + curriedArgs.Length];
            curriedArgs.CopyTo(actualArgs, 0);
            funcArgs.CopyTo(actualArgs, curriedArgs.Length );
            //Call the function with our final array of parameters.
            return  func( actualArgs );
        };
    }

    public delegate 
    T func<T>          (params T[] args);
    
    public delegate 
    T func1<T>          (T args);
    
    public static 
    func<T>  Curry<T> (func<T>    function, 
                       params T[] curriedArgs) 
    {
        cout (string.Format("curried ags: {0}" , curriedArgs.Length));
        return  delegate       (T[] funcArgs){            
            T[] actualArgs     = new T[funcArgs.Length + curriedArgs.Length];
            curriedArgs.CopyTo (actualArgs, 0);
            funcArgs.CopyTo    (actualArgs, curriedArgs.Length );            
            return  function   (actualArgs);
        };
    }

    public static 
    Func<int,Func<int,int>> Adder =
        delegate       (int t1)
        {            
            return  delegate(int t2)
            {
                return t1 + t2;
            };
        };
    

    
}

public class Program
{
    public static int Add (params int[] numbers){
        int result =0;
        foreach (int i in numbers)
            result += i;    
        return result;
    }

    public static void Main(){        
        Lambda.cout(Lambda.Adder(5)(6));        
        Lambda.func<int> adder=Lambda.Curry<int>(Add,7);        
        Lambda.cout(adder(5,6)); // returns 18
        Lambda.cout(Lambda.Curry<int>(Add,7)());

        // Lambda.Function<int,int> adder=Lambda.Curry<int,int>(Add,7);
        // Console.WriteLine(adder(5, 6)); // returns 18

        // Lambda.Function<int,int> adder2 = Lambda.Curry<int,int>(adder, 2);
        // adder2(5, 6); //returns 20 ( 5+ 6 + 7 + 2)
    }   

    // public static int Add1 (params int[] numbers){
    //     string str = "test";
    //     return numbers.ToList().Sum ();        
    // }
    
}