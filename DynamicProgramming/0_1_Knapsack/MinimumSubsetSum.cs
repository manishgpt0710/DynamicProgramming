using System;
namespace DynamicProgramming.Knapsack
{
    public class MinimumSubsetSum
    {
        public MinimumSubsetSum()
        {
        }

        #region Minimum Subset Sum Difference
        /*  I/P: 
         *  arr[] = {1, 6, 11, 5} 
            Output: 1
            Explanation:
            Subset1 = {1, 5, 6}, sum of Subset1 = 12 
            Subset2 = {11}, sum of Subset2 = 11

           S1-S2 = MINIMUM VALUE (MIN)
           S1+S2 = RANGE
        --------------------------
           2S1 = RANGE - MIN
           RANGE - 2S1 = MIN 
         */

        public static int MinimumSubsetSumDifference(int[] arr)
        {
            int range = 0, s1 = 0;
            for (int i = 0; i < arr.Length; i++)
                range += arr[i];

            for (int i = 1; i <= range / 2; i++)
            {
                if (SubsetSum.IsSubsetSumExists(arr, i))
                {
                    if (s1 < i) s1 = i;
                }
            }

            return range - 2 * s1;
        }
        #endregion
    }
}

