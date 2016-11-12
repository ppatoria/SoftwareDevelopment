/*
Shubhi's Interview in Cognizent
--------------------------------

C++
---
(1)  
myclass a;
myclass a (myclass &b);
myclass b ();
myclass b = a;

(2)  write a copy construction. 
     Member variable :
    	   (a) pointer 
	   (b) data on stack

(3)  Can Constructor be virtual ?
(4)  Can destructor can throw exception ?
(5)  What are the different ways to remove constness?
(6)  Why const reference is passed in copyconstructor?
(7)  Diferent types of casting?
     * What is static_cast
(8)  How to create thread?
(9)  How to make thread detachable?
(10) What happen to child threads when main returns?
(11) Synchronization primitive.
(12) If there is core dump in the production box how you will debug your program ?  
*/


#include <iostream>

using namespace std;

class myclass
{
public:
    myclass ()
	{
	    cout << "myclass constructor called" << endl;
	}

    myclass (const myclass& right)
	{
	    cout << "myclass copy constructor called" << endl;
	}
};

int main ()
{
    myclass a;
    myclass b (a);
    //myclass b ();
    //cout << "myclass b ();" << endl << myclass b () << endl;
    //myclass b = a;    
}
