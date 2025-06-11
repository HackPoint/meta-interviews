using Leetcode.Design.Easy;
using Leetcode.Design.Medium.Hashmap;
using Xunit;

namespace Leetcode.Design.Tests;

public class DynamicArrayO1Tests
{
    [Fact]
    public void Get_WithoutSet_ReturnsGlobalDefault()
    {
        var array = new DynamicArrayO1();
        Assert.Equal(0, array.Get(0)); // default _globalValue
    }

    [Fact]
    public void SetAndGet_IndexValue_ReturnsCorrectValue()
    {
        var array = new DynamicArrayO1();
        array.Set(1, 100);
        Assert.Equal(100, array.Get(1));
        Assert.Equal(0, array.Get(0)); // not set
    }


    [Fact]
    public void SetAll_OverridesUnsetIndexes()
    {
        var array = new DynamicArrayO1();
        array.Set(1, 100);
        array.SetAll(999);

        Assert.Equal(999, array.Get(0)); // not set directly
        Assert.Equal(999, array.Get(1)); // version of Set(1) < SetAll
    }
    
    [Fact]
    public void SetAfterSetAll_WinsOverGlobal()
    {
        var array = new DynamicArrayO1();
        array.SetAll(42);
        array.Set(2, 77);

        Assert.Equal(77, array.Get(2));
        Assert.Equal(42, array.Get(1));
    }

    [Fact]
    public void MultipleSetAlls_CorrectlyAffectOldValues()
    {
        var array = new DynamicArrayO1();
        array.Set(0, 5);
        array.SetAll(10);
        array.SetAll(20);

        Assert.Equal(20, array.Get(0));
        Assert.Equal(20, array.Get(99)); // random unset index
    }
    
    [Fact]
    public void SetThenSetAllThenSetAgain_UsesLatestValue()
    {
        var array = new DynamicArrayO1();
        array.Set(1, 111);
        array.SetAll(222);
        array.Set(1, 333);

        Assert.Equal(333, array.Get(1));
    }
}