#include<iostream>
#include<string>
using namespace std;

class less_than_equal_to{
public:
    less_than_equal_to(int length){
        this->length = length;
    }


    bool operator()(const string& str){
        return str.length() <= length;
    }
private:
    int length;

};


class StringArray
{
    private:
       int size;
       int index;
       string* strArr;
    public:
       StringArray(int i);
       void add(const string str);
       void printAll();
       ~StringArray();
       int count_if(less_than_equal_to x){
        int count =0;
        for(int i=0; i<size;i++)
        {
            if(x(strArr[i]))
                count++;
        }
        return count;
       }
};


StringArray::StringArray(int i): size(i), index(0)
{
    strArr = new string[size];
    for(int i=0; i<size;i++)
    {
        strArr[i] = "";
    }
}
void StringArray::add(const string str)
{
    strArr[index++]= str;
}
void StringArray::printAll()
{
    for(int i=0; i<size;i++)
    {
        cout<<strArr[i]<<endl;
    }
}
StringArray::~StringArray()
{
    cout<<"destructor called "<<endl;
    delete[] strArr;
}

int main()
{
   StringArray strarr(2);
   strarr.add("abc");
   strarr.add("xyz");
   strarr.printAll();
   cout << strarr.count_if(less_than_equal_to(5)) << endl;
}
