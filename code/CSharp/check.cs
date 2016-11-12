/*fload to double decimal
  if assignment operator
  cursor
  &
  10/20*5
  int ii; int[] i = new int[i;];*/
using System;

class test
{    
    static Action<object> print = Console.WriteLine;
    static Action<int> print = Console.WriteLine;

    public static void test1()	{
		float f=1;
		double d=2;
		//decimal dc=3;

		printd(f);
		printd(d);
		///print(dc);
    }

    public static void printd(double d){
		Console.WriteLine(d);
    }

    public static void Main(){	
		print("Main");
		test1();
		int i =0;
		// if(i=1) Console.WriteLine(i);
		i = 50/10*5;
		print(i);
		int[] ii = new int[i];
		print(ii.Length);
		print(string.Format("Print works ? {0}",true));
	}

}
