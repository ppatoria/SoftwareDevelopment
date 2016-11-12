#include <iostream>
#include <vector>

const std::vector<std::vector<int>>& getCombinations( const std::vector<int>& list )
{
    std::vector<std::vector<int>> result;
    for( const auto& outer : list )
    {
        for( const auto& inner : list )
        {
            result.push_back( std::vector<int>{ outer, inner } );
        }
    }
    return std::move( result );
}

void print( std::vector<std::vector<int>> list )
{
    for( const auto& lst : list )
    {
        for( const auto& elem : lst )
        {
	    std::cout << elem;
        }
        std::cout << std::endl;
    }
}

int main()
{
    std::vector<int> list{ 1,2,3 };
    auto result = getCombinations( list );
    print( result );
    return 0;
}
