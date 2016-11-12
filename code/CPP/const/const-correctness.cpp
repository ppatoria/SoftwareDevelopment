#include <iostream>
#include <string>

class Person
{
public:
  const std::string& name_good() const // Right: the caller can't change the Person's name
  {
    return name_;
  }

  std::string& name_evil()        // Wrong: the caller can change the Person's name
  {
    return name_;
  }

  int age() const                  // Also right: the caller can't change the Person's age
  {
    return age_;
  }
  
  std::string to_string()
  {
    std::string data;

    data
      .append( "Name: ").append( name_).append( "\n" )
      .append( "Age: ").append( std::to_string( age_ )).append( "\n" );

    return std::move( data );
  }
private:
  std::string name_;
  int age_;
};

void myCode(Person& p)  // myCode() promises not to change the Person object...
{
  p.name_evil() = "Igor";     // But myCode() changed it anyway!!
}

int main()
{
  Person p;
  p.name_evil() = "evil_1";
  std::cout << p.to_string() << std::endl;
  myCode( p );
  std::cout << p.to_string() << std::endl;
  return 0;
}
