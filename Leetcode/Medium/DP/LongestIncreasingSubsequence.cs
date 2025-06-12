namespace Leetcode.Medium.DP;

public class LongestIncreasingSubsequence
{
    public int LengthOfLIS(int[] nums)
    {
        int[] sub = new int[nums.Length];
        int length = 0;
        
        foreach (int num in nums)
        {
            // Binary Search: O(n log n)
            int left = 0, right = length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (sub[mid] < num)
                    left = mid + 1;
                else
                    right = mid;
            }
            sub[left] = num;

            if (left == length)
                length++;
        }

        return length;
    }

    public int LengthOfLISIterative(int[] nums)
    {
        int[] dp = new int[nums.Length];
        Array.Fill(dp, 1);
        int comparisons = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                comparisons++;
                if (nums[j] < nums[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return comparisons;
    }
}