#include <iostream>

auto add( auto a, auto b )
{
  return a+b;
}

int main()
{
  std::cout << add(2, 3) << std::endl;
  std::cout << add(2.3, 3.3) << std::endl;
  std::cout << add(2.3, 3) << std::endl;
  
  return 0;
}
