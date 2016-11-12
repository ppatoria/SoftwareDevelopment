/* 
 * further reading : 	
 * http://stackoverflow.com/questions/1638919/how-to-explain-dependency-injection-to-a-5-year-old
 * http://codeutopia.net/blog/2008/06/21/dependency-injection-or-how-to-make-simple-concepts-sound-difficult/
 */

/* Sample
 ********
 * If you have a class Employee and this employee has an Address you can have the Employee class defined as follows:
 */

class Employee 
{
    private Address address;

    // constructor 
    public Employee( Address newAddress ) 
	{
	    this.address = newAddress;
	}

    public Address getAddress() 
	{
	    return this.address;
	}

    public void setAddress( Address newAddress ) 
	{
	    this.address = newAddress;
	}
}

/*
 * Everything looks fine so far.
 * This code shows a HAS-A relationship between the employee and his address, that's fine.
 * Now, this HAS-A relationship created a dependency between them. The problem comes within the constructor.
 * Each time you want to create an Employee instance you need an Address instance:
 *
 * Address someAddress = ....
 * Employee oscar = new Employee( someAddress ); 
 *
 * Working this way becomes problematic especially when you want to perform unit testing.
 * 
 * The main problem comes when you need to test one particular object,you need to create an instance of other object,and most likely you need to create an instance of yet other object to do that. 
 * The chain may become unmanageable.
 *
 * To avoid this, you could change the constructor like this:
 */

  public Employee()
  {
  }

/*
 * Using a no args constructor.
 *
 * Then you can set the address when ever you want:
 *
 * Address someAddress = ....
 * Employee oscar = new Employee();
 * oscar.setAddress( someAddress ); 
 *
 * Now, this may be a drag, if you have several attributes or if the objects are hard to create.
 *
 * Yet, think about this, let's say, you add the Department attribute:
 */

  class Employee 
  {
      private Address address;
      private Department department;

  ....

/*
 * If you have 300 employees, and all of them need to have the same department, 
 * and plus that same department has to be shared between some other objects 
 * ( like the company list of departments, or the roles each department have etc ) 
 * then you'll have a hard time with the visibility of the Department object and to share it through all the network of objects.

 * What the Dependency Injection is all about it to help you to, well, "inject" these dependencies in your code. 
 * Most of the frameworks allow you to do this by specifying in an external file, what object is to be injected.

 * Assume a properties file for a fictitious dependency injector:

 * #mock employee
 * employee.address    = MockAddress.class
 * employee.department = MockDepartment.class

 * #production setup 
 * employee.address    = RealAddress.class
 * employee.department = RealDepartment.class

 * You'll define what to inject for a given scenario.

 * What the Dependency Injector framework will do is to set the correct objects for you, 
 * so you don't have to code setAddress or setDepartment. 
 * This would be done 
 * (*) either by reflection 
 * (*) or by code generation 
 * (*) or other techniques.

 * So, the next time you need to test the Employee class you may inject mock Address and Departments objects without having to code all the set/get for all your test. 
 * Even better, you can inject real Address and Department objects in production code, and still have the confidence your code works as tested.

 * That's pretty much about it.

 * Still I don't think this explanation is suitable for a 5 yr old as you requested.

 * I hope you still find it useful.
 */
