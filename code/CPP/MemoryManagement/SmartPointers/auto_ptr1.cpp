#include <iostream>
#include <memory>

using namespace std;

class A
{
    int i;
public:
    A(){
        i = 10;
    }
    A(int ii){
        i = ii;
    }

    int value(){
        return i;
    }
};

A* a_ptr; 

auto_ptr<A> source() 
{     
    auto_ptr<A> ptr( new A(9) );
    a_ptr = ptr.get();
    return ptr;
  // this will point to null after it returns
}

void checkNull()
{
    if(a_ptr)
        cout << "a_ptr is not null: " << a_ptr->value() << endl;
    else
        cout << "a_ptr is null" << endl;
}

 void sink( auto_ptr<A> pt ) 
 { }

void f()
{  
  auto_ptr<A> a( source() );

  checkNull();

  sink( source() );
  // a will become null when ownership is passed in sink method

  checkNull();

  sink( auto_ptr<A>( new A(7) ) );
  
  // vector< auto_ptr<T> > v;
  // v.push_back( auto_ptr<T>( new T(3) ) );
  // v.push_back( auto_ptr<T>( new T(4) ) );
  // v.push_back( auto_ptr<T>( new T(1) ) );
  // v.push_back( a );
  // v.push_back( auto_ptr<T>( new T(2) ) );
  // sort( v.begin(), v.end() );
  // cout << a->Value();
}

int main()
{
    f();
    return 0;
}

// class C
// {
// public:    /*...*/
// protected: /*...*/
// private:   /*...*/
//   auto_ptr<CImpl> pimpl_;
// };


