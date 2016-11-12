using System;

namespace MSPress.CSharpCoreRef.MathDelegate
{
    public class SubtractFunc
    {
        static public void Subtract(int First, int Second)
        {
            int res = First - Second;
            Console.WriteLine("{0}-{1}={2}", First, Second, res);
        }
    }
}
