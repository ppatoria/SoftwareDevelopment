// stl/multiset1.cpp
#include <set>
#include <string>
#include <iostream>
#include <algorithm>
using namespace std;

void print (const string& str)
{
    cout << str << endl;
}

// int main()
// {
//     multiset<string> cities;
//     cities.insert ("Braunschweig");
//     cities.insert ("Hanover");
//     cities.insert ("Frankfurt");
//     cities.insert ("New York");
//     cities.insert ("Chicago");
//     cities.insert ("Toronto");
//     cities.insert ("Paris");
//     cities.insert ("Frankfurt");

//     // print each element:
//     for_each ( cities.begin(), cities.end(), print);
//     cout << endl;

//     // insert additional values:
//     cities.insert ("London");
//     cities.insert ("Munich");
//     cities.insert ("Hanover");
//     cities.insert ("Braunschweig");

//     // print each element:
//     for_each ( cities.begin(), cities.end(), print);
//     cout << endl;
// }

int main()
{
    multiset<string> cities {
	"Braunschweig", "Hanover", "Frankfurt", "New York",
	    "Chicago", "Toronto", "Paris", "Frankfurt"
	    };
    // print each element:
    for (const auto& elem : cities) {
	cout << elem << " ";
    }
    cout << endl;
    // insert additional values:
    cities.insert( {"London", "Munich", "Hanover", "Braunschweig"} );
    // print each element:
    for (const auto& elem : cities) {
	cout << elem << " ";
    }
    cout << endl;
}
