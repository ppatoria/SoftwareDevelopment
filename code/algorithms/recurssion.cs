using System;

class Recurssion
{
    static int AddRecursively (int n)
	{
	    if (n > 0 )
		return n + AddRecursively (n-1);
	    return n;
	}

    public static void Main ()
	{
	    Console.WriteLine (AddRecursively (500000));	    
	}
}

// return 2 + AddReCursively (1)                  2 + 1 = 3   
//        return 1 + AddRecursively (0)           1 + 0 = 1
//               return 0                           0

