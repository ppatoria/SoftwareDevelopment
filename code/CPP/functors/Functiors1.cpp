#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

/* Adder Functor */
class adder{
public:
    adder(int num ){
        this->num = num;
    }

    int operator()(int num){
        return this->num + num;
    }
private:
    int num;
};

void func1(adder& instance_of_adder, int num){
    cout
        << instance_of_adder (num)
        << endl;
}

int main(){
    adder instance_of_added(10);
    int num = 20;
    func1(instance_of_added, num);
    return 0;
}
