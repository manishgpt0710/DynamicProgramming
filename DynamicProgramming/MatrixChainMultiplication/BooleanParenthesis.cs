using System;
namespace DynamicProgramming.MatrixChainMultiplication
{
    public class BooleanParenthesis
    {
        public BooleanParenthesis()
        {
        }

        public static int BooleanParenthesization(string input)
        {
            //Your code here
            int N = input.Length;
            int i = 0, j = N - 1;
            int[,] tab = new int[N, N];

            Dictionary<string, int> values = new Dictionary<string, int>();

            return BooleanMemoized(input.ToCharArray(), i, j, true, values);
        }

        public static int BooleanMemoized(char[] arr, int i, int j, bool isTrue, Dictionary<string, int> values)
        {
            //Your code here
            int temp = 0;
            int lT, lF, rT, rF;
            if (i > j) return 0;

            string currentKey = i.ToString() + j.ToString() + isTrue.ToString();

            if (values.ContainsKey(currentKey))
            {
                // Console.WriteLine("GET VALUE >> Key: {0}, Value: {1}", currentKey, values[currentKey]);
                return values[currentKey];
            }
            if (i == j)
            {
                if (isTrue)
                {
                    values[currentKey] = arr[i] == 'T' ? 1 : 0;
                    return values[currentKey];
                }
                else
                {
                    values[currentKey] = arr[i] == 'F' ? 1 : 0;
                    return values[currentKey];
                }
            }

            for (int k = i + 1; k <= j - 1; k += 2)
            {
                lT = BooleanMemoized(arr, i, k - 1, true, values);
                lF = BooleanMemoized(arr, i, k - 1, false, values);
                rT = BooleanMemoized(arr, k + 1, j, true, values);
                rF = BooleanMemoized(arr, k + 1, j, false, values);

                if (isTrue)
                {
                    if (arr[k] == '&') temp += lT * rT;
                    if (arr[k] == '|') temp += lT * rT + lT * rF + lF * rT;
                    if (arr[k] == '^') temp += lT * rF + lF * rT;
                }
                else
                {
                    if (arr[k] == '&') temp += lF * rF + lT * rF + lF * rT;
                    if (arr[k] == '|') temp += lF * rF;
                    if (arr[k] == '^') temp += lT * rT + lF * rF;
                }
            }
            values[currentKey] = temp % 1003;
            return values[currentKey];
        }
    }
}

