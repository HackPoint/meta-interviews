namespace Leetcode.Medium.DP;

public class DeleteAndEarns
{
    public int DeleteAndEarn(int[] nums)
    {
        int maxVal = MaxVal(nums);
        int[] points = new int[maxVal + 1];
        foreach (var t in nums)
        {
            points[t] += t;
        }

        int[] dp = new int[maxVal + 1];
        dp[0] = 0;
        dp[1] = points[1];

        for (int i = 2; i <= maxVal ; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + points[i]);
        }
        return dp[maxVal];
    }

    private int MaxVal(int[] nums)
    {
        int max = 0;
        foreach (int num in nums)
            if (max < num)
                max = num;
        return max;
    }
}