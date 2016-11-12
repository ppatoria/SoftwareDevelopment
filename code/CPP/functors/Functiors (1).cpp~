#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

class less_than_equal_to{
public:
    less_than_equal_to(int length){
        this->length = length;
    }
    less_than_equal_to(string& str ){
        this->str = str;
    }
    /*bool operator()(const string& str){
        return str.length() <= length;
    }*/

    string& operator()(const string& str){
        return this->str + str;
    }

    void test(){
    }
private:
    int length;
    //string str;
};

/*void func(bool (*funcp) int num)
{
    funcp(num);
}*/

void func1(less_than_equal_to obj,
           const string& str)
{
    if(obj(str))
        cout << "func1 less than 5" << endl;
    else
        cout << "func1 grater than 5" << endl;
}

int main()
{
    const string& str = "test_string";
    func1(less_than_equal_to(5), str);
    /* Vectors */
    vector<string> strings;
    strings.push_back ("ABC");
    strings.push_back ("ABCDE");
    astrings.push_back ("ABCDEF");

        //func(less)
    /*************************** Functional ***********************************/
    cout << "Total strings less than five: "
         << count_if (strings.begin(), strings.end(), 
                      less_than_equal_to(5));
         << endl;
    /************************************************************************/

    /************************** Functional ***********************************/
    cout << "Total strings less than five: "
         << count_if (strings.begin(), strings.end(),
                      less_than_equal_to(7))
         << endl;
    /**************************************************************************/

    /*************************** imperitive ***********************************/
    int count  = 0;
    int length = 5;
    for ( vector<string>::iterator iter=strings.begin(); 
	  iter!=strings.end(); 
	  ++iter)
    {
        if (iter->length() <= length)
            count++;
    }
    cout << "Total strings less than five: "
         << count
         << endl;
    /**************************************************************************/

    return 0;
}
