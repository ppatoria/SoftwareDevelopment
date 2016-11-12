#include<iostream>
class empty {};
class with_ctor_and_dtor
{
public:
  with_ctor_and_dtor(){}
  ~with_ctor_and_dtor(){}
};

class with_virtual_dtor
{
public:
  virtual ~with_virtual_dtor(){}
};


int main()
{
  std::cout << "empty class: "
	    << sizeof( empty )
	    << "\n";
  
  std::cout << "class with only ctor and dtor: "
	    << sizeof( with_ctor_and_dtor )
	    << "\n";
  
  std::cout << "class with only virtual destructor: "
	    << sizeof( with_virtual_dtor )
	    << "\n";
  return 0;
}
