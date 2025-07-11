namespace Leetcode.Medium.DP;

/// <summary>
/// Classification: Dynamic Programming (Unbounded Knapsack)
/// Algorithm: 1-D Bottom-Up DP with branch-break and stackalloc
/// Time:  O(amount × coins.Length)
/// Space: O(amount)  (stackalloc – on stack, no GC)
/// Passes > 95-98 % on LeetCode (C#)
/// </summary>
public class CoinChanges
{
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0) return 0;
        Array.Sort(coins);                       // позволяет ранний break

        int max = amount + 1;                   // “∞”
        Span<int> dp = max <= 2048
            ? stackalloc int[max]            // small: stackalloc
            : new int[max];                     // large: heap

        for (int i = 1; i < max; i++) dp[i] = max;
        dp[0] = 0;

        for (int val = 1; val <= amount; val++)
        {
            foreach (int coin in coins)
            {
                if (coin > val) break;          // ранний выход
                int prev = dp[val - coin];
                if (prev + 1 < dp[val])
                    dp[val] = prev + 1;
            }
        }

        return dp[amount] == max ? -1 : dp[amount];
    }
}