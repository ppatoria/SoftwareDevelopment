using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace test1
{
    class Program
    {
        private static string member1 = null;
        static Program()
        {
            member1 = "initial";
        }

        public static string Member
        {
            get { return member1;       }
            set { member1 = value;  }
        }

        static void Main(string[] args)
        {
            Debug.WriteLine(Program.Member);
            Program.Member = "changed";
            Debug.WriteLine(Program.Member);
        }
    }
}
