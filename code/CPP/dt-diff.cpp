#include <iostream>
#include <thread>
#include <chrono>

int main()
{
  using namespace std::chrono;
  using clock =  std::chrono::high_resolution_clock;
  
  auto t0 = clock::now();
  
  std::this_thread::sleep_for( milliseconds(50) );
  
  auto t1 = clock::now();
  
  auto ms = duration_cast<milliseconds>(t1 - t0);
  
  std::cout << ms.count() << "ms\n";
}
