using Leetcode.Design.Medium.Stack.MinStack;
using Xunit;

namespace Leetcode.Design.Tests;

public class MinStackTests
{
    [Fact]
    public void Push_Then_GetMin_ReturnsCorrect()
    {
        var stack = new MinStack();
        stack.Push(5);
        Assert.Equal(5, stack.GetMin());
    }

    [Fact]
    public void PushMultiple_GetMinTracksMinimum()
    {
        var stack = new MinStack();
        stack.Push(5);
        stack.Push(3);
        stack.Push(7);
        Assert.Equal(3, stack.GetMin());
    }

    [Fact]
    public void Pop_AfterPushingLowerMin_UpdatesMinCorrectly()
    {
        var stack = new MinStack();
        stack.Push(5);
        stack.Push(3);
        stack.Pop();
        Assert.Equal(5, stack.GetMin());
    }

    [Fact]
    public void Top_ReturnsCorrectValue()
    {
        var stack = new MinStack();
        stack.Push(1);
        stack.Push(2);
        Assert.Equal(2, stack.Top());
    }

    [Fact]
    public void PushSameValues_MinStaysCorrectAfterPop()
    {
        var stack = new MinStack();
        stack.Push(2);
        stack.Push(2);
        stack.Pop();
        Assert.Equal(2, stack.GetMin());
    }

    [Fact]
    public void PushNegativeValues_MinTracksNegative()
    {
        var stack = new MinStack();
        stack.Push(-1);
        stack.Push(-2);
        Assert.Equal(-2, stack.GetMin());
    }

    [Fact]
    public void PopAll_ThenGetMin_Throws()
    {
        var stack = new MinStack();
        stack.Push(1);
        stack.Pop();
        Assert.Throws<InvalidOperationException>(() => stack.GetMin());
    }

    [Fact]
    public void TopOnEmpty_Throws()
    {
        var stack = new MinStack();
        Assert.Throws<InvalidOperationException>(() => stack.Top());
    }

    [Fact]
    public void GetMinOnEmpty_Throws()
    {
        var stack = new MinStack();
        Assert.Throws<InvalidOperationException>(() => stack.GetMin());
    }

    [Fact]
    public void ComplexSequence_StillCorrect()
    {
        var stack = new MinStack();
        stack.Push(3);
        stack.Push(2);
        stack.Push(1);
        Assert.Equal(1, stack.GetMin());
        stack.Pop();
        Assert.Equal(2, stack.GetMin());
        stack.Pop();
        Assert.Equal(3, stack.GetMin());
    }
}