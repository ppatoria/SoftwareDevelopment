#include <iostream>
#include <vector>
#include <atomic>

template<typename Type>
void println( Type arg )
{
  std::cout << arg << std::endl;
}

class RR
{
  int counter;
public:
  RR():counter( 0 )
  {}
  
  int GetIndex( const std::vector<int>& endpoints)
  {
    counter %= endpoints.size();
    return counter++;
  }
};

int main()
{
  RR rr;
  std::vector<int> v {1,2,3};
  println( rr.GetIndex( v ) );
  println( rr.GetIndex( v ) );
  println( rr.GetIndex( v ) );
  println( rr.GetIndex( v ) );
  println( rr.GetIndex( v ) );
  println( rr.GetIndex( v ) );
  println( rr.GetIndex( v ) );
  println( rr.GetIndex( v ) );
}
                                                                                             
