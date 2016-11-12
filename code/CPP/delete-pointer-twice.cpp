#include <iostream>

class cls
{
public:
    ~cls(){ std::cout << "cls::~\n"; }
};

int delete_same_ptr_twice_1()
{
    cls* c1 = new cls();
    delete c1;
    delete c1;
}

int delete_same_ptr_twice_2()
{
    cls* c1 = new cls();
    cls* c2 = c1; 
    delete c1;
    delete c2;
}

int main()
{
    delete_same_ptr_twice_1();
    delete_same_ptr_twice_2();
    return 1;
}

