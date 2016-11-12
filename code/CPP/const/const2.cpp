#include <iostream>
#include "constHeader1.h"

using namespace std;

const int i = 10;// internal linkage

class cc
{
public:
    int func(){
        cout << i << endl;
        cout << ii << endl;
    }
};

// int global(){
//      cc c;
//      c.func();
//      return 0;
//  }
