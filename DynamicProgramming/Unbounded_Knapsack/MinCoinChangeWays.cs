using System;
namespace DynamicProgramming.Unbounded_Knapsack
{
    public class MinCoinChangeWays
    {
        public MinCoinChangeWays()
        {
        }

        #region Find Min number of coins to get the given sum from Coin array
        /* I/P: 
         * Coin[]: { 1, 2, 3 }
         * Sum: 5
         * O/P: 2 => [{2, 3}]
         */

        public static int MinCoinSubset(int[] coins, int sum)
        {
            const int MAX_VALUE = Int32.MaxValue - 1;
            if (sum == 0) return 0;
            if (coins.Length == 0) return MAX_VALUE;

            // Initialization
            int[,] tab = new int[coins.Length + 1, sum + 1];

            for (int i = 0, j = 0; j <= sum; j++)
                tab[i, j] = MAX_VALUE;

            for (int i = 1; i <= coins.Length; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (coins[i - 1] <= j)
                    {
                        tab[i, j] = Math.Min(tab[i, j - coins[i - 1]] + 1, tab[i - 1, j]);
                    }
                    else
                    {
                        tab[i, j] = tab[i - 1, j];
                    }
                }
            }

            //Result
            return tab[coins.Length, sum];
        }
        #endregion
    }
}

