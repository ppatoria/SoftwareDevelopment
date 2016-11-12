#include <iostream>

using namespace std;

class Coffee
{
    private:
    bool _containsMilk;

    public:
    Coffee()
    {
        _containsMilk = false;
    }

    void Out()
    {
        cout << "Cofee Object{ ContainsMilk: " << _containsMilk << " }" << endl;
    }

    bool GetContainsMilk()
    {
        return _containsMilk;
    }

    void SetContainsMilk(bool value)
    {
            _containsMilk = value;
    }
};

 void SwapByPtr(Coffee* paramOne, Coffee* paramTwo)
 {
    Coffee* temp = paramOne;
    paramOne     = paramTwo;
    paramTwo     = temp;
}

void SwapByRef(Coffee& paramOne, Coffee& paramTwo)
{
    Coffee temp  = paramOne;
    paramOne     = paramTwo;
    paramTwo     = temp;
}

void SwapByRefToPtr(Coffee*& paramOne, Coffee*& paramTwo)
{
    Coffee* temp = paramOne;
    paramOne     = paramTwo;
    paramTwo     = temp;
}

void SwapByVal(Coffee paramOne, Coffee paramTwo)
{
    Coffee temp = paramOne;
    paramOne    = paramTwo;
    paramTwo    = temp;
}


void SwapByValExample()
{
    cout<< endl << "SwapByValExample" << endl;
    cout << "Value Before Swap" <<endl;
    Coffee myCoffee;
    myCoffee.SetContainsMilk(true);
    myCoffee.Out();

    Coffee refCoffee;
    refCoffee.SetContainsMilk(false);
    refCoffee.Out();

    SwapByVal(myCoffee,refCoffee);

    cout << "Value After Swap" <<endl;
    myCoffee.Out();
    refCoffee.Out();
}

void SwapByRefExample()
{
    cout<< endl << "SwapByRefExample" << endl;

    cout << "Reference Before Swap" <<endl;
    Coffee myCoffee;
    myCoffee.SetContainsMilk(true);
    myCoffee.Out();

    Coffee refCoffee;
    refCoffee.SetContainsMilk(false);
    refCoffee.Out();

    SwapByRef(myCoffee,refCoffee);

    cout << "Reference After Swap" <<endl;
    myCoffee.Out();
    refCoffee.Out();
}

void SwapByPtrExample()
{
    cout<< endl << "SwapByPtrExample" << endl;

    cout << "Ptr Before Swap" <<endl;
    Coffee* myCoffee = new Coffee();
    myCoffee->SetContainsMilk(true);
    myCoffee->Out();

    Coffee* refCoffee = new Coffee();
    refCoffee->SetContainsMilk(false);
    refCoffee->Out();

    SwapByPtr(myCoffee,refCoffee);
    cout << "Ptr After Swap" <<endl;
    myCoffee->Out();
    refCoffee->Out();
}

void SwapByRefToPtrExample()
{
    cout<< endl << "SwapByRefToPtrExample" << endl;

    cout << "Reference Before Swap" <<endl;
    Coffee* myCoffee = new Coffee();
    myCoffee->SetContainsMilk(true);
    myCoffee->Out();
    Coffee* refCoffee = new Coffee();
    refCoffee->SetContainsMilk(false);
    refCoffee->Out();

    SwapByRefToPtr(myCoffee,refCoffee);

    cout << "Reference After Swap" <<endl;
    myCoffee->Out();
    refCoffee->Out();
}

int main()
{
    SwapByValExample();
    SwapByRefExample();

    SwapByPtrExample();
    SwapByRefToPtrExample();
    return 0;
}


