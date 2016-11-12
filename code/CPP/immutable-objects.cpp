#include <iostream>
#include <memory>
#include <utility>

void print (const std::string& data)
{
  std::cout << data << std::endl;
}

class Immutable
{
private:
  // Use a normal double, copying is cheap
  double d_;
  // Use a shared string, because strings can be very large
  std::shared_ptr<std::string const> s_;
public:
  // Default constructor
  Immutable()
    : d_(0.0),
      s_(std::make_shared<std::string const>(""))
  {
    print( "default constructor called" );
  }
  
  // Constructor taking a string
  Immutable(const double d, const std::string& s)
    : d_(d),
    s_(std::make_shared<std::string const>(s))
  {
    print( "constructor with param called" );
    
  }
  // Move constructor
  Immutable(Immutable&& other)
    : s_()
  {
    print( "move constructor called" );
    using std::swap;
    std::swap(d_, other.d_);
    std::swap(s_, other.s_);
  }
  // Move assignment operator
  Immutable& operator=(Immutable&& other)
  {
    print( "move assignment operator" );
    std::swap(d_, other.d_);
    std::swap(s_, other.s_);
    return *this;
  }
  // Use default copy constructor and assignment operator
  // Getter Functions
  double GetD() const
  {
    print( "getter function for D" );
    // Return a copy because double is small (8 bytes)
    return d_;
  }
  const std::string& GetS() const
  {
    print( "getter for S" );
    // Return a const reference because string can be very large
    return *s_;
  }
  // "Setter" Functions (always return a new object)
  Immutable SetD(double d) const
  {
    print( "setter for d" );
    auto this_object = *this;
    //Immutable newObject( std::move( *this ) );
    Immutable newObject( std::move( this_object ) );
    newObject.d_ = d;
    return newObject;
  }
  Immutable SetS(const std::string& s) const
  {
    print( "setter for s" );
    Immutable newObject( std::move( *this ) );
    newObject.s_ = std::make_shared<std::string const>(s);
    return newObject;
  }
};

int main()
{
  Immutable obj;
  auto obj1 = obj.SetD( 1.0 );
  std::cout << obj.GetD() << std::endl;
  return 1;
}
