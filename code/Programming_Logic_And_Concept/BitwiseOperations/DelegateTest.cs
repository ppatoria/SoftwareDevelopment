using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestXOR
{
    class DelegateTest
    {
        Action<object> cout = Console.WriteLine;
        delegate void TestDelegate();
        public void func()
        {
            TestDelegate d1 = new TestDelegate(CallBackOne);
            d1 += new TestDelegate(CallBackTwo);
            cout(d1.Target);
            d1.BeginInvoke(null, null);
        }

        private void CallBackOne()
        {
            Console.WriteLine("CallBackOne");
            throw new Exception("CallBackOne");
        }

        private void CallBackTwo()
        {
            Console.WriteLine("CallBackTwo");
            throw new Exception("CallBackTwo");
        }

        public static void Test()
        {
            DelegateTest d = new DelegateTest();
            d.func();
        }
    }
}
