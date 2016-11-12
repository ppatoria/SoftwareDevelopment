#include <utility>
#include <iostream>

using namespace std;

class Data
{
public:
  Data()
    : x (3)
  {
    cout << "Data()" << endl;
  }
  Data(Data&&)
    : x(4)
  {
    cout << "Data(&&)" << endl;
  }
  Data(const Data&)
    : x(2)
  {
    cout << "Data(copy)" << endl;
  }
  int x;
};

int main()
{
  Data a;
  Data b (std::move(a));
  cout << b.x << endl;
  return 0;
}
