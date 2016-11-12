#include <iostream>
#include "gtest/gtest.h"
#include <functional>

/********************************************/
/* Problem Definition:			    */
/* -------------------			    */
/* Reverse a string : Example:		    */
/*     Original string: "string to reverse" */
/*     Expected Result: "reverse to string" */
/********************************************/


namespace fp
{
    template<typename T>
    class vector
    {
    private:
	std::vector<T> vec_;
    public:

	vector<T>() = default;
    
	vector<T>( std::vector<T> v ) : vec_(v)
	    { }
    
	vector<T> reverse() const
	    {
		std::vector<T> temp(vec_);
		std::reverse(temp.begin(), temp.end());
		vector fp_vec(std::move(temp));
		return std::move(fp_vec);
	    }

	std::string to_string(const char delim) const
	    {
		std::stringstream ss;
		bool is_first = true;
		std::for_each(vec_.begin(), vec_.end(),
			      [&ss, &delim, &is_first](T t)
			      {
				  if(is_first)
				  {
				      is_first = false;
				  }
				  else
				  {
				      ss << delim;
				  }
				  ss << t;
			      });
		return std::move( ss.str() );
	    }

	void push_back(T t)
	    {
		vec_.push_back(std::move(t));
	    }

	const vector<T>& print(char delim) const
	    {
		std::for_each(vec_.begin(), vec_.end(),
			      [&delim](T t)
			      {
				  std::cout << t << delim;
			      });
		std::cout << std::endl;
		return *this;
	    }
    };
}

namespace my
{
    class string
    {
    public:
	string(std::string str) : str_(str)
	    { }

	fp::vector<std::string> split(const char delim) const
	    {
		fp::vector<std::string> result;
		std::string item;
		std::stringstream ss(str_);
      
		while(std::getline(ss, item, delim))
		{
		    result.push_back(std::move(item));
		}
		return std::move(result);
	    }
    
    private:
	std::string str_;
    };

    using uop = std::function<void(const std::string& word)> ;
    class string_parser
    {
    private:
	std::istringstream sentence_stream_;
    public:
	string_parser(std::string sentence) : sentence_stream_(sentence)
	    { }
      
	void for_each_word(const uop& func)
	    {
		for(auto iter = std::istream_iterator<std::string>(sentence_stream_);
		    iter != std::istream_iterator<std::string>();
		    ++iter)
		{
		    func(*iter);
		}
	    }
      
    };
}

namespace pb
{
    template<typename T>
    void println(const T& t)
    {
	std::cout << t << std::endl;
    }

    struct MakeSentenceReverse
    {
	MakeSentenceReverse() = default;
	std::string sentence;
	const std::string& operator()(const std::string& word) 
	    {
		if(is_first)
		{
		    sentence = word;
		    is_first=false;
		}
		else
		{
		    sentence.insert(0, word + space);
		}
		return sentence;
	    }
    private:
	bool is_first = true;
	const char space = ' ';
    };

    class reverse_string_test : public ::testing::Test
    {
    public:
	reverse_string_test()
	    {    
		std::cout << original_string << "\n";
	    }
	std::string make_reverse_sentence(const std::string& word);
	const std::string original_string = "string to reverse";
	const std::string expected_string = "reverse to string";
	const char delimiter_space = ' ';
    };


    TEST_F( reverse_string_test, functional )
    {
	auto result = my::string(original_string)
	    .split(delimiter_space)
	    .reverse()
	    .print(delimiter_space)
	    .to_string(delimiter_space);

	ASSERT_EQ(result, expected_string);
    }

    TEST_F(reverse_string_test, raw)
    {
	std::string result;
	std::istringstream sentence_stream(original_string);
	bool is_first = true;
	for(auto iter = std::istream_iterator<std::string>(sentence_stream);
	    iter != std::istream_iterator<std::string>();
	    ++iter)
	{
	    if(is_first)
	    {
		result = *iter;
		is_first=false;
	    }
	    else
	    {
		result.insert(0, *iter + delimiter_space);
	    }
	}

	std::cout << result << std::endl;
  
	ASSERT_EQ(result, expected_string);
    }

    TEST_F(reverse_string_test, raw_)
    {
	std::istringstream sentence_stream(original_string);
	auto iter = std::istream_iterator<std::string>(sentence_stream);
	auto eos = std::istream_iterator<std::string>();
	assert(iter!=eos); 
	std::string result = *iter;
	++iter;
	while(iter != eos)
	{
	    result.insert(0, *iter + delimiter_space);
	    ++iter;
	}
      
	std::cout << result << std::endl;
  
	ASSERT_EQ(result, expected_string);
    }


    TEST_F(reverse_string_test, raw_with_labda)
    {
	std::string reverse_sentence;
	bool is_first = true;
	my::string_parser(original_string).for_each_word(
	    [&reverse_sentence, &is_first, this]
	    (const std::string& word)
	    {
		if(is_first)
		{
		    reverse_sentence = word;
		    is_first=false;
		}
		else
		{
		    reverse_sentence.insert(0, word + delimiter_space);
		}
	    });
    
	std::cout << reverse_sentence << std::endl;
    
	ASSERT_EQ(reverse_sentence, expected_string);
    }


    TEST_F(reverse_string_test, raw_with_functor)
    {
	using namespace std::placeholders;
	MakeSentenceReverse reverse;
	auto reverse_op = std::bind(&MakeSentenceReverse::operator(), &reverse, _1); 
	my::string_parser(original_string)
	    .for_each_word(reverse_op);
	std::cout << reverse.sentence << std::endl;
	EXPECT_EQ(reverse.sentence, expected_string);
    }
}
