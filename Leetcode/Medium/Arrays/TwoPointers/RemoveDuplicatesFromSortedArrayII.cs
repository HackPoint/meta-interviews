using Xunit;

namespace Leetcode.Medium.Arrays.TwoPointers;

/// <summary>
/// Removes duplicates from a sorted array such that each unique element appears at most twice.
/// Modifies the input array in-place using two pointers: a read and a write pointer.
/// 
/// Approach:
/// - We keep the first two occurrences of each element.
/// - Start write pointer at index 2.
/// - Traverse the array from index 2.
/// - If the current number is not equal to the number at write - 2, we copy it and increment write.
/// 
/// Time Complexity: O(n) — one pass through the array
/// Space Complexity: O(1) — in-place modification
/// 
/// Example:
/// Input:  [1, 1, 1, 2, 2, 3]
/// Output: [1, 1, 2, 2, 3] with return value 5
/// </summary>
public class RemoveDuplicatesFromSortedArrayII
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 2) return nums.Length;

        int write = 2;

        for (int read = 2; read < nums.Length; read++)
        {
            // Only write if the current element is different from the element two places back
            if (nums[read] != nums[write - 2])
            {
                nums[write] = nums[read];
                write++;
            }
        }

        return write;
    }
}

public class RemoveDuplicatesFromSortedArrayIITests
{
    private readonly RemoveDuplicatesFromSortedArrayII solution = new();

    [Fact]
    public void EmptyArray_ReturnsZero()
    {
        int[] nums = new int[] { };
        int k = solution.RemoveDuplicates(nums);
        Assert.Equal(0, k);
    }

    [Fact]
    public void SingleElement_ReturnsOne()
    {
        int[] nums = new int[] { 1 };
        int k = solution.RemoveDuplicates(nums);
        Assert.Equal(1, k);
        Assert.Equal(new[] { 1 }, nums.Take(k));
    }

    [Fact]
    public void TwoDifferentElements_ReturnsTwo()
    {
        int[] nums = new int[] { 1, 2 };
        int k = solution.RemoveDuplicates(nums);
        Assert.Equal(2, k);
        Assert.Equal(new[] { 1, 2 }, nums.Take(k));
    }

    [Fact]
    public void TwoSameElements_ReturnsTwo()
    {
        int[] nums = new int[] { 2, 2 };
        int k = solution.RemoveDuplicates(nums);
        Assert.Equal(2, k);
        Assert.Equal(new[] { 2, 2 }, nums.Take(k));
    }

    [Fact]
    public void MoreThanTwoDuplicates_ReturnsTwo()
    {
        int[] nums = new int[] { 1, 1, 1, 1 };
        int k = solution.RemoveDuplicates(nums);
        Assert.Equal(2, k);
        Assert.Equal(new[] { 1, 1 }, nums.Take(k));
    }

    [Fact]
    public void MixedDuplicates()
    {
        int[] nums = new int[] { 1, 1, 1, 2, 2, 3 };
        int k = solution.RemoveDuplicates(nums);
        Assert.Equal(5, k);
        Assert.Equal(new[] { 1, 1, 2, 2, 3 }, nums.Take(k));
    }

    [Fact]
    public void NoDuplicates()
    {
        int[] nums = new int[] { 1, 2, 3, 4, 5 };
        int k = solution.RemoveDuplicates(nums);
        Assert.Equal(5, k);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, nums.Take(k));
    }

    [Fact]
    public void AllElementsOccurTwice()
    {
        int[] nums = new int[] { 1, 1, 2, 2, 3, 3 };
        int k = solution.RemoveDuplicates(nums);
        Assert.Equal(6, k);
        Assert.Equal(new[] { 1, 1, 2, 2, 3, 3 }, nums.Take(k));
    }

    [Fact]
    public void ComplexCase()
    {
        int[] nums = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
        int k = solution.RemoveDuplicates(nums);
        Assert.Equal(7, k);
        Assert.Equal(new[] { 0, 0, 1, 1, 2, 3, 3 }, nums.Take(k));
    }
}
