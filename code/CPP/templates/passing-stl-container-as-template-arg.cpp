#include <iostream>
#include <vector>

using namespace std;

template <typename T>
int fun( std::vector<T> t)
{
  
  T i = t[0];
  cout <<" Inside fun () "<<endl;
}

int main( int argc, char ** argv)
{
  std::vector<int> a;
  // This is the same as calling fun<std::vector<int> >();
  fun(a);
  return 0;
}
