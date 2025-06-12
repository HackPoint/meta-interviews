using Leetcode.Design.Easy.Hashmap;
using Xunit;

namespace Leetcode.Design.Easy.Tests;

public class HashMapTests
{
    [Fact]
    public void Put_ThenGet_ReturnsCorrectValue()
    {
        var map = new MyHashMap();
        map.Put(1, 10);
        map.Put(2, 20);
        Assert.Equal(10, map.Get(1));
        Assert.Equal(20, map.Get(2));
    }

    [Fact]
    public void Put_ExistingKey_UpdatesValue()
    {
        var map = new MyHashMap();
        map.Put(1, 10);
        map.Put(1, 99);
        Assert.Equal(99, map.Get(1));
    }

    [Fact]
    public void Get_NonExistentKey_ReturnsMinusOne()
    {
        var map = new MyHashMap();
        Assert.Equal(-1, map.Get(123)); // key was never added
    }

    [Fact]
    public void Remove_ExistingKey_RemovesValue()
    {
        var map = new MyHashMap();
        map.Put(1, 10);
        map.Remove(1);
        Assert.Equal(-1, map.Get(1));
    }

    [Fact]
    public void Remove_NonExistentKey_DoesNothing()
    {
        var map = new MyHashMap();
        map.Remove(42); // should not throw
        Assert.Equal(-1, map.Get(42));
    }

    [Fact]
    public void StressTest_InsertMany_StillCorrect()
    {
        var map = new MyHashMap();

        for (int i = 0; i < 1000; i++)
            map.Put(i, i * 10);

        for (int i = 0; i < 1000; i++)
            Assert.Equal(i * 10, map.Get(i));
    }

    [Fact]
    public void RepeatedRemoveAndGet_WorksCorrectly()
    {
        var map = new MyHashMap();
        map.Put(5, 500);
        Assert.Equal(500, map.Get(5));
        map.Remove(5);
        Assert.Equal(-1, map.Get(5));
        map.Put(5, 999);
        Assert.Equal(999, map.Get(5));
    }
}