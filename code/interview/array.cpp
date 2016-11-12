/* Question 5 An array contains n numbers ranging from 0 to n-2. There is exactly one number duplicated in the array. How do you find the duplicated */
/* number? For example, if an array with length 5 contains numbers {0, 2, 1, 3, 2}, the duplicated number is 2. */

int duplicate(int numbers[])
{
  int length = numbers.length;
  int sum1 = 0;
  for(int i = 0; i < length; ++i)
    {
      if(numbers[i] < 0 || numbers[i] > length - 2)
	  throw new IllegalArgumentException("Invalid numbers.");
      sum1 += numbers[i];
    }
  int sum2 = ((length - 1) * (length - 2)) >> 1;
  return sum1 - sum2;
}

  
