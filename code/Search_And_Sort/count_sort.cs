using System;
static class CountSort
{
    /*
     * Count Sort ( Array to sort InputArray )
     *-----------------------------------------
     * Step (1) Create a Array Count with Size of Max range + 1 . 
     * Step (2) Initialize it with 0
     * Step (3) Loop for each element in InputArray
     *          (a) Get the indes of Count for the element in loop.
     *          (b) Increment the index of Count
     * Step (4) Loop for each element in Count
     *          (a) if value of the element > 0
     *               While value of the element > 0
     *                  (i)  Insert in the InputArray
     *                  (ii) decrement the value of the element by 1
     */
    public static void SortSimple ( int[] ages)
	{
	    int maxAge = 99;
	    int[] timesOfAge = new int [maxAge + 1];
	    
	    for (int i=0; i<timesOfAge.Length; i++) timesOfAge[i] = 0;	    
	    
	    foreach (var age in ages) ++ timesOfAge[age];
	    
	    int index = 0;
	    for (int i=0; i<timesOfAge.Length; i++)
	    {	
		while (timesOfAge[i] != 0)		    
		{
		    ages [index++] = i;
		    timesOfAge[i]--;
		}		
	    }
	}
    
    public static void Sort(int[] ages) 
	{
	    int oldestAge = 99;
	    int[] timesOfAge = new int[oldestAge+1];
	    for(int i = 0; i <= oldestAge; ++ i)
		timesOfAge[i] = 0;
	    for(int i = 0; i < ages.Length; ++ i) 
	    {
		int age = ages[i];
		if(age < 0 || age > oldestAge)
		    throw new Exception("Out of range.");
		++ timesOfAge[age];
	    }
	    int index = 0;
	    for(int i = 0; i <= oldestAge; ++ i) 
	    {
		for(int j = 0; j < timesOfAge[i]; ++ j) 
		{
		    ages[index] = i;
		    ++ index;
		}
	    }

	    // Console.WriteLine ("TimesOfAge:");
	    // foreach (var age in timesOfAge) Console.WriteLine (age);
	}

    public static void Main()
	{
	    int[] ages = { 25,35,23,34,25,35,23};
	    foreach (var age in ages) Console.WriteLine (age);

	    Console.WriteLine ("--x--");
	    CountSort.Sort (ages);	    
	    foreach (var age in ages) Console.WriteLine (age);

	    Console.WriteLine ("--x--");
	    CountSort.SortSimple (ages);
	    foreach (var age in ages) Console.WriteLine (age);
	}
}