#include "iostream"

using namespace std;

void swap(int* x1, int* x2){
    std::cout << "swap1 :" << std::endl;
}

void swap(int& x1, int& x2){
    cout << "swap2 :" << endl;
}

int main(){
    int x = 1;
    int y = 2;
    swap(&x, &y);
}


void switch_test(){    
    double d = 1.2;
    switch(d){
        case 1.0:
            cout << "case1" << endl;
        case 1.5:
            cout << "case2" << endl;
        case 2.0:
            cout << "case3" << endl;
    }
}

