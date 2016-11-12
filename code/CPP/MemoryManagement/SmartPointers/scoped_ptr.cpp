#include "boost/scoped_ptr.hpp"
#include <string>
#include <iostream>

using namespace std;
using namespace boost;

typedef scoped_ptr<string> message;

int main() {
    {
        message msg (new string ("Use scoped_ptr often."));        
        if (msg) 
            cout << *msg << endl;
        
        size_t i = msg->size();
        cout << i << endl;

        *msg = "Acts just like a pointer";
        cout << *msg << endl;

    } // p is destroyed here, and deletes the std::string

    
}

void scoped_vs_auto () {    
    scoped_ptr<string> p_scoped (new string("Hello"));
    auto_ptr<string>   p_auto   (new string("Hello"));
    p_scoped->size ();
    p_auto->size ();
    //scoped_ptr<string> p_another_scoped=p_scoped;
    auto_ptr<string> p_another_auto=p_auto;
    p_another_auto->size();
}
