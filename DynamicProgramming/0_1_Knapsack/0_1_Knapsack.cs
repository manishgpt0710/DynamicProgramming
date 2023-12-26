using System;
namespace DynamicProgramming.Knapsack
{
    public class Knapsack_0_1
    {
        public Knapsack_0_1()
        {
            /* Types of problem in 0-1 Knapsack in DP 
            * 1. Subset Sum
            * 2. Equal Sum Partition
            * 3. Count of Subset Sum
            * 4. Minimum subset sum diff
            * 5. Target Sum
            * 6. Count of subset wrt given diff
            */
        }

        #region Find Maximum Profit with Given Sum(Weight)
        /* I/P: 
         * wt[]: { 1, 3, 4, 5 }
         * val[]: { 1, 4, 5, 7 }
         * W: 7
         * O/P: 9
         */

        public static int Knapsack_Recursive(int[] wt, int[] val, int n, int w)
        {
            if (n == 0 || w == 0) return 0;
            Console.WriteLine("Knapsack_Recursive method called for n: {0} and w: {1}", n, w);

            if (wt[n - 1] <= w)
            {
                return Math.Max(val[n - 1] + Knapsack_Recursive(wt, val, n - 1, w - wt[n - 1]),
                                Knapsack_Recursive(wt, val, n - 1, w));
            }
            else
            {
                return Knapsack_Recursive(wt, val, n - 1, w);
            }
        }

        public static int Knapsack_Memoization(int[] wt, int[] val, int n, int w)
        {
            if (n == 0 || w == 0) return 0;
            int[,] tab = new int[n + 1, w + 1];

            //Initialization
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= w; j++)
                {
                    tab[i, j] = -1;
                }
            }

            return Knapsack_Rec(wt, val, n, w, tab);
        }

        public static int Knapsack_Rec(int[] wt, int[] val, int n, int w, int[,] tab)
        {
            if (n == 0 || w == 0) return 0;

            if (tab[n, w] != -1) return tab[n, w];

            //Memoization
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= w; j++)
                {
                    if (tab[i, j] != -1) return tab[i, j];

                    if (wt[i - 1] <= j)
                    {
                        tab[i, j] = Math.Max(val[i - 1] + Knapsack_Rec(wt, val, i - 1, j - wt[i - 1], tab),
                                            Knapsack_Rec(wt, val, i - 1, j, tab));
                    }
                    else
                    {
                        tab[i, j] = Knapsack_Rec(wt, val, i - 1, j, tab);
                    }
                }
            }

            //Result
            return tab[n, w];
        }

        public static int Knapsack_BottomUp(int[] wt, int[] val, int n, int w)
        {
            if (n == 0 || w == 0) return 0;
            int[,] tab = new int[n + 1, w + 1];

            //Iteration
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= w; j++)
                {
                    if (wt[i - 1] <= j)
                    {
                        tab[i, j] = Math.Max(val[i - 1] + tab[i - 1, j - wt[i - 1]],
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

