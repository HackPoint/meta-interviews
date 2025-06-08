namespace Leetcode.DSA;

public class KadanesAlgorithm
{
    public static int MaxSubArray(int[] nums)
    {
        int maxSum = int.MinValue;
        int currentSum = 0;

        foreach (int num in nums)
        {
            currentSum += num;
            maxSum = Math.Max(currentSum, maxSum);
            if (currentSum < 0)
            {
                currentSum = 0;
            }
        }

        return maxSum;
    }
}