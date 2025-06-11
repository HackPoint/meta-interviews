using Leetcode.Design.Hard.Hashmap;

namespace Leetcode.Design.Hard.Tests;

using Xunit;

public class AllOneTests
{
    [Fact]
    public void NewKey_IncOnce_ShouldReturnAsMinAndMax()
    {
        var ds = new AllOne();

        ds.Inc("apple");

        Assert.Equal("apple", ds.GetMinKey());
        Assert.Equal("apple", ds.GetMaxKey());
    }

    [Fact]
    public void MultipleKeys_WithDifferentCounts_ShouldReturnCorrectMinMax()
    {
        var ds = new AllOne();

        ds.Inc("a");     // a:1
        ds.Inc("b");     // b:1
        ds.Inc("b");     // b:2
        ds.Inc("c");     // c:1
        ds.Inc("c");     // c:2
        ds.Inc("c");     // c:3

        Assert.Equal("a", ds.GetMinKey()); // count = 1
        Assert.Equal("c", ds.GetMaxKey()); // count = 3
    }

    [Fact]
    public void DecrementToZero_RemovesKey()
    {
        var ds = new AllOne();

        ds.Inc("a");
        ds.Dec("a");

        Assert.Equal("", ds.GetMinKey());
        Assert.Equal("", ds.GetMaxKey());
    }

    [Fact]
    public void IncrementAndDecrement_StabilizesState()
    {
        var ds = new AllOne();

        ds.Inc("x");     // x:1
        ds.Inc("x");     // x:2
        ds.Inc("y");     // y:1
        ds.Dec("x");     // x:1

        var min = ds.GetMinKey();
        var max = ds.GetMaxKey();

        // both keys should have the same count
        Assert.Contains(min, new[] { "x", "y" });
        Assert.Contains(max, new[] { "x", "y" });
    }

    [Fact]
    public void EmptyStructure_ReturnsEmptyStrings()
    {
        var ds = new AllOne();

        Assert.Equal("", ds.GetMaxKey());
        Assert.Equal("", ds.GetMinKey());

        ds.Inc("test");
        ds.Dec("test");

        Assert.Equal("", ds.GetMaxKey());
        Assert.Equal("", ds.GetMinKey());
    }

    [Fact]
    public void IncMultipleThenDecToBalance()
    {
        var ds = new AllOne();

        ds.Inc("a"); // 1
        ds.Inc("a"); // 2
        ds.Inc("b"); // 1
        ds.Inc("b"); // 2
        ds.Dec("a"); // 1

        Assert.Equal("a", ds.GetMinKey()); // a:1, b:2
        Assert.Equal("b", ds.GetMaxKey());
    }
}
