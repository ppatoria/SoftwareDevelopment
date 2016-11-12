#include <iostream>
#include <stdlib.h>
#include <time.h>

using namespace std;

// Example 30-1
//

class Y
{    
public:
    Y(){
        cout << "Y()" << endl;
        m=10;
    }
    ~Y(){
        cout << "~Y()" << endl;
    }
    int m;
};

class X
{
public:
    X(){        
        cout << "X: " << ++uniqueId << endl;
        y_ = new Y();
    }

    // X(X& x){
    //     this->y_ = x.y_;        
    //     cout << "X(X& x): " << ++uniqueId << endl;        
    // }

    ~X(){        
        cout << "~X: " << uniqueId << endl;
        if(y_!=0){
            cout << "deleting y_ with m=" << y_->m << endl;
            delete y_;
            y_ = 0;
        }else{
            cout << "Y is already deleted" << endl;
        }
    }
    // ...
private:
    static int uniqueid(){
        srand (time(NULL));
        return rand();
    }

    static int uniqueId;
    Y* y_;
};

int X::uniqueId=0;

int main()
{
    // // Example 30-1(a): Ownership semantics.    
    // {
    //     X1 a; // allocates a new Y object and points at it
    //     // ...
    // } // as a goes out of scope and is destroyed, it
    // // deletes the pointed-at Y

    // Example 30-1(b): Sharing, and double delete.    
    {
        X a;   // allocates a new Y object and points at it        
        X b( a ); // b now points at the same Y object as a
        // ... manipulating a and b modifies
        // the same Y object ...

    } // as b goes out of scope and is destroyed, it
    // deletes the pointed-at Y... and so does a, oops
    return 1;
}
