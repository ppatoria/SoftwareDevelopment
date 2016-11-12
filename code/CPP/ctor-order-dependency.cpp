#include <memory>
class MyString {
public:
  MyString();
  ~MyString();
  MyString(const MyString& s);              // copy constructor
  MyString& operator= (const MyString& s);  // assignment
  // ...
protected:
  unsigned len_;
  char*    data_;
};


MyString::MyString()
  : len_(0u)
  , data_(new char[1])
{
  data_[0] = '\0';
}

MyString::~MyString()
{
  delete[] data_;
}

MyString::MyString(const MyString& s)
  : len_ (s.len_)
  , data_(new char[s.len_ + 1u]) //      <--Not {tt{new char[len_+1]}tt}
{                 // ↑↑↑↑↑↑   // not len_
  memcpy(data_, s.data_, len_ + 1u);
}
//↑↑↑↑   // no issue using len_ in ctor's {body}
int main()
{
  MyString a;      // default ctor; zero length MyString ("")
  MyString b = a;  // copy constructor
  return 0;
}
