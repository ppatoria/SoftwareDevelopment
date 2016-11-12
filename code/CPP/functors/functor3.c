#include<iostream>
#include<string>
using namespace std;

class StringArray
{
    private:
       int size;
       int index;
       String strArr[];
    public:
       stringArray(int i);
       void add(const string str);
       void printAll();
       ~stringArray();
       //int count_if(void* x);
};
stringArray::stringArray(int i): size(i), index(0)
{
    string strArr = new string[size];
    for(int i=0; i<size;i++)
    {
        strArr[i] = "";
    }
}
stringArray::add(const string str)
{
    strArr[index++]= str;
}
stringArray::printAll()
{
    for(int i=0; i<size;i++)
    {
        cout<<strArr[i]<<endl;
    }
}
stringArray::~stringArray()
{
    cout<<"destructor called<<endl;"
    delete[] strArr;
}

int main()
{
   StringArray strarr(2);
   strarr.add("abc");
   strarr.add("xyz);
   strarr.printAll();
}
