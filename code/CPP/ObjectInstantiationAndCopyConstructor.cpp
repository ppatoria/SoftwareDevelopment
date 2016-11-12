#include <iostream>

using namespace std;

class myclass
{
public:
    myclass(){
	cout << "constructor called" << endl;
    }
};

int main()
{
    myclass b();
    return 0;
}
