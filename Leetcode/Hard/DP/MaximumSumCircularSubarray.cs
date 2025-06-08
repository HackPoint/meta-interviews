using Leetcode.DSA;

namespace Leetcode.Hard.DP;

public class MaximumSumCircularSubarray
{
    /// <summary>
    /// Returns the maximum sum of a non-empty subarray in a circular array.
    /// </summary>
    /// <param name="nums">The input integer array (can be circular).</param>
    /// <returns>The maximum possible sum of a non-empty subarray.</returns>
    public int MaxSubarraySumCircular(int[] nums)
    {
        // Total sum of the array — needed to calculate circular max sum later.
        int total = 0;

        // For standard (non-circular) Kadane's algorithm.
        int currentMax = 0;
        int maxSum = int.MinValue;

        // For circular part: we find the minimum subarray sum as well.
        int currentMin = 0;
        int minSum = int.MaxValue;

        foreach (int num in nums)
        {
            // Kadane's Algorithm (Linear max subarray)
            // Either start new at num, or extend previous subarray
            currentMax = Math.Max(num, currentMax + num);
            maxSum = Math.Max(maxSum, currentMax);

            // Inverted Kadane's to find min subarray (used for circular wrap-around case)
            currentMin = Math.Min(num, currentMin + num);
            minSum = Math.Min(minSum, currentMin);

            // Running total of the entire array
            total += num;
        }

        // Edge Case: If all numbers are negative,
        // then total == minSum, and wraparound would give 0 (invalid)
        // So we must return the regular max subarray in that case
        if (maxSum < 0)
        {
            return maxSum;
        }

        //   Return the best between:
        // - Normal Kadane’s max
        // - Circular subarray max = total - minSubarray
        return Math.Max(maxSum, total - minSum);
    }
}