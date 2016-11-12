#include <iostream>
#include <map>
#include <vector>
#include <algorithm>
#include <sstream>

template<typename KeyType, typename ValueType>
bool contains( std::map<KeyType,ValueType> const & my_map,
	       KeyType const key)
{
  return my_map.find( key ) != my_map.end();
}

template <typename Type> 
void println( Type arg )
{
    std::cout << arg << std::endl;
}

namespace functional
{
  template <typename Type>
  class vector : public std::vector<Type>
  {
  public:
    virtual ~vector() = default;
    template<typename UnaryPredicate>
    functional::vector<Type> filter( UnaryPredicate predicate )
    {
      functional::vector<Type> v;
      std::copy_if( this->begin(),
		    this->end(),
		    std::back_inserter( v ),
		    predicate);
      return v;
    }
 
    template <typename Function,  typename ReturnType
	      = typename std::result_of<Function(Type)>::type>

    functional::vector<ReturnType> map( Function select_lambda )
    {
      functional::vector<ReturnType> v;
      std::transform( this->begin(),
		      this->end(),
		      std::back_inserter( v ),
		      select_lambda );
      return v;
    }

    template <typename InitialValueType>
    Type fold( InitialValueType initial_value)
    {
	return std::accumulate( this->begin(),
				this->end(),
				initial_value);
    }
      
    template <typename InitialValueType, typename BinaryOperation>
    Type fold( InitialValueType initial_value,
	       BinaryOperation op)
    {
	return std::accumulate( this->begin(),
				this->end(),
				initial_value,
				op );
    }

    template <typename InitialValueType>
    Type fold_back( InitialValueType initial_value)
    {
	return std::accumulate( this->rbegin(),
				this->rend(),
				initial_value);
    }
      
    template <typename InitialValueType, typename BinaryOperation>
    Type fold_back( InitialValueType initial_value,
		    BinaryOperation op)
    {
	return std::accumulate( this->rbegin(),
				this->rend(),
				initial_value,
				op );
    }

    template <typename Function>
    void for_each( Function func )
    {
      std::for_each(this->begin(), this->end(),
		    func);
    }
  };
}
int main()
{
  std::map<int,std::string> my_map;
  my_map[1] = "one";
  my_map[2] = "two";
  
  std::cout << contains( my_map, 2 ) << std::endl;

 /* auto v = std::vector<int> {1,2,3,4,5,6,7,8,9}; */
 /* auto t1 = where(v, [](int e){return e % 2 == 0; }); */
 /* auto t2 = select(t1, [](int e){return e*e; }); */
 /* auto s = sum(t2); */

  functional::vector<int> v;
  v.push_back(1);
  v.push_back(2);
  v.push_back(3);
  v.push_back(4);
  v.push_back(5);
  v.push_back(6);
  v.push_back(7);
  v.push_back(8);
  v.push_back(9);
 /* auto v = functional::vector<int> {1,2,3,4,5,6,7,8,9}; */
  auto n = v
      .filter( [](int e){ return e % 2 == 0; } )
      .map   ( [](int e){ return e*e; } );

  n.for_each( [](int e){ println(e); });
  
  auto s = v
      .filter( [](int e){ return e % 2 == 0; } )
      .map   ( [](int e){ return e*e; } )
      .fold  ( 0 );
 
 std::cout << s << std::endl;

 v.for_each( [](int e){ println(e); });

 auto m = v.fold( 1,
		  []( int folded_value, int current )
		  {
		      std::ostringstream os;
		      os << "folded_value: " <<folded_value << " current: " << current;
		      println( os.str() );
		      return folded_value * current;
		  });
  println( m );

  auto rm = v.fold_back( 1,
		   []( int folded_value, int current )
			 {
			     std::ostringstream os;
			     os << "folded_value: " <<folded_value
			     << " current: " << current;
			     println( os.str() );
			     return folded_value * current;
			 });
  println( rm );
  
  auto sum = v
      .filter( [](int e){ return e % 2 == 0; } )
      .map   ( [](int e){ return e*e; } )
      .fold  ( 0, []( int folded_value, int current )
	       {
		   return folded_value + current;
	       });
  println( sum );
}
