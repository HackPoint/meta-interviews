namespace Leetcode.Medium.DP;

public class HouseRobberI
{
    public int Rob(int[] nums)
    {
        int prev = 0, sum = 0;
        foreach (var t in nums)
        {
            int temp = sum;
            sum = Math.Max(sum, prev + t);
            prev = temp;
        }

        return sum;
    }

    public int RobII(int[] nums)
    {
        Span<int> dp = stackalloc int[nums.Length];
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for(int i = 2; i < nums.Length; i++) {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        return dp[nums.Length - 1];
    }
}