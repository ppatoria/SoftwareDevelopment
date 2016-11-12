#include <iostream>
#include <cassert>

class cls
{
public:
  cls () = default;

  ~cls ()
  {
    delete ch_arr_;
  }
  
  cls (const std::string&& str)  
    : str_(std::move( str ))
    , ch_arr_ (nullptr)
  {}

  cls (const char* ch_arr)
    : ch_arr_( ch_arr )
    , str_ (ch_arr)
  {}
  
  cls (const cls& rhs)  
  {
    ch_arr_ = rhs.ch_arr_;
    str_ = rhs.str_;
  }
  
  void print() const 
  {
    if( ch_arr_ )
      std::cout << ch_arr_ << std::endl;

    if( !str_.empty() )
      std::cout << str_ << std::endl; 
  }
  
private:
  std::string str_;
  const char* ch_arr_;
};

int main ()
{
  const char* str = "val";
  //std::string str = "val";
  
  cls c( str );
  c.print();
  return 1;
}
