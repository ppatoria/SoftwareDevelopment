#include <iostream>

using namespace std;

class Information : public ostream
{
private:
    int data ;
public:
    Information(int data){
        this->data = data;
    }
    //friend ostream& operator << (ostream& , Information& );
    Information& operator << (Information& info){
        cout << this->data << endl;
        return *this;
    }
};

// ostream& operator << (ostream& os, Information& info)
// {
//     os << info.data;
//     return os;
// }

int main()
{
    Information info(10);
    cout << info << info << endl;
    return 0;
}

// << (cout , info)
