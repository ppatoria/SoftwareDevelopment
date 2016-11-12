using System;
class test
{
    const int i = 10;
    readonly int ii;

    public test(){
        ii = 20;
    }

    public void showReadOnly(){
        Console.WriteLine(ii);
    }

    public static void Main()
    {
        Console.WriteLine(i);
        test t = new test();
        t.showReadOnly();
    }    
}