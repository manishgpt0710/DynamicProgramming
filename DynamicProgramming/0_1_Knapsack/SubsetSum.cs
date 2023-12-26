using System;
namespace DynamicProgramming.Knapsack
{
    public class SubsetSum
    {
        public SubsetSum()
        {
        }

        #region Subset Sum
        /* I/P: 
         * arr[]: { 2, 3, 7, 8, 10 }
         * Sum: 11
         * O/P: True
         */

        public static bool IsSubsetSumExists(int[] arr, int sum)
        {
            bool[,] tab = new bool[arr.Length + 1, sum + 1];

            tab[0, 0] = true;
            for (int i = 1; i <= arr.Length; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    if (arr[i - 1] <= j)
                        tab[i, j] = tab[i - 1, j - arr[i - 1]] || tab[i - 1, j];
                    else
                        tab[i, j] = tab[i - 1, j];
                }
            }
            return tab[arr.Length, sum];
        }
        #endregion

        #region Count of Subset Sum
        /* I/P: 
         * arr[]: { 3, 5, 6, 7 }
         * Sum: 9
         * O/P: 1
         */

        public static int SubsetSumCount(int[] arr, int sum)
        {
            int[,] tab = new int[arr.Length + 1, sum + 1];

            tab[0, 0] = 1;
            for (int i = 1; i <= arr.Length; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    if (arr[i - 1] <= j)
                        tab[i, j] = tab[i - 1, j - arr[i - 1]] + tab[i - 1, j];
                    else
                        tab[i, j] = tab[i - 1, j];
                }
            }
            return tab[arr.Length, sum];
        }
        #endregion


    }
}

