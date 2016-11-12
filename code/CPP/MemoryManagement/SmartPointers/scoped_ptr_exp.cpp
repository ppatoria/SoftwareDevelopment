#include<boost/scoped_ptr.hpp>

using namespace std;
using namespace boost;

class B
{
public:
    B ()  { cout << "B constructor call\n" << endl; }
    ~B () { cout << "B destructor call\n"  << endl; }
};

typedef scoped_ptr<B> clsB;

class A
{

public:    
    scoped_ptr<B> b;
    
    A():b(new B())  
    {
        cout << "A constructor call\n" << endl;
        throw "exception in A constructor";
    }
};

int main()
{
    
    //A a; 
    try{
        clsB b(new B());
        cout << "Throwing exception" << endl;
        throw 1;
    }catch(...){
        cout << "Exception handled" << endl;
    }
    
    return 0;
}
