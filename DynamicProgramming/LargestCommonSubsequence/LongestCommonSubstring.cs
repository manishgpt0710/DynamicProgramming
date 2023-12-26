using System;
namespace DynamicProgramming.LargestCommonSubsequence
{
    public class LongestCommonSubstring
    {
        public LongestCommonSubstring()
        {
        }

        #region Find Longest Common Substring length
        /* I/P: 
         * a: abcdek
         * b: cdefgk
         * n: 6
         * m: 6
         * O/P: 3 => { cde }
         */

        public static int LCSubstring(string a, string b, int n, int m)
        {
            if (n == 0 || m == 0) return 0;
            int[,] tab = new int[n + 1, m + 1];
            int maxLength = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        tab[i, j] = tab[i - 1, j - 1] + 1;
                        maxLength = Math.Max(maxLength, tab[i, j]);
                    }
                }
            }
            return maxLength;
        }

        #endregion

    }
}

