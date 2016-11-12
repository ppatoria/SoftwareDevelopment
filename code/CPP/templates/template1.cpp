#include <iostream>

using namespace std;

class custom_type
{
    int i;
public:
    custom_type(int i)        
        {
            this->i = i;
        }

    int get_i() const 
        {
            return i;
        }    
};


template<typename T>
class Plus
{
public:
    T operator () (const T& t1, const T& t2) const 
        {            
            return t1 + t2;
        }

    T operator () (const T* t1, const T* t2) const 
        {            
            return *t1 + *t2;
        }

    custom_type operator () (const custom_type& t1, const custom_type& t2)
        {
            return custom_type(t1.get_i() + t2.get_i());            
        }
};


int main()
{            
    Plus<int> myplus;
    int x=10, y=20;
    cout << myplus (10, 20) << endl;
    cout << myplus (x, y)   << endl;
    cout << myplus (&x, &y) << endl;

    custom_type c1(20); 
    custom_type c2(20);
    cout << myplus (c1, c2).get_i() << endl;
    return 0;
}

