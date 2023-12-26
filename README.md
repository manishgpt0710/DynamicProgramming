# Dynamic Programming

We have mainly three types of problem in Dynamic Programming-
1. Knapsack (0-1 Knapsack and Unbounded Knapsack)
2. Longest Common Subsequence (LCS)
3. Matrix Chain Multiplication (MCM)

## Types of problem in 0-1 Knapsack
1. Subset Sum
2. Equal Sum Partition
3. Count of Subset Sum
4. Minimum subset sum difference
5. Target Sum
6. Count of subset with respect to given difference

## Types of problem in Unbounded Knapsack
1. Rod Cutting Problem
2. Coin Change (Max # of ways)
3. Coin Change II (Min # of ways) 
4. Maximum Ribbon Cut

## Types of Problems in LCS
1. Longest Common Substring
2. Print LCS
3. Shortest Common Supersequence (SCS)
   `Explanation: Shortest Common Supersequence is the joining of two strings without repeating LCS.
    Means SCS(s1, s2, m, n) => m + n - LCS(s1, s2, m, n) `
4. Print SCS
5. Min # of insertion and deletion a->b
   `Explanation: To transform string a to b. We need to initially find common subsequence (LCS) and then 
   We can find # of deletions = (a.length - LCS) and # of insertions = (b.length - LCS)
   Example => a: heap, b: pea`
6. Largest Repeating Subsequence
7. Length of largest subsequence of 'a' which is substring in 'b'
8. Subsequence Pattern Matching
9. Count how many times 'a' appear as subsequence in 'b'
10. Longest Pallindrome Subsequence
  `Explanation: LPS(a) = LCS(a, reverse(a))
   Example => a: agbcba, b: abcbga`
11. Longest Pallindrome Substring
12. Count of Pallindrome Substring
13. Minimum # of deletion in a string to make it pallindrome
14. Minimum # of insertion in a string to make it pallindrome

## Types of Problems in MCM
1. MCM
2. Printing MCM
3. Evaluate expression to true / Boolean Parenthesization
4. Min / Max value of expression
5. Pallindrome Partitioning
6. Scramble String
7. Egg Dropping Problem
