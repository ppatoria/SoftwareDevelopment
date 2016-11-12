#include <iostream>

class cls
{
public:
  void func (const std::string& str)
  {
    std::cout << "const ref" << "\t" <<str << std::endl;
  }
      
  void func (std::string&& str)
  {
    std::cout << "move semantic..." << std::endl;
  }
};

std::string get_string_val()
{
  return "return val";
}

const std::string& get_string_ref_const()
{
  return std::string( "return const ref" );
}

std::string str;
std::string& get_string_ref( )
{
  str = "return ref";
  return str;
}

int main ()
{
  std::string str = "local var";
  cls c;
  c.func( "param" );                //1 move semantic
  c.func( std::string( "param" ));  //2 move semantic
  c.func( str );                    //3 const ref
  c.func( std::move( str ) );       //4 move semantic
  c.func( get_string_val() );       //5 move semantic
  c.func( get_string_ref() );       //6 const ref
  c.func( get_string_ref_const() ); //7 const ref
  return 1;
}
