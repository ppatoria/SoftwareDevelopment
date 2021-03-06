#include <iostream>
#include <memory>
#include <functional>

using namespace std;

void func (int x, int y)
{
    cout << x + y << endl;
}

auto l = [] (int x, int y) 
{
    cout << x + y << endl;
};

class C 
{
public:
    void operator () (int x, int y) const
	{
	    cout << x + y << endl;
	}
    void memfunc (int x, int y) const
	{
	    cout << x + y << endl;
	}
};

int main()
{
    C c;
    shared_ptr<C> sp(new C);

    // bind() uses callable objects to bind arguments:
    bind	(func,77,33) ();            // calls: func(77,33)
    bind	(l,77,33)    ();            // calls: l(77,33)
    bind	(C(),77,33)  ();            // calls: C::operator()(77,33)
    bind	(&C::memfunc,c,77,33)  ();  // calls: c.memfunc(77,33)
    bind	(&C::memfunc,sp,77,33) ();  // calls: sp->memfunc(77,33)

    // async() uses callable objects to start (background) tasks:
    async	(func,42,77);             // calls: func(42,77)
    async	(l,42,77);                // calls: l(42,77)
    async	(c,42,77);                // calls: c.operator()(42,77)
    async	(&C::memfunc,&c,42,77);   // calls: c.memfunc(42,77)
    async	(&C::memfunc,sp,42,77);   // calls: sp->memfunc(42,77)
}
