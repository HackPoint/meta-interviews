using Xunit;

namespace Leetcode.Easy.Bits;

/// <summary>
/// Problem:
/// Given an array `nums` containing `n` distinct numbers taken from the range [0, n],
/// find the only number that is missing from the array.
///
/// Approach:
/// - Use XOR properties:
///     1. a ^ a = 0
///     2. a ^ 0 = a
/// - XOR all values from `0` to `n` and XOR all values in the input array.
/// - The duplicate values cancel each other out, and the only value remaining
///   after all XORs is the missing number.
///
/// Implementation:
/// - Initialize `missing = n` (because loop only covers 0 to n - 1).
/// - Loop through `i = 0` to `n - 1`:
///     missing ^= i ^ nums[i];
/// - At the end, `missing` holds the number that was not seen in `nums`.
///
/// Time Complexity: O(n)
/// - Single pass through the array.
///
/// Space Complexity: O(1)
/// - Constant space, no additional data structures used.
///
/// Example:
/// Input:  [3, 0, 1]
/// Output: 2
///
/// Notes:
/// - This technique leverages the XOR identity to avoid sorting or extra memory.
/// - It is more space-efficient than summation-based approaches and avoids overflow.
/// </summary>
public class MissingNumbers
{
    public int MissingNumber(int[] nums)
    {
        int missing = nums.Length;
        for (int i = 0; i < nums.Length; i++)
        {
            missing ^= i ^ nums[i];
        }

        return missing;
    }
}

public class MissingNumbersTests
{
    private readonly MissingNumbers _solver = new();

    [Fact]
    public void Test_SimpleCase()
    {
        int[] nums = { 3, 0, 1 };
        int result = _solver.MissingNumber(nums);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Test_SingleMissingZero()
    {
        int[] nums = { 1 };
        int result = _solver.MissingNumber(nums);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Test_SingleMissingOne()
    {
        int[] nums = { 0 };
        int result = _solver.MissingNumber(nums);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Test_SequentialMissingMiddle()
    {
        int[] nums = { 0, 1, 2, 4, 5 };
        int result = _solver.MissingNumber(nums);
        Assert.Equal(3, result);
    }

    [Fact]
    public void Test_SequentialMissingFirst()
    {
        int[] nums = { 1, 2, 3, 4 };
        int result = _solver.MissingNumber(nums);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Test_SequentialMissingLast()
    {
        int[] nums = { 0, 1, 2, 3 };
        int result = _solver.MissingNumber(nums);
        Assert.Equal(4, result);
    }

    [Fact]
    public void Test_LargeInput()
    {
        int n = 100000;
        var nums = Enumerable.Range(0, n + 1).ToList();
        nums.RemoveAt(54321); // Remove one number
        int result = _solver.MissingNumber(nums.ToArray());
        Assert.Equal(54321, result);
    }
}