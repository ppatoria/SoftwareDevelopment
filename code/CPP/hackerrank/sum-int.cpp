#include<iostream>
#include<algorithm>
#include<vector>

int main()
{
  std::vector<int> inputs;
  std::cin >> inputs[0]
	   >> inputs[1];
  auto sum = std::accumulate( inputs.begin(), inputs.end(), 0 );
  std::cout << sum;
  return 0;
}

