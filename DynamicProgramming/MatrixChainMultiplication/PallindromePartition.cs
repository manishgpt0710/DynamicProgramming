using System;
namespace DynamicProgramming.MatrixChainMultiplication
{
    public class PallindromePartition
    {
        public PallindromePartition()
        {
        }

        public static int PallindromePartitioning(string input)
        {
            //Your code here
            int N = input.Length;
            int i = 0, j = N - 1;
            int[,] tab = new int[N, N];

            return PallindromeMemoized(input, i, j, tab);
        }

        public static int PallindromeMemoized(string arr, int i, int j, int[,] tab)
        {
            int temp = 0, minValue = Int32.MaxValue;
            if (isPallindrome(arr, i, j)) return 0;

            if (tab[i, j] > 0) return tab[i, j];

            for (int k = i; k < j; k++)
            {
                temp = PallindromeMemoized(arr, i, k, tab) + PallindromeMemoized(arr, k + 1, j, tab) + 1;
                minValue = Math.Min(minValue, temp);
                tab[i, j] = minValue;
            }
            return minValue;
        }

        private static bool isPallindrome(string arr, int i, int j)
        {
            if (i >= j) return true;
            while (i < j)
            {
                if (arr[i++] != arr[j--]) return false;
            }
            return true;
        }
    }
}

