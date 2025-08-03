using Xunit;

namespace Leetcode.Medium.Bits;

public class BitOrsOfSubArrays
{
    public int SubarrayBitwiseORs(int[] arr)
    {
        HashSet<int> answer = new(), curr = new(), next = new();

        foreach (int x in arr)
        {
            next.Clear();
            next.Add(x);
            foreach (int y in curr)
                next.Add(y | x);

            foreach (int val in next)
                answer.Add(val);
            
            (curr, next) = (next, curr);
        }

        return answer.Count;
    }
}

public class SubarrayBitwiseORsTests
{
    [Fact]
    public void Should_DoA_MinimalCase()
    {
        var s = new BitOrsOfSubArrays();
        int res = s.SubarrayBitwiseORs([0]);
        Assert.Equal(1, res);
    }

    [Fact]
    public void Should_Do_Repeating_Elements()
    {
        var s = new BitOrsOfSubArrays();
        int res = s.SubarrayBitwiseORs([1, 1, 1]);
        Assert.Equal(1, res);
    }

    [Fact]
    public void Should_Do_Rising_OR()
    {
        var s = new BitOrsOfSubArrays();
        int res = s.SubarrayBitwiseORs([1, 2, 4]);
        Assert.Equal(6, res);
    }
}