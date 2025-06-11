using Leetcode.Design.Easy;
using Xunit;

namespace Leetcode.Design.Tests;

public class MyCircularQueueTests
{
    [Fact]
    public void EnQueueAndDeQueue_SingleElement_ShouldWork()
    {
        var q = new MyCircularQueue(3);
        Assert.True(q.EnQueue(10));
        Assert.Equal(10, q.Front());
        Assert.Equal(10, q.Rear());
        Assert.True(q.DeQueue());
        Assert.True(q.IsEmpty());
    }

    [Fact]
    public void EnQueue_FillToCapacity_ShouldReportFull()
    {
        var q = new MyCircularQueue(2);
        Assert.True(q.EnQueue(1));
        Assert.True(q.EnQueue(2));
        Assert.False(q.EnQueue(3)); // full
        Assert.True(q.IsFull());
    }

    [Fact]
    public void DeQueue_EmptyQueue_ShouldReturnFalse()
    {
        var q = new MyCircularQueue(2);
        Assert.False(q.DeQueue());
    }

    [Fact]
    public void EnQueueDeQueue_MultipleWrapAround_ShouldBehaveCorrectly()
    {
        var q = new MyCircularQueue(3);
        Assert.True(q.EnQueue(1));
        Assert.True(q.EnQueue(2));
        Assert.True(q.EnQueue(3));
        Assert.True(q.DeQueue());  // remove 1
        Assert.True(q.EnQueue(4)); // wrap around
        Assert.Equal(2, q.Front());
        Assert.Equal(4, q.Rear());
    }

    [Fact]
    public void FrontAndRear_WhenEmpty_ShouldReturnMinusOne()
    {
        var q = new MyCircularQueue(2);
        Assert.Equal(-1, q.Front());
        Assert.Equal(-1, q.Rear());
    }

    [Fact]
    public void IsEmptyAndIsFull_BoundaryChecks_ShouldWork()
    {
        var q = new MyCircularQueue(1);
        Assert.True(q.IsEmpty());
        Assert.True(q.EnQueue(5));
        Assert.True(q.IsFull());
        Assert.True(q.DeQueue());
        Assert.True(q.IsEmpty());
    }

    [Fact]
    public void EnQueueAfterDeQueue_WrapsAroundCorrectly()
    {
        var q = new MyCircularQueue(3);
        Assert.True(q.EnQueue(1));
        Assert.True(q.EnQueue(2));
        Assert.True(q.EnQueue(3));
        Assert.True(q.DeQueue());      // remove 1
        Assert.True(q.EnQueue(4));     // wrap around
        Assert.Equal(2, q.Front());
        Assert.Equal(4, q.Rear());
    }
}
