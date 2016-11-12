#include "boost/shared_ptr.hpp"
#include <vector>
#include <iostream>
#include "boost/lambda/lambda.hpp"

using namespace boost;
using namespace std;
using namespace lambda;

class A {
public:
    virtual void sing()=0;
protected:
    virtual ~A() { cout << "~A" << endl; };
};

class B : public A {
public:
    virtual void sing() {
        std::cout << "Do re mi fa so la";
    }
    virtual ~B () { cout << "~B" << endl; }
};

boost::shared_ptr<A> createA() {
    boost::shared_ptr<A> p(new B());
    return p;
}

typedef shared_ptr<A> A_ptr;
typedef vector<A_ptr> array;

void print(A_ptr a_ptr)
{
    a_ptr->sing();
}

int main() 
{
    array arr;    

    for (int i=0;i<10;++i)  arr.push_back(createA());    

    std::cout << "The choir is gathered: \n";    

    for_each (arr.begin(), arr.end(), A_ptr a_ptr = _1; a_ptr->sing(););
}

