#include<iostream>
#include<algorithm>

std::vector<double> make_C( std::vector<int>& A,
			 std::vector<int>& B,
			 std::function<bool( double a, double b, double& c )> op )
{
    std::vector<double> C;
    for( int i = 0; i < A.size(); i ++ )
    {
	double result = 0.0;
	if( op( A[i], B[i], result ))
	{
	    C.push_back( result );
	}
    }
    return std::move( C );
}

template <typename T>
void print( std::vector<T> v )
{
    if( v.empty() )
    {
	std::cout << "vector is empty" << std::endl;
    }
    else
    {
	std::for_each( v.begin(), v.end(),
		       []( T elem )
		       {
			   std::cout << elem << std::endl;
		       });
    }
}

int solution( std::vector<int>& A, std::vector<int>& B )
{
    if( A.empty() or B.empty() or (A.size() != B.size()) )
    {
	return -1;
    }

    auto filter = [](double a, double b, double& out_c)
	{
	    out_c = a + b / 1000000; 
	    return out_c > 1 ? true : false;
	};
  
    std::vector<double> C = make_C( A, B, filter );

    print( C );
    
    std::sort( C.begin(), C.end() );

    print( C );
    
    auto result = 0;
    auto pos = 0;
    auto len = C.size() - 1;
		       
    while (len > pos)
    {
	auto res = C[len] / (C[len] - 1);
        while (pos < len and C[pos] < res)
	{
            pos = pos + 1;
	}
        if (pos == len)
	{
            break;
	}
        result = result + (len - pos);
        
        if (result > 1000000000)
	{
            return 1000000000;
	}
        
        len = len - 1;
    }
    return result;
}


int main()
{
    std::vector<int> A { 0, 1, 2, 2, 3, 5 };
    std::vector<int> B {500000, 500000, 0, 0, 0, 20000 };
    std::cout << "result: " << solution( A, B ) << std::endl;
    return 0;
}

/* def solution(A, B): */
/*     # write your code in Python 2.7 */
/*     if not len(A) or not len(B) or len(A) != len(B): */
/*         return -1 */
 
/*     # make C and filter all values <= 1 */
/*     C = [A[i]+float(B[i])/1000000 for i in range(len(A)) if A[i]+float(B[i])/1000000 > 1] */
    
/*     C.sort() */
/*     result = 0 */
    
/*     p = 0  # position */
/*     l = len(C) - 1 */
    
/*     while l > p: */
/*         res = C[l] / (C[l] - 1) */
/*         while (p < l and C[p] < res): */
/*             p = p + 1 */
/*         if p == l: */
/*             break */
/*         result = result + (l-p) */
        
/*         if result > 1000000000: */
/*             return 1000000000 */
        
/*         l = l-1 */
        
 
/*     return result */



