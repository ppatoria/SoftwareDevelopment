#include <iostream>
#include <vector>
#include <string>
#include "boost/lambda/lambda.hpp"

using namespace std;
using namespace boost;
using namespace lambda;

placeholder1_type element;
// boost::lambda::placeholder2_type Arg2;
// boost::lambda::placeholder3_type Arg3;

template <typename T,typename Operation>

void for_all(T& t,Operation Op) {
    std::for_each(t.begin(),t.end(),Op);
}

int main() {

    vector<string> vec;

    vec.push_back ("What are");
    vec.push_back ("the names");
    vec.push_back ("of the");
    vec.push_back ("placeholders?");

    for_all (vec, cout << _1 << " ");

    std::cout << "\nArg1, Arg2, and Arg3!";
}
