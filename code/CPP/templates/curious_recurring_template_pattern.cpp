#include <iostream>

using namespace std;
// Base class has a pure virtual function for cloning 
class Shape 
{ 
public:
    virtual ~Shape() {}
    virtual Shape *clone() const = 0; 
}; 

// This CRTP class implements clone() for Derived 
template <typename Derived> 
class Shape_CRTP : public Shape 
{ 
public:
    virtual Shape *clone() const {
	return new Derived(static_cast<Derived const&>(*this));
    } 

    virtual void Draw (){
	cout << "Share_CRTP::Draw" << endl;
    }
}; 

// Nice macro which ensures correct CRTP usage 
#define Derive_Shape_CRTP(Type) class Type: public Shape_CRTP<Type> 

class Square;

class Square : public Share_CRTP<Square>
{
public:
    void Draw (){
	cout << "Square::Draw" << endl;
    }
};

int main(){
    Shape_CRTP* s = new Square ();
    s->Draw ();
    return 1;
}
// Every derived class inherits from Shape_CRTP instead of Shape 
//Derive_Shape_CRTP(Square) {}; 
//Derive_Shape_CRTP(Circle) {};
