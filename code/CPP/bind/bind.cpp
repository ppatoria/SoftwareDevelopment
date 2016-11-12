#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

bool LengthIsLessThan(string myStr, int threshold) {
    return myStr.length() < threshold;
}

int main(){
    vector<string> container;
    container.push_back("abc");    
    cout 
        << count_if (container.begin(), container.end(),
                     bind2nd(ptr_fun(LengthIsLessThan), 5))
        << endl;
    return 0;
}
