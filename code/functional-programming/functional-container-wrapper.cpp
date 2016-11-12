#include <iostream>
#include <map>
#include <vector>
#include <algorithm>
#include <sstream>
#include "gtest/gtest.h"
#include <cassert>

template <typename Type> 
void println( Type arg )
{
    std::cout << arg << std::endl;
}

bool contains( const auto& container, const auto& key)
{
  return (std::find(container.begin(), container.end(), key )) != container.end();
}

template <typename Container>
class functional
{
public:
  functional( Container container ) : container_(container)
  {}
  
  bool contains(const auto& key) const 
  {
    auto result = std::find(container_.begin(),
			    container_.end(),
			    key );
    return result != container_.end();
  }

 functional<Container> filter( auto predicate ) const
  {
    Container c;
    std::copy_if( container_.begin(),
		  container_.end(),
		  std::back_inserter( c ),
		  predicate);
    return std::move(functional(std::move(c)));
  }

  uint size() const 
  {
    container_.size();
  }

  void for_each( auto func ) const
  {
    std::for_each( container_.begin(), container_.end(), func );
  }

  functional<Container> map( auto select ) const
  {
    Container c;
    std::transform( container_.begin(),
  		    container_.end(),
  		    std::back_inserter( c ),
  		    select );
    return std::move(functional(std::move(c)));
  }
  
private:
  Container container_;
};

class FunctionalContainerWrapperTest : public testing::Test
{  
public:
  std::vector<int> vec{1,2,3,4,5};
  
};

TEST( FunctionalTest, contains_ok )
{
  std::vector<int> v{1,2,3,4,5};
  EXPECT_TRUE( contains(v, 1) ); 
}

TEST_F( FunctionalContainerWrapperTest, contains_ok )
{
  EXPECT_TRUE( functional<std::vector<int>>(vec).contains(1) );
}

TEST_F( FunctionalContainerWrapperTest, filter_ok )
{
   auto result = functional<std::vector<int>>( vec )
     .filter( [] (int i){ return (i < 3); } );
   
   EXPECT_EQ( result.size(), 2 );
   
   EXPECT_TRUE( result.contains(1) );   
   EXPECT_TRUE( result.contains(2) );
   EXPECT_FALSE( result.contains(4) );
}

TEST_F( FunctionalContainerWrapperTest, for_each_ok )
{
   const auto& result = functional<std::vector<int>>( vec )
     .filter( [] (int i){ return (i < 3); } );

   int counter = 0;

   result.for_each( [&counter](const int& i)
		    {
		      ++ counter;
		    });
   EXPECT_EQ( counter, result.size() );
}

TEST_F( FunctionalContainerWrapperTest, map_ok )
{
   const auto& result = functional<std::vector<int>>( vec )
     .filter( [] (int i){ return (i < 3); } )
     .map( [](int i){ return i * 2; } );
   EXPECT_EQ( result.size(), 2 );
   EXPECT_TRUE( result.contains(2) );
   EXPECT_TRUE( result.contains(4) );
   EXPECT_FALSE( result.contains(6) );
}
