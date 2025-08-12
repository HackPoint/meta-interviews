using Leetcode.Easy.DFS;
using Xunit;

namespace Leetcode.Easy.Arrays;

/// <summary>
/// ✅ Returns the minimum POSITIVE subarray sum for any subarray whose length is in [l, r].
/// If no such subarray exists, returns -1.
///
/// 🧠 Approach:
/// Brute-force all subarrays by expanding from each start index i and accumulating the running sum.
/// For each end j, check the current length len = j - i + 1. If len ∈ [l, r] and sum > 0,
/// update the best answer with the minimal positive sum found.
///
/// ⏱ Time Complexity: O(n^2) — two nested loops (start i, end j).
/// 💾 Space Complexity: O(1) — only a few scalars for running sum and best.
///
/// 🔒 Notes:
/// - Uses long for intermediate sums to avoid overflow with large values,
///   casts back to int in the return value.
/// - If you need the minimal sum regardless of sign, remove the (sum > 0) condition.
/// </summary>
public class MinimumPositiveSubArray
{
    public int MinimumSumSubarray(IList<int> nums, int l, int r) {
        int n = nums.Count;
        long minSum = long.MaxValue;
        
        for (int i = 0; i < n; i++)
        {
            long sum = 0;
            for (int j = i; j < n; j++)
            {
                sum += nums[j];
                int length = j - i + 1;

                if (length >= l && length <= r && sum > 0 && sum < minSum)
                {
                    minSum = sum;
                }
            }
        }

        return minSum == long.MaxValue ? -1 : (int)minSum;
    }
}

public class MinimumSumSubarrayTests
{
    [Fact]
    public void Basic_PositiveNumbers_RangeWithinArray()
    {
        // nums: choose lengths in [l=2, r=3]
        var nums = new List<int> { 2, 3, 1, 4 };
        var sol = new MinimumPositiveSubArray();

        // Candidate subarrays with lengths 2..3 and positive sums:
        // [2,3] = 5, [3,1] = 4, [1,4] = 5, [2,3,1] = 6, [3,1,4] = 8
        // Minimum positive among them = 4
        int ans = sol.MinimumSumSubarray(nums, l: 2, r: 3);

        Assert.Equal(4, ans);
    }

    [Fact]
    public void ContainsNegativeNumbers_MinPositiveFound()
    {
        // There are negative values; still we want smallest positive sum with len in [2,3]
        var nums = new List<int> { -5, 4, -1, 2, -2, 3 };
        var sol = new MinimumPositiveSubArray();

        // Consider lengths 2..3:
        // Examples:
        // [4, -1] = 3  (len=2)
        // [-1, 2] = 1  (len=2)  -> candidate minimum positive
        // [2, -2] = 0  (not > 0)
        // [-1, 2, -2] = -1 (not > 0)
        // [2, -2, 3] = 3
        // Minimum positive = 1
        int ans = sol.MinimumSumSubarray(nums, l: 2, r: 3);

        Assert.Equal(1, ans);
    }

    [Fact]
    public void NoPositiveSumInRange_ReturnsMinusOne()
    {
        // All subarray sums in [l=1, r=2] are <= 0, so return -1
        var nums = new List<int> { -3, -2, -1 };
        var sol = new MinimumPositiveSubArray();

        int ans = sol.MinimumSumSubarray(nums, l: 1, r: 2);

        Assert.Equal(-1, ans);
    }

    [Fact]
    public void LengthBounds_ExactLAndRWork()
    {
        var nums = new List<int> { 5, -4, 2, 1, -1, 3 };
        var sol = new MinimumPositiveSubArray();

        // l = r = 2: only length 2 subarrays count
        // [5,-4]=1, [-4,2]=-2 (not >0), [2,1]=3, [1,-1]=0 (not >0), [-1,3]=2
        // min positive of length 2 = 1
        int ansExact = sol.MinimumSumSubarray(nums, l: 2, r: 2);
        Assert.Equal(1, ansExact);

        // l = 1, r = 1: only single elements
        // Positive singles: 5, 2, 1, 3 -> min positive = 1
        int ansSingles = sol.MinimumSumSubarray(nums, l: 1, r: 1);
        Assert.Equal(1, ansSingles);
    }

    [Fact]
    public void LargeValues_UsesLong_NoOverflow()
    {
        var nums = new List<int> { int.MaxValue, -1, 2, -2, 3 };
        var sol = new MinimumPositiveSubArray();

        // lengths in [1,3]
        // Positive candidates include int.MaxValue (len=1)
        // The minimal positive may be smaller if there's a tiny positive sum in length 2..3
        // Check that it doesn't overflow and returns some positive result.
        int ans = sol.MinimumSumSubarray(nums, l: 1, r: 3);

        Assert.True(ans > 0);
    }
}