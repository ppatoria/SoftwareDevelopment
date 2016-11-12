#include "functional-container.h"
#include "gtest/gtest.h"

class FunctionalContainerWrapperTest : public testing::Test
{  
public:
    std::vector<int> vec{1,2,3,4,5};
};


TEST_F( FunctionalContainerWrapperTest, contains_ok )
{
    EXPECT_TRUE(fp::container<std::vector<int>>(vec)
		.contains(1));
}

TEST_F( FunctionalContainerWrapperTest, filter_ok )
{
    auto result = fp::container<std::vector<int>>(vec)
	.filter([](int i)
		{
		  return (i < 3);
		});
   
    EXPECT_EQ( result.size(), 2 );
   
    EXPECT_TRUE(result.contains(1));   
    EXPECT_TRUE(result.contains(2));
    EXPECT_FALSE(result.contains(4));
}

TEST_F( FunctionalContainerWrapperTest, for_each_ok )
{
    const auto& result = fp::container<std::vector<int>>( vec )
	.filter([] (int i)
		{
		  return (i < 3);
		});
    
    int counter = 0;

    result.for_each([&counter](const int& i)
		    {
		      ++ counter;
		    });
    EXPECT_EQ( counter, result.size() );
}

TEST_F( FunctionalContainerWrapperTest, map_ok )
{
    const auto& result = fp::container<std::vector<int>>( vec )
	.filter([](int i)
		{
		  return (i < 3);
		})
	.map([](int i)
	     {
	       return i * 2;
	     });
    EXPECT_EQ( result.size(), 2 );
    EXPECT_TRUE( result.contains(2) );
    EXPECT_TRUE( result.contains(4) );
    EXPECT_FALSE( result.contains(6) );
}

TEST_F(FunctionalContainerWrapperTest, fold_left_ok)
{
  const auto& sum = fp::container<std::vector<int>>(vec)
    .fold_left(0, std::plus<int>());
  EXPECT_EQ(15, sum);
}

TEST_F(FunctionalContainerWrapperTest, fold_right_ok)
{
  const auto& sum = fp::container<std::vector<int>>(vec)
    .fold_right(0, std::plus<int>());
  EXPECT_EQ(15, sum);
}
