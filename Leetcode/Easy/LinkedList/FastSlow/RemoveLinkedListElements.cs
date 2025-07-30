using Leetcode.Easy.DFS;
using Leetcode.Easy.LinkedList.TwoPointer.LinkedLists;
using Xunit;

namespace Leetcode.Easy.LinkedList.FastSlow;

/// <summary>
/// Removes all nodes from the singly linked list that have a specific target value.
/// 
/// The algorithm uses a dummy (sentinel) node to simplify edge cases like deleting the head.
/// It traverses the list with a pointer and removes nodes in-place by skipping them when their value equals the target.
/// 
/// Time Complexity:    O(n) — each node is visited once
/// Space Complexity:   O(1) — in-place operation, no extra memory
/// 
/// Edge cases handled:
/// - Deleting head node(s)
/// - Empty list (head == null)
/// - Multiple consecutive deletions
/// </summary>
/// <param name="head">The head of the singly linked list</param>
/// <param name="val">The integer value to remove from the list</param>
/// <returns>The head of the modified linked list</returns>
public class RemoveLinkedListElements
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        var dummy = new ListNode(0);
        dummy.next = head;
        var curr = dummy;

        while (curr.next != null) {
            if (curr.next.val == val) {
                curr.next = curr.next.next;
            } else {
                curr = curr.next;
            }
        }

        return dummy.next;
    }
}


public class RemoveElementsTests {

    [Fact]
    public void RemoveElements_AllMatching_RemovesAll() {
        var input = CreateList(new[] { 7, 7, 7, 7 });
        var expected = CreateList(new int[] { });

        var result = new RemoveLinkedListElements().RemoveElements(input, 7);

        Assert.True(AreEqual(expected, result));
    }

    [Fact]
    public void RemoveElements_HeadMatch_RemovesFromHead() {
        var input = CreateList(new[] { 6, 1, 2, 3 });
        var expected = CreateList(new[] { 1, 2, 3 });

        var result = new RemoveLinkedListElements().RemoveElements(input, 6);

        Assert.True(AreEqual(expected, result));
    }

    [Fact]
    public void RemoveElements_MiddleMatch_RemovesOnlyMatching() {
        var input = CreateList([1, 2, 6, 3, 4, 5, 6]);
        var expected = CreateList([1, 2, 3, 4, 5]);

        var result = new RemoveLinkedListElements().RemoveElements(input, 6);

        Assert.True(AreEqual(expected, result));
    }

    [Fact]
    public void RemoveElements_EmptyInput_ReturnsNull() {
        var result = new RemoveLinkedListElements().RemoveElements(null, 1);
        Assert.Null(result);
    }

    // Utility: Create list from array
    private ListNode CreateList(int[] values) {
        var dummy = new ListNode(0);
        var curr = dummy;
        foreach (var val in values) {
            curr.next = new ListNode(val);
            curr = curr.next;
        }
        return dummy.next;
    }

    // Utility: Compare two linked lists
    private bool AreEqual(ListNode a, ListNode b) {
        while (a != null && b != null) {
            if (a.val != b.val) return false;
            a = a.next;
            b = b.next;
        }
        return a == null && b == null;
    }
}
