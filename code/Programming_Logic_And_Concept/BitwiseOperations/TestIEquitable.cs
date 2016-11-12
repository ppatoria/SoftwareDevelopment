using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestXOR
{
    public class BaseClass
    {
    }
    public class PersonOne: BaseClass
    {
        public string SSN { get; set; }
        public string LastName { get; set; }

    }
    public class Person : BaseClass//, IEquatable<Person>
    {
        //private string uniqueSsn;
        private string lName;
        public string FirstName { get; set; }

        public override string ToString()
        {
            return string.Format("FirstName: {0}{1}LastName: {2}", FirstName, Environment.NewLine, LastName);
        }

        //public Person(string lastName, string ssn)
        //{
        //    this.SSN = ssn;
        //    this.LastName = lastName;
            
        //}

        public Person(string firstName, string lastName)
        {
            this.LastName = lastName;
            FirstName = firstName;
        }
        //public string SSN
        //{
        //    get { return this.uniqueSsn; }
        //    set
        //    {
        //        if (Regex.IsMatch(value, @"\d{9}"))
        //            uniqueSsn = String.Format("{0}-(1}-{2}", value.Substring(0, 3),
        //                                                     value.Substring(3, 2),
        //                                                     value.Substring(5, 3));
        //        else if (Regex.IsMatch(value, @"\d{3}-\d{2}-\d{3}"))
        //            uniqueSsn = value;
        //        else
        //            throw new FormatException("The social security number has an invalid format.");
        //    }
        //}

        public string LastName
        {
            get { return this.lName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new NullReferenceException("The last name cannot be null or empty.");
                else
                    lName = value;
            }
        }

        //public bool Equals(Person other)
        //{
        //    if (this.uniqueSsn == other.SSN)
        //        return true;
        //    else
        //        return false;
        //}

        public bool Equals(Person other)
        {

            if (FirstName == other.FirstName)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            Console.WriteLine(Environment.StackTrace);
            if (obj == null) return base.Equals(obj);

            if (!(obj is Person))
                throw new
                    InvalidCastException("The 'obj' argument is not a Person object.");
            else
                return Equals(obj as Person);
        }

        //public override int GetHashCode()
        //{
        //    return this.SSN.GetHashCode();
        //}

        public override int GetHashCode()
        {
            // return FirstName.GetHashCode();
            //Random rand = new Random();
            //return rand.Next();
            return 1;
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return (!person1.Equals(person2));
        }

        //public static void Test()
        //{
        //    // Create a Person object for each job applicant.
        //    Person applicant1 = new Person("Jones", "099-29-4999");
        //    Person applicant2 = new Person("Jones", "199-29-3999");
        //    Person applicant3 = new Person("Jones", "299-49-6999");

        //    // Add applicants to a List object.
        //    List<Person> applicants = new List<Person>();
        //    applicants.Add(applicant1);
        //    applicants.Add(applicant2);
        //    applicants.Add(applicant3);

        //    // Create a Person object for the final candidate.
        //    Person candidate = new Person("Jones", "199-29-3999");

        //    if (applicants.Contains(candidate))
        //        Console.WriteLine("Found {0} (SSN {1}).",
        //                           candidate.LastName, candidate.SSN);
        //    else
        //        Console.WriteLine("Applicant {0} not found.", candidate.SSN);

        //    // Call the shared inherited Equals(Object, Object) method.
        //    // It will in turn call the IEquatable(Of T).Equals implementation.
        //    Console.WriteLine("{0}({1}) already on file: {2}.",
        //                      applicant2.LastName,
        //                      applicant2.SSN,
        //                      Person.Equals(applicant2, candidate));
        //    Person.Equals(applicant2, candidate);
        //    applicant2.Equals(candidate);
        //    PersonOne p = new PersonOne{ LastName = "test", SSN = "ssn"};
        //    applicant1.Equals(p);
        //}
    }
}
