#include <iostream>
using namespace std;
//: C08:ConstReturnValues.cpp
// Constant return by value
// Result cannot be used as an lvalue

class X {
    int i;
public:
    
    X(){ 
        cout << "X() invoked" << endl;
    }
    
    X(int ii) { 
        cout << "X(int ii) invoked" << endl;  
        i = ii; 
    }

    void modify() { 
        i++; 
    }

    void output(){
        cout << i << endl;
    }
};

X f5() {
    cout << "f5() invoked" << endl;
    X x = X();
    x.output();
    return x;
}

const X f6() {
    return X();
}

void f7(X& x) { // Pass by non-const reference
    x.modify();
}

int main() {
    cout << "main() invoked" << endl;
    //f5() = X(1); // OK -- non-const return value
    const X x = f5() = X(1);
    x.output();
    //f5().modify(); // OK
// Causes compile-time errors:
//! f7(f5());
//! f6() = X(1);
//! f6().modify();
//! f7(f6());
} ///:~
