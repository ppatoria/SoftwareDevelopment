#include <memory>
#include <iostream>
#include <string.h>
#include <bitset>

using namespace std;

typedef shared_ptr<char> CharArray_SPtr;
//typedef char*            CharArray_SPtr;
class Message
{
public:       
    Message(int size){	
        buffer = shared_ptr<char>(new char[size]);
	//buffer = new char[size];
	this->size = size;
    }
	
    CharArray_SPtr GetBuffer(){
	return buffer;
    }

    ~Message(){
	// cout << buffer << endl;
	// cout << "deleting buffer" << endl;
	// if(buffer)
	//     delete buffer;
	// else
	//     cout << "buffer is invalidated" << endl;
    }

private:
    CharArray_SPtr  buffer;
    int size;
};

int main (){
    //bitset<4> bits(1);
    string         message = "ancb";
    
    //bitset<4> bits(message);
    //message = bits.to_string();
    int            size = message.size();
    Message        msg(size);
    CharArray_SPtr buffer = msg.GetBuffer();
    
    memcpy (buffer.get(), message.c_str(), size);    
    //memcpy (buffer, message.c_str(), size);
    
    cout << buffer << endl;
    //delete buffer;
    return 0;
}
