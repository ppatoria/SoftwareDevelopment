#include<iostream>
using namespace std;

void funcP(int* a)
{
    a = new int(20);
}

void funcPP(int** a)
{
    *a = new int(15);
}

void funcRP(int*& a)
{
    a = new int(25);
}

int main(int argc, char* argv[])
{
    int* a = new int(10);
    funcP(a);
    cout<<*a<<endl;
    funcPP(&a);
    cout<<*a<<endl;
    funcRP(a);
    cout<<*a<<endl;
    return 0;
}
