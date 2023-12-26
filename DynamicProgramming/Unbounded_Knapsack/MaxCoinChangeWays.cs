using System;
namespace DynamicProgramming.Unbounded_Knapsack
{
    public class MaxCoinChangeWays
    {
        public MaxCoinChangeWays()
        {
        }

        #region Find Max number of ways for Coin array and given sum
        /* I/P: 
         * Coin[]: { 1, 2, 3 }
         * Sum: 5
         * O/P: 5 => [{1,1,1,1,1}, {1,1,1,2}, {1,1,3}, {1,2,2}, {2, 3}]
         */

        public static int MaxCoinSubset(int[] coins, int sum)
        {
            if (coins.Length == 0 || sum == 0) return 0;
            int[,] tab = new int[coins.Length + 1, sum + 1];

            tab[0, 0] = 1;
            for (int i = 1; i <= coins.Length; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    if (coins[i - 1] <= j)
                    {
                        tab[i, j] = tab[i, j - coins[i - 1]] + tab[i - 1, j];
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

