using System;

namespace MSPress.CSharpCoreRef.MathDelegate
{
    public class AddFunc
    {
        static public void Add(int First, int Second)
        {
            int res = First + Second;
            Console.WriteLine("{0}+{1}={2}", First, Second, res);
        }
    }
}
