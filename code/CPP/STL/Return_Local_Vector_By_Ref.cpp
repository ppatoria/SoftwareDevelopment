#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

std::vector<int> return_vector(void) {     
    std::vector<int> tmp {1,2,3,4,5};     
    return tmp; 
}


void SetBuffer( vector<int>::const_iterator begin, vector<int>::const_iterator end){
    while(begin != end){
	cout << *begin << endl;
	begin++;
    }
}

int main(){ 
    std::vector<int> rval_ref = return_vector();
    SetBuffer (rval_ref.begin(), rval_ref.end());
    // for_each(rval_ref.begin(), rval_ref.end(), [](int i){ 
    // 	    cout << i << endl;
    // 	});
    return 0;
}
