using System;

namespace MSPress.CSharpCoreRef.MathDelegate
{
    public class MathOp
    {
        public delegate void OpDelegate(int First, int Second);
        public OpDelegate Op;
        
        public MathOp(int First, int Second)
        {
            _first = First;
            _second = Second;
        }

        public void Invoke()
        {
            // Explicit management of delegate invocation.
            object[] args = new object[2];
            args[0] = _first;
            args[1] = _second;

			Delegate [] operators = Op.GetInvocationList();
            foreach(Delegate d in operators)
            {
                try
                {
                    d.DynamicInvoke(args);
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
            /*
            // Default delegate invocation
            if(Op != null)
                Op(_first, _second);
            */
        }
		protected int _first;
		protected int _second;
    }
}
