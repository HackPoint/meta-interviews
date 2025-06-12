using Leetcode.Design.Medium.Stack.StackWithIncrementOps;
using Xunit;

namespace Leetcode.Design.Tests;

public class CustomIncrementStackTests
{
    [Fact]
    public void Push_WithinCapacity_AddsElement()
    {
        var stack = new CustomStack(3);
        stack.Push(1);
        stack.Push(2);

        Assert.Equal(2, stack.Pop());
    }

    [Fact]
    public void Push_ExceedingCapacity_Ignored()
    {
        var stack = new CustomStack(1);
        stack.Push(1);
        stack.Push(2);

        Assert.Equal(1, stack.Pop());
    }

    [Fact]
    public void Pop_OnEmptyStack_ReturnsMinusOne()
    {
        var stack = new CustomStack(1);
        Assert.Equal(-1, stack.Pop());
    }

    [Fact]
    public void Increment_PartialStackOnly()
    {
        var stack = new CustomStack(5);
        stack.Push(1);
        stack.Push(2);
        stack.Increment(1, 100);

        Assert.Equal(2, stack.Pop()); // Not incremented
        Assert.Equal(101, stack.Pop()); // Incremented
    }

    [Fact]
    public void Increment_AllStack()
    {
        var stack = new CustomStack(2);
        stack.Push(1);
        stack.Push(2);
        stack.Increment(2, 10);

        Assert.Equal(12, stack.Pop());
        Assert.Equal(11, stack.Pop());
    }

    [Fact]
    public void Increment_ExceedingSize_StillWorks()
    {
        var stack = new CustomStack(2);
        stack.Push(1);
        stack.Push(2);
        stack.Increment(5, 10); // should increment all

        Assert.Equal(12, stack.Pop());
        Assert.Equal(11, stack.Pop());
    }
}