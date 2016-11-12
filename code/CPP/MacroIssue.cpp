//#include <stdio.h>

#define MAX(a,b) ( a>b ? a : b)

int main(void){
   int a=3, 
       b=4; 
   // printf("%d %d %d\n"
   //        ,a
   //        ,b
   //        ,MAX(a++,b++));

   printf("%d %d %d\n",
          MAX(a++,b++)
          ,a
          ,b);
}

//  a++>b++ ? a++ : b++)
//  4>5?:6
