using System;
using System.Text;

namespace DynamicProgramming.LargestCommonSubsequence
{
    public class LongestCommonSubsequence
    {
        public LongestCommonSubsequence()
        {
            /* Types of Problems in LCS
            * 1. Longest Common Substring
            * 2. Print LCS
            * 3. Shortest Common Supersequence (SCS)
            * Explanation: Shortest Common Supersequence is the joining of two strings without repeating LCS.
            * Means SCS(s1, s2, m, n) => m + n - LCS(s1, s2, m, n)
            * 4. Print SCS
            * 5. Min # of insertion and deletion a->b
            * Explanation: To transform string a to b. We need to initially find common subsequence (LCS) and then 
            * we can find # of deletions = (a.length - LCS) and # of insertions = (b.length - LCS)
            * Example => a: heap 
            *            b: pea  
            * 6. Largest Repeating Subsequence
            * 7. Length of largest subsequence of 'a' which is substring in 'b'
            * 8. Subsequence Pattern Matching
            * 9. Count how many times 'a' appear as subsequence in 'b'
            * 10. Longest Pallindrome Subsequence
            * Explanation: LPS(a) = LCS(a, reverse(a))
            * Example => a: agbcba
            *            b: abcbga
            * 11. Longest Pallindrome Substring
            * 12. Count of Pallindrome Substring
            * 13. Minimum # of deletion in a string to make it pallindrome
            * 14. Minimum # of insertion in a string to make it pallindrome
            */
        }

        #region Find Longest Common Subsequence
        /* I/P: 
         * a: abcdek
         * b: cdefgk
         * n: 6
         * m: 6
         * O/P: 4 => { c, d, e, k }
         */

        public static int LCS(string a, string b, int n, int m)
        {
            if (n == 0 || m == 0) return 0;

            if (a[n - 1] == b[m - 1])
            {
                return 1 + LCS(a, b, n - 1, m - 1);
            }
            else
            {
                return Math.Max(LCS(a, b, n, m - 1), LCS(a, b, n - 1, m));
            }
        }

        public static int LCS_Memoized(string a, string b, int n, int m)
        {
            if (n == 0 || m == 0) return 0;
            int[,] tab = new int[n + 1, m + 1];

            //Initialization
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    tab[i, j] = -1;
                }
            }

            return LCS_Memoized_Rec(a, b, n, m, tab);
        }

        public static int LCS_Memoized_Rec(string a, string b, int n, int m, int[,] tab)
        {
            if (n == 0 || m == 0) return 0;

            if (tab[n, m] != -1) return tab[n, m];

            //Memoization
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        tab[i, j] = LCS_Memoized_Rec(a, b, i - 1, j - 1, tab) + 1;
                    }
                    else
                    {
                        tab[i, j] = Math.Max(LCS_Memoized_Rec(a, b, i, j - 1, tab), LCS_Memoized_Rec(a, b, i - 1, j, tab));
                    }
                }
            }
            return tab[n, m];
        }

        public static int LCS_BottomUp(string a, string b, int n, int m)
        {
            if (n == 0 || m == 0) return 0;
            int[,] tab = new int[n + 1, m + 1];

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
            return tab[n, m];
        }

        #endregion

        #region Print LCS
        /* I/P: 
         * a: abcdek
         * b: cdefgk
         * n: 6
         * m: 6
         * O/P: 3 => { cde }
         */

        public static string PrintLCS(string a, string b, int n, int m)
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
                        sb.Append(a[i - 1]);
                    }
                    else
                    {
                        tab[i, j] = Math.Max(tab[i, j - 1], tab[i - 1, j]);
                    }
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}

