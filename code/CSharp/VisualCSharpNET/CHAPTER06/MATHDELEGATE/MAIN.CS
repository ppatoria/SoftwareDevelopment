using System;

namespace MSPress.CSharpCoreRef.MathDelegate
{
    class MathDelegateApp
    {
        static void Main(string[] args)
        {
            MathOp mo = new MathOp(42, 27);
            mo.Op += new MathOp.OpDelegate(AddFunc.Add);
            mo.Op += new MathOp.OpDelegate(SubtractFunc.Subtract);
            mo.Op += new MathOp.OpDelegate(MultFunc.Multiply);
            mo.Invoke();
            Console.WriteLine("Done");
        }
    }
}
