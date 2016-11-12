using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TestXOR
{
    public struct structure
    {
        public int x { get; set; }

    }
    public class MyClass
    {
        public string FirstName;
        public string LastName;
        public override int GetHashCode()
        {
            return (FirstName.GetHashCode() ^ LastName.GetHashCode()) % 2;
        }
    }

    class ABC
    {
        public const int constant = 10;
        public ABC()
        {
            
            a = new Random().Next();
        }
        int a;
        public void Func(ABC obj)
        {
            a = obj.a;
        }

        public override string ToString()
        {
            return a.ToString();
        }
    }

    partial class Program
    {
        //Action<string> cout = Console.WriteLine;
        
        delegate bool check(int i, string s);
        class HKey
        {
            public int Key { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ABC.constant);           
            ABC obj1 = new ABC();
            ABC obj2 = new ABC();
            
            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
            obj1.Func(obj2);
            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
            Hashtable ht = new Hashtable();
            HKey k = null;
            try
            {
                ht.Add(k, "test");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            string str1 = "mystr";
            string str2 = "mystr";

            Console.WriteLine(object.ReferenceEquals(str1, str2));
            Console.WriteLine(object.Equals(str1, str2));
            try
            {
                DelegateTest.Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            List<Person> persons = new List<Person>()
            {
                new Person("Abhay","Deshmukh"),
                new Person("Pralay","Patoria"),
                new Person("Shubhi","Patoria")
            };

            //var res = from person in persons orderby person.FirstName descending;
            var res1 = from person in persons
                       where person.FirstName == "Pralay"
                       select new { Name = person.FirstName, Surname = "Patoria" };
            foreach(var p in res1)
            {
                Console.WriteLine(string.Format("{0} {1}",p.Name,p.Surname));
            }

            //List<Person> matches = 
            //persons
            //    .FindAll(person => person.LastName == "Patoria")
            //    .ForEach(Console.WriteLine);

            persons
                .Select(person => person.LastName.Equals("Patoria")).ToList()
                .ForEach(Console.WriteLine);

            ReadonlyProperty.Test();
            TestStringWithDictionary();
            MyGCCollectClass.Test();
            structure st1 = new structure { x = 10 };
            structure st2 = new structure { x = 10 };
            bool result = structure.ReferenceEquals(st1, st1);
            MyClass o = new MyClass { FirstName = "pralay", LastName = "patoria" };
            MyClass t = new MyClass { FirstName = "pralay", LastName = "patoria" };
            int ohc = o.GetHashCode();
            int thc = t.GetHashCode();
            result = ohc == thc;
            string strOne = "pralay";
            string strTwo = "patoria";
            int strOneHC = strOne.GetHashCode();
            int strTwoHC = strTwo.GetHashCode();
            int xor = strOneHC ^ (strTwoHC);
            bool res = strOne.GetHashCode() == strTwo.GetHashCode();
            object obj = new MyClass();
            Console.WriteLine(obj.ToString());
            //TestXOR.Person.Test();
            check checkLength = (int x, string s) => s.Length > x;
            bool r = checkLength(5, "pralay");
            Test(null);
            float ii = 1f;
            double jj = 1;
            result = ii == jj;


            int i = 13;
            int j = 11;
            int z = i ^ j;
            i = 2;
            j = 4;
            z = i ^ j;
            z = z >> 1;
            Console.WriteLine(z);
        }

        public static void TestStringWithDictionary()
        {
            try
            {
                Dictionary<Person, Person> dict = new Dictionary<Person, Person>();
                Person p1 = new Person("pralay", "patoria");
                dict.Add(p1, p1);
                Person p2 = new Person("pralay", "patoria");
                dict.Add(p2, p2);
                Person p3 = dict[p2];

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
    }





    partial class Program
    {
        public static ArrayList GetVarList()
        {
            ArrayList arrayList = new ArrayList();
            var item1 = "Math.PI=";
            var item2 = Math.PI;
            var item3 = ';';
            arrayList.Add(item1);
            arrayList.Add(item2);
            arrayList.Add(item3);
            return arrayList;
        }

        public static ArrayList GetVarListTwo()
        {
            ArrayList arrayList = new ArrayList();
            int i = 10;
            arrayList.Add(i);
            arrayList.Add("Math.PI=");
            arrayList.Add(Math.PI);
            arrayList.Add(';');
            arrayList.Add(new MyClass());
            return arrayList;
        }

        static void Test(string[] args)
        {
            var resultList = GetVarListTwo();
            foreach (var item in resultList)
                Console.Write(item);
        }
    }
}
