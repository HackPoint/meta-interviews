namespace Leetcode.Medium.DP;

/// <summary>
/// LeetCode 494. Target Sum
///
/// ❓ Problem:
/// Given an integer array `nums` and an integer `target`, return the number of ways to assign '+' and '-' to each element such that the resulting expression equals `target`.
///
/// ✅ Approach:
/// This is a classic **subset sum transformation** problem. We reduce it to finding the number of subsets with a specific sum.
///
/// Let:
/// • `P` be the sum of elements with `+`
/// • `N` be the sum of elements with `-`
///
/// We are solving:
///     P - N = target
///     P + N = totalSum
/// ⇒   2P = target + totalSum ⇒ P = (target + totalSum) / 2
///
/// So we reduce it to: **find number of subsets with sum = (target + totalSum) / 2**
///
/// 🧠 Algorithm:
/// • Use 1D DP array `dp[i]` = number of ways to reach sum `i`
/// • Initialize `dp[0] = 1` (one way to make sum 0: empty subset)
/// • For each number `num`, update `dp` backwards: from `subsetSum` down to `num`
///
/// ⚠️ Corner Case:
/// • If `(target + totalSum)` is odd or `|target| > totalSum`, it's impossible ⇒ return 0
///
/// ⏱️ Time Complexity: O(n * subsetSum)
/// 🧠 Space Complexity: O(subsetSum)
///
/// 🧪 Example:
/// Input: nums = [1,1,1,1,1], target = 3
/// totalSum = 5 → subsetSum = (3+5)/2 = 4
/// Ways to make sum 4: [1,1,1,1] (5 ways)
///
/// 🔄 Equivalent to 0/1 Knapsack subset sum count.
/// </summary>
public class TargetSum
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int totalSum = nums.Sum();
        
        // Check feasibility
        if ((target + totalSum) % 2 != 0 || Math.Abs(target) > totalSum)
            return 0;
        
        int subsetSum = (target + totalSum) / 2;
        
        // dp[i] = number of ways to reach sum i
        int[] dp = new int[subsetSum + 1];
        dp[0] = 1; // one way to make sum 0 — empty subset

        foreach (int num in nums)
        {
            // Go backwards to avoid reusing the same num
            for (int j = subsetSum; j >= num; j--)
            {
                dp[j] += dp[j - num];
            }
        }

        return dp[subsetSum];
    }
}