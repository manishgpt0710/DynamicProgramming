using System;
using System.Text;

namespace DynamicProgramming.LargestCommonSubsequence
{
    public class ShortestCommonSupersequence
    {
        public ShortestCommonSupersequence()
        {
        }

        #region Print SCS
        /* I/P: 
         * a: ABCDGH
         * b: ACDGHR
         * n: 6
         * m: 6
         * O/P: ABCDGHR
         */

        public static string PrintSCS(string a, string b, int n, int m)
        {
            if (n == 0 || m == 0) return "-1";

            int[,] tab = new int[n + 1, m + 1];
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        tab[i, j] = tab[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        tab[i, j] = Math.Max(tab[i, j - 1], tab[i - 1, j]);
                    }
                }
            }

            int x = n, y = m;

            while (x > 0 || y > 0)
            {
                if (x == 0)
                {
                    sb.Insert(0, b[y - 1]);
                    y--;
                }
                else if (y == 0)
                {
                    sb.Insert(0, a[x - 1]);
                    x--;
                }
                else if (a[x - 1] == b[y - 1])
                {
                    sb.Insert(0, a[x - 1]);
                    x--;
                    y--;
                }
                else if (tab[x, y - 1] > tab[x - 1, y])
                {
                    sb.Insert(0, b[y - 1]);
                    y--;
                }
                else
                {
                    sb.Insert(0, a[x - 1]);
                    x--;
                }
            }

            return sb.ToString();
        }
        #endregion
    }
}

