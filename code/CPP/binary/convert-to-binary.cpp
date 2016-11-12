#include <iostream> 
#include <bitset> 
#include <limits.h> 
#include <vector>
#include <stdint.h>
#include <memory>

using namespace std;

int main() {         
    int  val;     
    val = 121;
    //std::cin >> val;     
    std::bitset<sizeof(int) * CHAR_BIT>  bits(val);     
    std::cout << bits << "\n";

    bitset<8> bytes(val);
    string str = bytes.to_string<char, string::traits_type, string::allocator_type>();
    shared_ptr<vector<uint8_t>> ByteArray (new vector<uint8_t>(str.begin(), str.end()));
    cout << ByteArray->data();
    return 0;
}
