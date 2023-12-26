using System;
namespace DynamicProgramming.MatrixChainMultiplication
{
    public class MatrixChainMultiplication
    {
        public MatrixChainMultiplication()
        {
            /* Types of Problems in DP
            * 1. MCM
            * 2. Printing MCM
            * 3. Evaluate expression to true / Boolean Parenthesization
            * 4. Min / Max value of expression
            * 5. Pallindrome Partitioning
            * 6. Scramble String
            * 7. Egg Dropping Problem
            */
        }

        #region Find out minimum number of multiplication required for MCM
        /* I/P: arr[] = { 40, 20, 30, 10, 30 }
         * Here i should be 1 and j should be arr.Length - 1
         * O/P: 24000
         */

        public static int McmRecursive(int[] arr, int i, int j)
        {
            if (i >= j) return 0;

            int min = Int32.MaxValue, temp = 0;
            for (int k = i; k < j; k++)
            {
                temp = McmRecursive(arr, i, k) + McmRecursive(arr, k + 1, j) + arr[i - 1] * arr[k] * arr[j];
                min = Math.Min(min, temp);
            }
            return min;
        }

        public static int MatrixMultiplication(int N, int[] arr)
        {
            //Your code here
            int i = 1, j = N - 1;
            int[,] tab = new int[N, N];

            for (int m = 0; m < N; m++)
            {
                for (int n = m + 1; n < N; n++)
                {
                    tab[m, n] = -1;
                }
            }
            return McmMemoized(arr, i, j, tab);
        }

        public static int McmMemoized(int[] arr, int i, int j, int[,] tab)
        {
            //Your code here
            int temp = 0, minValue = Int32.MaxValue;
            if (i >= j) return 0;

            if (tab[i, j] >= 0) return tab[i, j];

            for (int k = i; k < j; k++)
            {
                temp = McmMemoized(arr, i, k, tab) + McmMemoized(arr, k + 1, j, tab) + arr[i - 1] * arr[k] * arr[j];
                minValue = Math.Min(minValue, temp);
                tab[i, j] = minValue;
            }
            return minValue;
        }
        #endregion
    }
}
