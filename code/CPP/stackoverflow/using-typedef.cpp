#include <iostream>

using my_type = double;
struct cls
{
  using type = double;          //case 1
  // typedef double type;       //case 2
};

template<typename T>
void foo(typename T::type) {
    std::cout<<"T::type\n";
}

void func( cls::type type )
{
  std::cout << "func called" << std::endl;
}

void func1( my_type t)
{
  std::cout << "func1 called" << std::endl;
}

int main()
{
  foo<cls>(22.2);
  func( 34.6 );
  func1( 33.5 );
}
