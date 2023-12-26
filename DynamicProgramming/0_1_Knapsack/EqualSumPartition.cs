using System;
namespace DynamicProgramming.Knapsack
{
    public class EqualSumPartition
    {
        public EqualSumPartition()
        {
        }

        #region Equal Sum Partition Problem
        /* I/P: 
         * arr[]: { 1, 5, 11, 6 }
         * O/P: True
         */

        public static bool IsEqualSumPartitionExists(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
                sum += arr[i];

            if (sum % 2 == 0)
                return SubsetSum.IsSubsetSumExists(arr, sum / 2);
            else
                return false;
        }
        #endregion
    }
}

