using System;

internal class Employee {
   
}
internal class Manager : Employee {
   
}


public sealed class Program {
    public static void Main() {
	// Construct a Manager object and pass it to PromoteEmployee.
	// A Manager IS-A Employee: PromoteEmployee runs OK.
	Manager m = new Manager();
	PromoteEmployee(m);

	// Construct a DateTime object and pass it to PromoteEmployee.
	// A DateTime is NOT derived from Employee. PromoteEmployee
	// throws a System.InvalidCastException exception.
	DateTime newYears = new DateTime(2013, 1, 1);
	PromoteEmployee(newYears);
    }


    public static void PromoteEmployee(Object o) {
	// At this point, the compiler doesn't know exactly what
	// type of object o refers to. So the compiler allows the
	// code to compile. However, at run time, the CLR does know
	// what type o refers to (each time the cast is performed) and
	// it checks whether the object's type is Employee or any type
	// that is derived from Employee.

	Console.WriteLine("Casting object to employee");
	try
	{
	    Employee e = (Employee) o;
	}
	catch(Exception ex)
	{
	    Console.WriteLine ("Exception while casing object to employee"); 
	    Console.WriteLine (ex.ToString());
	}
    }
}