#include "boost/shared_ptr.hpp"
#include <cassert>
#include <iostream>

using namespace std;
using namespace boost;

typedef shared_ptr<int> shared_ptr_int;

class A 
{
    shared_ptr_int no_;

public:
    A(shared_ptr_int no) : no_(no) 
    { }
    
    void value(int i) {
        *no_=i;
    }
};

class B 
{
     shared_ptr_int no_;

public:
    B(shared_ptr_int no) : no_(no) 
    { }
    
    int value() const {
        return *no_;
    }
};

int main () {

    shared_ptr_int int_ptr (new int(14));

    cout << "reference count: " << int_ptr.use_count() << endl;
    cout << "sole owner: "      << int_ptr.unique()    << endl;

    A* a = new A (int_ptr);

    cout << "reference count: " << int_ptr.use_count() << endl;
    cout << "sole owner: "      << int_ptr.unique()    << endl;

    B* b = new B (int_ptr);

    cout << "reference count: " << int_ptr.use_count() << endl;

    a->value (28);
    assert (b->value()==28);
    cout << b->value() << endl; 

     delete a;

     cout << "reference count: " << int_ptr.use_count() << endl;
     cout << "sole owner: "      << int_ptr.unique()    << endl;
     
     delete b;

     cout << "reference count: " << int_ptr.use_count() << endl;
     cout << "sole owner: "      <<int_ptr.unique()     << endl;
}
