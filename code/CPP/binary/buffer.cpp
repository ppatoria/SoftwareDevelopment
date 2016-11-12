#include <memory>
#include <iostream>
#include <stdint.h>
#include <vector>
#include <algorithm>
#include <cstring>

using namespace std;



int main(){
    
    typedef vector<uint8_t> bytes;

    char* buf = new char[10];
    memcpy(buf,"1234567890",10);
    void* vbuf = buf;
    uint8_t* uibuf = (uint8_t*)vbuf;

    bytes buffer;
    // buffer.insert(buffer.end(), &buf[0], &buf[10]);
    // cout << buf << endl;
    // for_each(buffer.begin(), buffer.end(), [](uint8_t ch){cout << ch << endl;});

    //     buffer.insert(buffer.end(), &vbuf[0], &vbuf[10]);
    // cout << vbuf << endl;
    // for_each(buffer.begin(), buffer.end(), [](uint8_t ch){cout << ch << endl;});

    buffer.insert(buffer.end(), &uibuf[0], &uibuf[10]);
    cout << uibuf << endl;
    for_each(buffer.begin(), buffer.end(), [](uint8_t ch){cout << ch << endl;});
    return 1;
    
}
