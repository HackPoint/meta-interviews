using Xunit;

namespace Leetcode.MockInterviews;

public interface INestedInteger {
    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    IList<INestedInteger> GetList();
}

/// <summary>
/// This namespace contains mock interview practice problems from LeetCode
/// Problem 341: Flatten Nested List Iterator
/// 
/// Problem Description:
/// You are given a nested list of integers nestedList. Each element is either an integer
/// or a list whose elements may also be integers or other lists. Implement an iterator to
/// flatten it.
/// Time Complexity: 
/// - Constructor: O(n) where n is the total number of elements
/// - Next(): O(1) amortized
/// - HasNext(): O(1) amortized
/// 
/// Space Complexity:
/// - O(d) where d is the maximum depth of nesting
/// <remarks>
/// The iterator maintains a stack of enumerators to track the current position in the nested structure.
/// It uses lazy evaluation to prepare the next integer only when needed.
/// 
/// Example:
/// Input: [[1,1],2,[1,1]]
/// Output: [1,1,2,1,1]
/// 
/// The class implements a depth-first traversal approach where:
/// - _stack: Tracks the current path in the nested structure
/// - _next: Buffers the next integer to be returned
/// </remarks>
/// </summary>
public class NestedIterator {
    private readonly Stack<IEnumerator<INestedInteger>> _stack = new();
    private int? _next;

    public NestedIterator(IList<INestedInteger> nestedList) {
        _stack.Push(nestedList.GetEnumerator());
    }

    public bool HasNext() {
        if (_next.HasValue) return true; // already prepared.

        while (_stack.Count > 0) {
            var top = _stack.Peek();

            if (!top.MoveNext()) {
                _stack.Pop();
                continue;
            }

            var cur = top.Current;
            if (cur.IsInteger()) {
                // find: buffer it and return
                _next = cur.GetInteger();
                return true;
            }

            _stack.Push(cur.GetList().GetEnumerator());
        }

        return false;
    }

    public int Next() {
        // Guarantee: if there's an integer, HasNext() must have prepared _next.
        if (!HasNext()) {
            throw new InvalidOperationException("No more elements.");
        }

        int result = _next!.Value;
        _next = null;
        return result;
    }
}

public class NestedIteratorTests {
    private class TestNestedInteger : INestedInteger {
        private readonly int? _value;
        private readonly IList<INestedInteger> _list;

        public TestNestedInteger(int value) {
            _value = value;
            _list = null;
        }

        public TestNestedInteger(IList<INestedInteger> list) {
            _value = null;
            _list = list;
        }

        public bool IsInteger() => _value.HasValue;
        public int GetInteger() => _value ?? 0;
        public IList<INestedInteger> GetList() => _list;
    }

    [Fact]
    public void EmptyList_HasNoNext() {
        var iterator = new NestedIterator(new List<INestedInteger>());
        Assert.False(iterator.HasNext());
    }

    [Fact]
    public void FlatList_ReturnsElementsInOrder() {
        var list = new List<INestedInteger> {
            new TestNestedInteger(1),
            new TestNestedInteger(2),
            new TestNestedInteger(3)
        };
        var iterator = new NestedIterator(list);

        Assert.True(iterator.HasNext());
        Assert.Equal(1, iterator.Next());
        Assert.Equal(2, iterator.Next());
        Assert.Equal(3, iterator.Next());
        Assert.False(iterator.HasNext());
    }

    [Fact]
    public void NestedList_FlattensCorrectly() {
        var innerList = new List<INestedInteger> {
            new TestNestedInteger(2),
            new TestNestedInteger(3)
        };
        var list = new List<INestedInteger> {
            new TestNestedInteger(1),
            new TestNestedInteger(innerList),
            new TestNestedInteger(4)
        };
        var iterator = new NestedIterator(list);

        Assert.Equal(1, iterator.Next());
        Assert.Equal(2, iterator.Next());
        Assert.Equal(3, iterator.Next());
        Assert.Equal(4, iterator.Next());
        Assert.False(iterator.HasNext());
    }

    [Fact]
    public void Next_ThrowsWhenNoMoreElements() {
        var iterator = new NestedIterator(new List<INestedInteger>());
        Assert.Throws<InvalidOperationException>(() => iterator.Next());
    }
}