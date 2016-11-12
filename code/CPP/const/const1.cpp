#include <iostream>
#include "constHeader.h"
#define inc(x) (x)
using namespace std;


const int i = 10;// internal linkage

class c
{
private:
    static int staticFunc(){
        cout << i << endl;        
    }    
int x;
public:
    c(){x=99;}
    int func(){
        std::cout << i  << std::endl;        
        std::cout << ii << std::endl;        
    }
    int increment(int x){
        return x++ + x++;
    }

};

int main(){
    cout << inc(10) << endl;
    //c::staticFunc();
    c cc;
    cout << cc.increment(10) << endl;
    //cc.func();
    return 0;
}

