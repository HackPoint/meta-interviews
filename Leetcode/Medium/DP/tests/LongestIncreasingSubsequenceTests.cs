using Xunit;

namespace Leetcode.Medium.DP.tests;
using Xunit;

public class LongestIncreasingSubsequenceTests

{
    [Fact]
    public void EmptyArray_ReturnsZero()
    {
        var lis = new LongestIncreasingSubsequence();
        var input = new int[] { };
        int result = lis.LengthOfLIS(input);
        Assert.Equal(0, result);
    }

    [Fact]
    public void LeetCode_CrashedTest()
    {
        var lis = new LongestIncreasingSubsequence();
        var input = new[] { 10, 9, 2, 5, 3, 7, 101, 18 };
        int result = lis.LengthOfLIS(input);
        Assert.Equal(4, result);
    }

    [Fact]
    public void SingleElement_ReturnsOne()
    {
        var lis = new LongestIncreasingSubsequence();
        var input = new[] { 5 };
        int result = lis.LengthOfLIS(input);
        Assert.Equal(1, result);
    }

    [Fact]
    public void AllIncreasing_ReturnsLength()
    {
        var lis = new LongestIncreasingSubsequence();
        var input = new int[] { 1, 2, 3, 4, 5 };
        int result = lis.LengthOfLIS(input);
        Assert.Equal(5, result);
    }

    [Fact]
    public void AllDecreasing_ReturnsOne()
    {
        var lis = new LongestIncreasingSubsequence();
        var input = new int[] { 5, 4, 3, 2, 1 };
        int result = lis.LengthOfLIS(input);
        Assert.Equal(1, result);
    }

    [Fact]
    public void RandomMix_ReturnsCorrectLIS()
    {
        var lis = new LongestIncreasingSubsequence();
        var input = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
        int result = lis.LengthOfLIS(input);
        Assert.Equal(4, result); // [2,3,7,101]
    }

    [Fact]
    public void DuplicatesInInput()
    {
        var lis = new LongestIncreasingSubsequence();
        var input = new[] { 1, 3, 5, 4, 7, 7, 8 };
        int result = lis.LengthOfLIS(input);
        Assert.Equal(5, result); // [1, 3, 4, 7, 8]
    }

    [Fact]
    public void StressTest_ManyElements()
    {
        var lis = new LongestIncreasingSubsequence();
        var input = Enumerable.Range(1, 1000).ToArray(); // strictly increasing
        int result = lis.LengthOfLIS(input);
        Assert.Equal(1000, result);
    }
}