using System;
namespace DynamicProgramming.Knapsack
{
    public class TargetSum
    {
        public TargetSum()
        {
        }

        #region Target Sum
        /*  I/P: 
         *  arr[] = {1, 1, 2, 3} 
         *  sum   = -7
            Output: 3
            Problem: We can either add positive or negative sign to each element of given array.
                     And we need to find out how many different way we can get the given sum while changing sign.
            Explanation: Here we can separate the positive and negative number into two subset S1 and S2.
            S1 = {1, 3}, sum of S1 = 4 
            S2 = {-1, -2}, sum of S2 = -3
            S1 + S2 = 1 (equal to given sum)

            Now we can take negative sign out of S2 and this problem will be equivalent to count of subset wrt given difference.
         */

        public static int TargetSumCount(int[] arr, int sum)
        {
            int range = 0;
            for (int i = 0; i < arr.Length; i++)
                range += arr[i];

            if ((range + sum) % 2 != 0) return 0;

            return SubsetSum.SubsetSumCount(arr, (range + sum) / 2);
        }
        #endregion
    }
}
