using Xunit;

namespace Leetcode.Easy.Arrays;

public class TwoSums {
    public int[] TwoSum(int[] numbers, int target) {
        var complements = new Dictionary<int, int>();
        for (int i = 0; i < numbers.Length; i++) {
            int complement = target - numbers[i];
            if (complements.ContainsKey(complement))
                return [complements[complement], i];

            if (!complements.ContainsKey(complement))
                complements[numbers[i]] = i;
        }
        return [];
    }
}

public class TwoSumTests
{
    private readonly TwoSums _solution = new(); 
    [Fact]
    public void Test_Example1() {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        var result = _solution.TwoSum(nums, target);
        Assert.Contains(0, result);
        Assert.Contains(1, result);
    }

    [Fact]
    public void Test_UnsortedArray() {
        int[] nums = { 3, 2, 4 };
        int target = 6;

        var result = _solution.TwoSum(nums, target);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
    }

    [Fact]
    public void Test_WithDuplicates() {
        int[] nums = { 3, 3 };
        int target = 6;

        var result = _solution.TwoSum(nums, target);
        Assert.Contains(0, result);
        Assert.Contains(1, result);
    }

    [Fact]
    public void Test_NegativeNumbers() {
        int[] nums = { -1, -2, -3, -4, -5 };
        int target = -8;

        var result = _solution.TwoSum(nums, target);
        Assert.Contains(2, result);
        Assert.Contains(4, result);
    }

    [Fact]
    public void Test_NoSolution() {
        int[] nums = { 1, 2, 3 };
        int target = 10;

        var result = _solution.TwoSum(nums, target);
        Assert.Empty(result);
    }
}
