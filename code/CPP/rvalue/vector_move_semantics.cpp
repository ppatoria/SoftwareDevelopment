#include <iostream>
#include <vector>
#include <utility>
#include <algorithm>

using namespace std;

// void print (vector<int> v){
//     cout << "............." << endl; 
//     for_each (v.begin(), v.end(), [](int i){
// 	    cout << i << endl;
// 	});
// }

void print (vector<int>& v){
    cout << "............." << endl; 
    for( int i=0; i<v.size(); i++){
	cout << v[i] << endl;
    }
}

vector<int> createVector (){
    vector<int> v1;
    v1.push_back(1);
    v1.push_back(2);
    return move(v1);
    //return v1;
}

// vector<int> test (vector<int> v){
//     vector<int> v1;
//     for_each (v.begin(), v.end(), [&](int i){
// 	    v1.push_back(i + 1);
// 	});
//     //print (v);
//     return v1;
// }

vector<int> test (vector<int> v){
    cout << "test" << endl;
    cout << ".. v" << endl;
    print (v);

    vector<int> v1;
    for (int i=0; i < v.size(); i++){
	int val = v[i] + 1;
        v1.push_back(val);
    }

    cout << ".. v1" << endl;
    print (v1);
    cout << "................." << endl;
    return  move(v1);
    //return v1;
}


int main (){
    try{
	{
	    vector<int> v;
	    {
		v = createVector();
	    }
	    print (v);
	    vector<int> v1;
	    {
		v1 = test (move(v));
	    }
	    //vector<int> v1 = test (v);
	    print (v);
	    print (v1);
	}
    }catch(exception& ex){
	cout << ex.what() << endl;
    }
    return 0;
}
