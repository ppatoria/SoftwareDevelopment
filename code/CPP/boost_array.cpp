/** TODO
 * what is unary_function?
 * class_name() struct_name() means instance of class or struct ?
 * Does for_each returns new container ? Does for_each modify the state ? 
 * Why assert didn't fail in case of char ?
 **/

#include <boost/array.hpp>
#include <algorithm>

using namespace std;

// Functional object to increment value by one
struct add_1 : public std::unary_function<int, void> 
{
    void operator()(int& c) const {
       c=c+10;
    }
    // If you're not in a mood to write functional objects,
    // but don't know what does 'boost::bind(std::plus<char>(),
    // _1, 1)' do, then read recipe 'Binding a value as a function 
    // parameter'.
};

struct print_char 
{
    void operator()(int& ch){
        cout << ch << endl;
    }
};

typedef boost::array<int, 4> array4_t;
array4_t& vector_advance(array4_t& val) {
    cout << "Entered vector_advance" << endl;

    // boost::array has begin(), cbegin(), end(), cend(), 
    // rbegin(), size(), empty() and other functions that are 
    // common for STL containers.
    std::for_each(val.begin(), val.end(), add_1());
    return val;
}

void print (array4_t& val)
{
    print_char print_ch;
    for_each (val.begin (), val.end (), print_ch );
}

int main() {
    // We can initialize boost::array just like an array in C++11:
    // array4_t val = {0, 1, 2, 3};
    // but in C++03 additional pair of curly brackets is required.
    cout << "Entered main" << endl;
    array4_t val = {{0, 1, 2, 3}};

    // boost::array works like a usual array:
    array4_t val_res;       // it can be default constructible and
    val_res = vector_advance(val);  // assignable
    // if value type supports default construction and assignment

    print (val);
    print (val_res);

    assert(val.size() == 4);
    assert(val[0] == 1);
    /*val[4];*/ // Will trigger an assert because max index is 3
    // We can make this assert work at compile-time.
    // Interested? See recipe 'Checking sizes at compile time' 
    // in Chapter 4, Compile-time Tricks.'
    assert(sizeof(val) == sizeof(char) * array4_t::static_size);
    cout << "returning from main" << endl;
    return 0;
}
