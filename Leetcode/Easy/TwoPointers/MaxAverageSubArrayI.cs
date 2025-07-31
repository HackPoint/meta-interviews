namespace Leetcode.Easy.TwoPointers;

/// <summary>
/// Problem:
/// Given an integer array `nums` and an integer `k`, return the maximum average value of any contiguous subarray of length `k`.
///
/// Approach:
/// - Use the Sliding Window pattern:
///     - Compute the sum of the first `k` elements.
///     - Slide the window forward by removing the leftmost element and adding the new rightmost element.
///     - Track the maximum sum encountered while sliding the window.
///     - At the end, divide the max sum by `k` to get the average.
///
/// Time Complexity: O(n) - We process each element once while sliding the window.
/// Space Complexity: O(1) - We use a few integer variables only.
/// </summary>
/// <param name="nums">Input integer array</param>
/// <param name="k">Size of the sliding window</param>
/// <returns>Maximum average value over all subarrays of length k</returns>
public class MaxAverageSubArrayI
{
    public double FindMaxAverage(int[] nums, int k)
    {
        int windowSum = 0;
        for (int i = 0; i < k; i++)
            windowSum += nums[i];

        int maxSum = windowSum;

        for (int i = k; i < nums.Length; i++)
        {
            windowSum += nums[i] - nums[i - k];
            if (windowSum > maxSum)
                maxSum = windowSum;
        }

        return (double)maxSum / k;
    }
}