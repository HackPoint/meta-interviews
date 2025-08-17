using Xunit;

namespace Leetcode.Design.Easy.Stack;

/// <summary>
/// 225. Implement Stack using Queues
/// Simple implementation of a stack using a single List<int> to simulate a queue.
/// Push is O(n) due to rotation; Pop/Top/Empty are O(1).
/// Idea: Push to the end, then rotate previous elements to the back so the new one is at the front.
/// </summary>
public class MyStack
{
    private readonly List<int> _q = new();

    /// <summary>
    /// Push element x onto stack.
    /// </summary>
    public void Push(int x)
    {
        _q.Add(x);
        for (int i = 0; i < _q.Count - 1; i++)
        {
            _q.Add(_q[0]);
            _q.RemoveAt(0);
        }
    }

    /// <summary>
    /// Removes the element on top of the stack and returns it.
    /// </summary>
    public int Pop()
    {
        int val = _q[0];
        _q.RemoveAt(0);
        return val;
    }

    /// <summary>
    /// Get the top element.
    /// </summary>
    public int Top() => _q[0];

    /// <summary>
    /// Returns whether the stack is empty.
    /// </summary>
    public bool Empty() => _q.Count == 0;
}



public class MyStackTests
{
    [Fact]
    public void PushAndTop_ShouldReturnLastPushed()
    {
        var st = new MyStack();
        st.Push(1);
        st.Push(2);
        Assert.Equal(2, st.Top());
    }

    [Fact]
    public void Pop_ShouldReturnLastPushed()
    {
        var st = new MyStack();
        st.Push(1);
        st.Push(2);
        Assert.Equal(2, st.Pop());
        Assert.Equal(1, st.Top());
    }

    [Fact]
    public void Empty_ShouldReturnTrueWhenNoElements()
    {
        var st = new MyStack();
        Assert.True(st.Empty());
    }

    [Fact]
    public void Empty_ShouldReturnFalseWhenElementsExist()
    {
        var st = new MyStack();
        st.Push(5);
        Assert.False(st.Empty());
    }

    [Fact]
    public void PushPopMultiple_ShouldMaintainLifo()
    {
        var st = new MyStack();
        st.Push(1);
        st.Push(2);
        st.Push(3);
        Assert.Equal(3, st.Pop());
        Assert.Equal(2, st.Pop());
        Assert.Equal(1, st.Pop());
        Assert.True(st.Empty());
    }
}
