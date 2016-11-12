#include <iostream>
#include <string>

using namespace std;

template <typename T>
class smart_ptr
{
private:
    T* t;
public:
    smart_ptr(T* tt)
        :t(tt)
    {
        cout << "constructor of smart_ptr is called" << endl;
    }
 
    ~smart_ptr()
    {
        cout << "destructor of smart_ptr is called" << endl;
        delete t;
    }
};

typedef smart_ptr<string> string_ptr;

int main()
{
    try{
        string_ptr str (new string("test"));
        cout << "throwing exception" << endl;
        throw 1;
    }catch(...){
        cout << "exception handled" << endl;        
    }
}
