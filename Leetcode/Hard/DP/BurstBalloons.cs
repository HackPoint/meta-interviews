namespace Leetcode.Hard.DP;

/// <summary>
/// Classification: Dynamic Programming (Intervals)
/// Algorithm: dp[left][right] = max coins bursting balloons strictly
///            between indices left and right, assuming nums[left] and
///            nums[right] are the virtual boundaries (value 1).
///
/// Time Complexity:  O(n³)
/// Space Complexity: O(n²)
/// </summary>
public class BurstBalloons
{
    public int MaxCoins(int[] original)
    {
        // 1) Add virtual boundaries (value 1) to simplify edge handling
        int n = original.Length;
        int[] nums = new int[n + 2];
        nums[0] = nums[n + 1] = 1;
        Array.Copy(original, 0, nums, 1, n);
        n += 2;  // new length with boundaries

        // 2) dp[left, right] – max coins by bursting balloons (left, right) exclusively
        int[,] dp = new int[n, n];
                   
        // 3) Iterate by interval length (at least 2, because boundaries differ by ≥2)
        for (int length = 2; length < n; length++)
        {
            for (int left = 0; left + length < n; left++)
            {
                int right = left + length;
                // 4) Try every possible last balloon k between left and right
                for (int k = left + 1; k < right; k++)
                {
                    int coins = nums[left] * nums[k] * nums[right];
                    int total = dp[left, k] + coins + dp[k, right];
                    if (total > dp[left, right])
                        dp[left, right] = total;
                }
            }
        }

        // 5) Answer: burst everything between the two virtual 1's
        return dp[0, n - 1];
    }
}