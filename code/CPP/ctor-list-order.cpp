#include <iostream>
class Y
{
public:
  Y();
  void f();
};

Y::Y()
{
  std::cout << "Initializing Y\n";
}

void Y::f()
{
  std::cout << "Using Y\n";
}

class X
{
public:
  X(Y& y);
};

X::X(Y& y)
{
  y.f();
}

class Z
{
public:
  Z();

protected:
  X x_;
  Y y_;
};

Z::Z() //\wthrow()
  : x_(y_)
  , y_()
    //↑↑   // Bad: should have listed x_ before y_
{ }

int main()
{
  Z z;
  return 0;
}
