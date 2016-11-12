#include <iostream>
#include "../print.h"

template <typename T>
const T& max( const T& x, const T& y) const 
{
  return x < y ? y : x;
}

template <typename T1, typename T2>
const T1& max( const T1& x, const T2& y) const
{
  return x < y ? y : x;
}


int main()
{
  std::cout << max(2, 4) << std::endl;
  /* std::cout << max(2.2,1) << std::endl; */
  /* std::cout << max<double>(5.2, 4.3) << std::endl; */
}
