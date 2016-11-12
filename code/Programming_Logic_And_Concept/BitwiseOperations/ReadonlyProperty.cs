using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestXOR
{
    class ReadonlyProperty
    {
        private readonly string name;
        public string Name
        {
            get { return name; }
        }
        public ReadonlyProperty(string name)
        {
            this.name = name;
        }

        public ReadonlyProperty(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
        private string address;
        public string Address
        {
            get { return address; }
        }

        public static void Test()
        {
            ReadonlyProperty r = new ReadonlyProperty("pralay");
            ReadonlyProperty rr = new ReadonlyProperty(name: "patoria");
            ReadonlyProperty rrr = new ReadonlyProperty(name: "pralay", address: "patoria");

            Console.WriteLine(r.Name);
            Console.WriteLine(rr.Name);
            Console.WriteLine(rrr.Name);
            Console.WriteLine(rrr.Address);
        }
    }
}
