#include <iostream>
#include <algorithm>
#include <vector>
#include <gtest/gtest.h>
#include<iterator>

void println(std::ostream& os )
{
  std:: cout << os << std::endl;
}

TEST( hackerrank, sum_of_2_int )
{
  std::vector<int> inputs;

  std::cout << "inputs from console:\n";
  for(int i=0; i<3; i++)
  {
    int input;
    std::cin >> input;
    inputs.push_back( input );
  }
  
  EXPECT_FALSE( inputs.empty() );
  EXPECT_EQ( inputs.size(), 3 );

  auto till_second = inputs.begin() + 2;
  auto sum = std::accumulate( inputs.begin(), till_second, 0 );

  EXPECT_EQ( sum, inputs[2] );
}

TEST( hackerrank, sum_of_2_int_using_iterator )
{
  std::cout << "inputs from console:\n";
  std::vector<int> inputs( std::istream_iterator<int>(std::cin),
			   std::istream_iterator<int>() );
  
  EXPECT_FALSE( inputs.empty() );
  EXPECT_EQ( inputs.size(), 3 );

  auto till_second = inputs.begin() + 2;
  auto sum = std::accumulate( inputs.begin(), till_second, 0 );

  EXPECT_EQ( sum, inputs[2] );
}

TEST( hackerrank, sum_of_2_int_using_iterator_ )
{
  std::vector<int> inputs;
  std::cout << "inputs from console:\n";
  std::istream_iterator<int> cin_iter(std::cin), cin_iter_end;
  for(int i=0; i<3; i++ )
  {
    std::cout << *cin_iter << std::endl;
    inputs.push_back(*cin_iter);
    ++ cin_iter;
  }
  
  EXPECT_FALSE( inputs.empty() );
  EXPECT_EQ( inputs.size(), 3 );

  auto till_second = inputs.begin() + 2;
  auto sum = std::accumulate( inputs.begin(), till_second, 0 );

  EXPECT_EQ( sum, inputs[2] );
}

TEST( hackerrank, sum_of_2_int_using_iterator__ )
{
  std::cout << "inputs from console:\n";
  std::istream_iterator<int> cin_input(std::cin), cin_end;
  
  auto sum = std::accumulate( cin_input, cin_end, 0 );

  EXPECT_EQ( sum, 5 );
}

TEST( hackerrank, sum_of_array )
{
  int n;
  std::cin >> n;
  std::vector<int> arr(n);

  for(int arr_i = 0;arr_i < n;arr_i++){
    std::cin >> arr[arr_i];
  }

  auto sum = accumulate(arr.begin(), arr.end(), 0);
  EXPECT_EQ( sum, 9 );
}

template <typename T>
struct fraction
{
    fraction( double size_of_array )
	: _size_of_array(size_of_array)
	{}

    double operator()( T size_of_numbers)
	{
	    return std::divides<double>()(
		static_cast<double>(size_of_numbers),
		_size_of_array );
	}
private:
    double _size_of_array;
};

template <typename Iter>
void println( const std::string& msg, Iter begin, Iter end )
{
    std::cout << msg << std::endl;
    std::for_each(begin, end, [](const int el)
		  {
		      std::cout << el << "\t";
		  });
    std::cout << std::endl;
}
    
TEST( hackerrank, sort_and_fraction )
{
  
  std::vector<int> arr{ -4, 3, -9, 0, 4, 1 }; 
  std::sort( arr.begin(), arr.end(), std::greater<int>() );
  
  println( "sorted array", arr.begin(), arr.end() );  // -9 -4 0 1 3 4
  
  fraction<double> fraction_of(static_cast<double>(arr.size()));
  
  auto first_occurance_of_zero = std::find( arr.begin(), arr.end(), 0 );
  auto size_of_negative_numbers = std::distance( arr.begin(), first_occurance_of_zero ) - 1; 
  EXPECT_EQ( size_of_negative_numbers, 2 );
  auto fraction_of_negative_numbers = fraction_of( size_of_negative_numbers );
  EXPECT_EQ(fraction_of_negative_numbers, 0.333333);

  std::vector<int> zero{0};
  auto last_occurance_of_zero = std::find_end(
      arr.begin(), arr.end(),
      zero.begin(), zero.end() );
  auto size_of_zeros = std::distance( first_occurance_of_zero, last_occurance_of_zero ) + 1;
  EXPECT_EQ( first_occurance_of_zero, last_occurance_of_zero );
  EXPECT_EQ( 1, size_of_zeros );
  auto fraction_of_zeros = fraction_of( size_of_zeros );
  EXPECT_EQ( fraction_of_zeros, 0.166667 );
  
  auto size_of_positive_numbers = std::distance( last_occurance_of_zero, arr.end() ) ;
  EXPECT_EQ( size_of_positive_numbers, 3 );
  auto fraction_of_positive_numbers = fraction_of( size_of_positive_numbers );
  EXPECT_EQ( fraction_of_positive_numbers, 0.500000 );
}
