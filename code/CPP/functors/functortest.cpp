#include<iostream>
using namespace std;

class functortest
{
    public:
        functortest(){ cout << "ctor"<<endl;}
        int operator()(int a, int b)
        {
            return (a+b);
        }
};

int main()
{
    functortest f;
    cout<<f(1,2);
    return 0;
}
