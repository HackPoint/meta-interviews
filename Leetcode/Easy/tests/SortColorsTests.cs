using Leetcode.Easy.Arrays.TwoPointers;
using Xunit;

namespace Leetcode.Easy.tests;

public class SortColorsTests
{
    [Fact]
    public void Should_SortInPlace_DutchFlagAlgorithm()
    {
        var sortColors = new SortColorss();
        int[] output = [2, 0, 2, 1, 1, 0];
        sortColors.SortColors(output);
        var sorted = output.Clone() as int[];
        Array.Sort(sorted);
        Assert.Equal(output, sorted);
    }
}