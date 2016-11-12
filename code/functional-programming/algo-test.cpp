#include <iostream>
#include <algorithm>
#include <vector>

//template<typename Type, typename CollType=>
void println( const std::vector<int>& v )
{
  std::for_each( v.begin(), v.end(),
		 [](int i)
		 {
		   std::cout << i << " ";
		 });
  std::cout << "\n";
}

struct ServiceEndpoint
{
  ServiceEndpoint(std::string name) : name_( std::move(name) )
  {}
  std::string name_;
};

int main()
{
  std::vector<int> v {1,2,3};
  
  auto elm_4 = [](int i){ return i == 4; }; 
  std::cout << std::any_of( v.begin(), v.end(), elm_4 ) << std::endl;

  auto elm_2 = [](int i){ return i == 2; }; 
  std::cout << std::any_of( v.begin(), v.end(), elm_2 ) << std::endl;

  auto iter  = std::remove_if( v.begin(), v.end(), elm_2 );

  std::cout << *iter << std::endl;

  println( v );
  
  std::vector<int> vec {1,2,3,4,5,6,7,8,9};
  println( vec );
  std::vector<std::string> str {"Programming", "in", "a", "functional", "style."};

  auto it = std::remove_if( vec.begin(), vec.end(),
			    [](int i)
			    {
			      return !((i<3) || (i>8));
			    });
  std::cout << "remove_if: begin:iter: ";
  std::for_each( vec.begin(), it,
		 [](int i)
		 {
		   std::cout << i;
		 });
  std::cout << "\n";
  
  println( vec );

  vec.erase( std::remove_if( vec.begin(), vec.end(),
			     [](int i)
			     {
			       return i==9;
			     }),
	     vec.end());
  println( vec );

  //std::accumulate( str.begin(), str.end(), "");
				  /* [](const std::string& sum, const std::string& current) */
				  /* { */
				  /*   sum+=current; */
				  /* }) ; */ 
  std::accumulate( vec.begin(), vec.end(), 0);

 std::vector<std::string> vstr{"Hello, ", " Cruel ", "World!"};
    std::string s;
    s = accumulate(begin(vstr), end(vstr), s,
    		     [](const std::string& sum, const std::string& current)
    		     {
		       std::cout << "..." << std::endl;
    		       return sum + current;
    		     });
		   
    std::cout << s; // Will print "Hello, Cruel World!" 

    ServiceEndpoint s1{"s1"}, s2{"s2"}, s3{"s3"};
    std::vector<ServiceEndpoint> ep{ s1,s2,s3 };
    ServiceEndpoint e{ "" };
    e = accumulate( ep.begin(), ep.end(), e ,
    		     [](const ServiceEndpoint& sum, const ServiceEndpoint& current)
    		     {
    		       return sum.name_ + current.name_;
    		     });
    std::cout << e.name_ << std::endl;
    return 0;
 

}
