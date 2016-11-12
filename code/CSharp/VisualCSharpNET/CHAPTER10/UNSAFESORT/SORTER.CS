using System;

namespace MSPress.CSharpCoreRef.UnsafeSort
{
    /// <summary>
    /// Sorts an array of integers using the QuickSort
    /// algorithm. The class includes unsafe code blocks,
    /// so it must be compiled with the /unsafe switch.
    /// </summary>
	public class Sorter
	{
        public unsafe void UnsafeQuickSort(int* pLower, int* pUpper)
        {
            if(pLower < pUpper)
            {
                int* pOriginalLower = pLower;
                int* pOriginalUpper = pUpper;
                long elements = pUpper - pLower;
                int  midpointValue = *(pLower + (elements/2));
                while(pLower <= pUpper)
                {
                    // Find the first unsorted element below the midpoint.
                    while((pLower < pOriginalUpper)&&(*pLower < midpointValue))
                        ++pLower;

                    // Find the last unsorted element above the midpoint.
                    while((pUpper > pOriginalLower) && (*pUpper > midpointValue))
                        --pUpper;

                    if(pLower < pUpper)
                    {
                        // Sneaky trick that quickly swaps two scalar 
                        // values in-place.
                        *pLower ^= *pUpper;
                        *pUpper ^= *pLower;
                        *pLower ^= *pUpper;
                    }
                    if(pLower <= pUpper)
                    {
                        ++pLower;
                        --pUpper;
                    }
                }
                // Recursively call method again to sort the remaining
                // unsorted portion of the array.
                if(pLower < pOriginalUpper)
                    UnsafeQuickSort(pLower, pOriginalUpper);
                if(pUpper > pOriginalLower)
                    UnsafeQuickSort(pOriginalLower, pUpper);
            }
        }

        public void Sort(int [] numberArray)
        {
            unsafe
            {
                fixed(int* p = numberArray)
                {
                    UnsafeQuickSort(p, &p[numberArray.Length-1]);
                }
            }
        }
    }
}
