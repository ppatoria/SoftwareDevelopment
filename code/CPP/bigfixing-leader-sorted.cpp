#include <iostream>
#include <vector>
#include <algorithm>
/* original */
int org_solution(std::vector<int>& A) {
    int n = A.size();
    std::vector<int> L;
    L.push_back(-1);
    for (int i = 0; i < n; i++) {
        L.push_back(A[i]);
    }
    int count = 0;
    int pos = n / 2;
    int candidate = L[pos];
    for (int i = 1; i <= n; i++) {
        if (L[i] == candidate)
            count = count + 1;
    }
    if (count > pos)
        return candidate;
    return (-1);
}

/* my solution */
int my_solution(std::vector<int>& A) {
    int n = A.size();
    std::vector<int> L;
    //L.push_back(-1);
    for (int i = 0; i < n; i++) {
        L.push_back(A[i]);
    }
    int count = 0;
    int pos = n / 2;
    int candidate = L[pos];
    for (int i = 1; i <= n; i++) {
        if (L[i] == candidate)
            count = count + 1;
    }
    if (count > pos)
        return candidate;
    return (-1);
}

/* correct solution */
int correct_solution( std::vector<int>& A )
{
  int n = A.size();
  std::vector<int> L;
  L.push_back( -1 );
  for (int i = 0; i < n; i++)
    {
      L.push_back(A[i]);
    }
  int count = 0;
  int pos = (n + 1)/2;
  int candidate = L[pos];
  for (int i = 1; i <= n; i++) {
    if (L[i] == candidate)
      count = count + 1;
  }
  
  if (2*count > n )
    return candidate;
  
  return (-1);
}

void test(std::vector<int>& v)
{
  std::cout << "original: " << org_solution( v ) << std::endl;
  std::cout << "my: " << my_solution( v ) << std::endl;
  std::cout << "corrent: " << correct_solution( v ) << std::endl;
  
}
int main()
{
  std::vector<int> v{1,1,1,1,2,2,2,2,2,2};
  std::vector<int> v1{0,0,1,1,2,2,2,2,2,2};
  std::vector<int> v2{0,0,0,0,0,1,1,1,1,1,1};
  std::vector<int> v3{2};  
  std::vector<int> v4{2,3};  

  test( v );
  test( v1 );
  test( v2 );
  test( v3 );
  test( v4 );
}


/* correct solution */
/*     def solution(A):  */
/*     n = len(A) */
/*     L = [-1] + A */
/*     count = 0 */
/*     pos = (n + 1) // 2 */
/*     candidate = L[pos] */
/*     for i in xrange(1, n + 1): */
/*         if (L[i] == candidate): */
/*             count = count + 1 */
/*     if (2*count > n): */
/*         return candidate */
/*     return -1 */
