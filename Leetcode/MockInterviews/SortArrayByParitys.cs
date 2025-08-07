using Xunit;

namespace Leetcode.MockInterviews;

/// <summary>
/// Problem:
///     Given an integer array `nums`, move all even integers to the beginning of the array,
///     followed by all the odd integers. The order of elements within even/odd groups doesn't matter.
///
/// Approach:
///     Uses the **two-pointer technique**:
///     - `left` starts at the beginning, `right` at the end.
///     - If `nums[left]` is even, move `left` forward.
///     - If `nums[right]` is even and `nums[left]` is odd, swap them.
///     - If `nums[right]` is odd, move `right` backward.
///
/// Time Complexity:
///     • O(n) — Each element is visited at most once
///
/// Space Complexity:
///     • O(1) — In-place array modification
///
/// Example:
///     Input: [3, 1, 2, 4]
///     Output: [4, 2, 1, 3] (or any other valid arrangement like [2,4,3,1])
/// </summary>
public class SortArrayByParitys
{
    public int[] SortArrayByParity(int[] nums) {
        int left = 0, right = nums.Length - 1;
        
        while(left <= right) {
            if(nums[left] % 2 == 0) {              
                left++;
            } else if(nums[right] % 2 == 0) {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            } else {
                right--;
            }
        }
        
        return nums;
    }
}

public class SortArrayByParityTests
{
    [Theory]
    [InlineData(new int[] { 3, 1, 2, 4 }, 2)]  // Two evens
    [InlineData(new int[] { 0 }, 1)]          // One element
    [InlineData(new int[] { 2, 4, 6 }, 3)]    // All even
    [InlineData(new int[] { 1, 3, 5 }, 0)]    // All odd
    [InlineData(new int[] { 2, 1 }, 1)]       // Mixed
    public void SortArrayByParity_ShouldPlaceEvenFirst(int[] input, int expectedEvenCount)
    {
        var solution = new SortArrayByParitys();
        var result = solution.SortArrayByParity((int[])input.Clone());

        // All evens should be at the beginning
        int evenCount = 0;
        foreach (int num in result)
        {
            if (num % 2 == 0)
                evenCount++;
            else
                break; // All evens should come before first odd
        }

        Assert.Equal(expectedEvenCount, evenCount);
    }

    [Fact]
    public void SortArrayByParity_ShouldHandleEmptyArray()
    {
        var solution = new SortArrayByParitys();
        var result = solution.SortArrayByParity(new int[] { });
        Assert.Empty(result);
    }
}