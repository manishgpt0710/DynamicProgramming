using System;
namespace DynamicProgramming.Unbounded_Knapsack
{
    public class RodCuttingProblem
    {
        public RodCuttingProblem()
        {
            /* Types of problem in Unbounded Knapsack
            * 1. Rod Cutting
            * 2. Coin Change (Max # of ways)
            * 3. Coin Change II (Min # of ways) 
            * 4. Maximum Ribbon Cut
            */
        }

        #region Rod Cutting Problem
        /* I/P: 
         * Length[]: { 1, 2, 3, 4, 5, 6, 7, 8 }
         * Price[] : { 1, 5, 8, 9,10,17,17,20 }
         * N: 8
         * O/P: Maximum Profit = 22
         */

        public static int Unbounded_Knapsack(int[] length, int[] price, int n, int w)
        {
            if (n == 0 || w == 0) return 0;
            int[,] tab = new int[n + 1, w + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= w; j++)
                {
                    if (length[i - 1] <= j)
                    {
                        tab[i, j] = Math.Max(price[i - 1] + tab[i, j - length[i - 1]],
                                            tab[i - 1, j]);
                    }
                    else
                    {
                        tab[i, j] = tab[i - 1, j];
                    }
                }
            }

            //Result
            return tab[n, w];
        }
        #endregion
    }
}

