#include <iostream>
// #include <strstream>
#include <string>

using namespace std;

template <typename T>
void print (T val){
    cout << val << endl;
}

template <typename T>
T increment(T val){
    return ++val;
}


// template <typename T>
// string& to_string(T val){
//     ostrstream str_out;
//     str_out << val;    
//     return val.str();
// }

template <typename T1, typename T2>
T1 IsGreaterThan (T2 val){
    return val > 10;
}

int main(){
    
    print(10);
    print("pravek");

    
    cout << increment(9)    << endl;
    cout << increment(99.9) << endl;

    // cout << to_string(999)  << endl;

    bool result = IsGreaterThan<bool,int>(11);
    cout << result << endl;    

    // auto test = 8.9;
    // cout << test << endl;

    return 0;
}




