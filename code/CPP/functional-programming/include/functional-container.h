#include <iostream>
#include <map>
#include <vector>
#include <algorithm>
#include <sstream>
#include <cassert>

namespace fp
{
template <typename Col>
class container
{
public:
    container( Col col ) : col_(col)
	{}
  
    bool contains(const auto& key) const 
	{
	    auto result = std::find(col_.begin(),
				    col_.end(),
				    key );
	    return result != col_.end();
	}

    container<Col> filter( auto predicate ) const
	{
	    Col c;
	    std::copy_if( col_.begin(),
			  col_.end(),
			  std::back_inserter( c ),
			  predicate);
	    return std::move(container(std::move(c)));
	}

    uint size() const 
	{
	    col_.size();
	}

    void for_each( auto func ) const
	{
	    std::for_each( col_.begin(), col_.end(), func );
	}

    container<Col> map( auto select ) const
	{
	    Col c;
	    std::transform( col_.begin(),
			    col_.end(),
			    std::back_inserter( c ),
			    select );
	    return std::move(container(std::move(c)));
	}

    auto fold_left(auto initial_value, auto binary_operation) const 
	{
	    return std::accumulate(
		col_.begin(),
		col_.end(),
		initial_value,
		binary_operation);
	}

    auto fold_right(auto initial_value, auto binary_operation) const
	{
	    return std::accumulate(
		col_.rbegin(),
		col_.rend(),
		initial_value,
		binary_operation);
	}
  
private:
    Col col_;
};
}
