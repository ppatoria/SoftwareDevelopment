#include <iostream>
#include <stdio.h>
#include <cstring>

class CMyString
{
private:
  const char* str_;
  size_t size_;
  
public:
  
  CMyString()
    : str_( nullptr )
  {}

  CMyString( const char* str)
      : CMyString(  str , sizeof( str ))
  {}

  CMyString( const char* str, size_t size )
    : str_( str )
    , size_( size )
  {}

  CMyString& operator=( const CMyString& right )
  {
      if( this != &right )
      {
	  char* temp = new char[ right.size_ ];
	  strcpy( temp, right.str_ );
	  delete str_;
	  str_ = temp;
	  size_ = right.size_;
      }
      return *this;
  }

  friend std::ostream&
  operator<<( std::ostream& os, const CMyString& str )
  {
      os << str.str_;
      return os;
  }
};

int main()
{
    CMyString str1 { "str1" };
    CMyString str2, str3;
    str3 = str2  = str1;
    std::cout << str1 << "\t"
	      << str2 << "\t"
	      << str3 << std::endl;
    return 0;
}
