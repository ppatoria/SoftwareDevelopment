#include<stdio.h>
int fib(int n)
{
   if (n <= 1)
      return n;
   return fib(n-1) + fib(n-2);
}

int fib_non_recursive (int n)
{
    int first  = 0,
	second = 1;

    for (int i=0; i<n; i++)
    {
	int temp = first;
	first = second;
	second = temp + first;
    }
    return first;
}
 
int main ()
{
  int n = 6;
  printf("%d", fib(n));
  printf ("%d", fib_non_recursive (n));

  getchar(); 
   return 0;
}

//0,1,2,3,5,8


