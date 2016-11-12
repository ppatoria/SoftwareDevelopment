#include <iostream>
#include "boost/scoped_ptr.hpp"
#include "boost/shared_ptr.hpp"
#include <string>

using namespace std;
using namespace boost;

enum productType{ productA=0, productB=1 };

class product{
public:
    string name () { return string("product");   }
    ~product ()    { cout << "~product" << endl; }
};

class productA : public product{
public:
    string name () { return string("product A");  }
    ~productA ()   { cout << "~productA" << endl; }
};

class productB : public product{
public:
    string name () { return string("product B");  }
    ~productB ()   { cout << "~productB" << endl; }
};

typedef scoped_ptr<product> product_ptr;

class factory
{
public:

    product* getProduct(productType type){
        if(type == productA)
            return new productA();        
        if(type == productB)
            return new productB();
        return new product();
    }    


};

class client
{
public:
    void func(){
        factory factoryA;       
        product& prod = factoryA.getProduct(productA);
        cout << "product name: " << prod.name() << endl;
        
    }
};


int main()
{    
    client clientA;
    clientA.func();   
}
