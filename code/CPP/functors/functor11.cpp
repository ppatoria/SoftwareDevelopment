// stl/foreach2.cpp

#include <vector>
#include <algorithm>
#include <iostream>
using namespace std;

// simple function object that prints the passed argument
class PrintInt {
  public:
    void operator() (int elem) const {
        cout << elem << ' ';
    }
};

int main()
{
    vector<int> coll;

    // insert elements from 1 to 9
    for (int i=1; i<=9; ++i) {
         coll.push_back(i);
    }

    // print all elements
    for_each (coll.begin(), coll.end(),    // range
              PrintInt());                   // operation
    cout << endl;
}
