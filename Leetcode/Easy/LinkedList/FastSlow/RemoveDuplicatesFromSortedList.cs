using Leetcode.Easy.DFS;
using Leetcode.Easy.LinkedList.TwoPointer.LinkedLists;
using Xunit;

namespace Leetcode.Easy.LinkedList.FastSlow;

/// <summary>
/// Removes duplicates from a sorted singly linked list.
/// Since the list is sorted, any duplicates will appear consecutively.
/// This function traverses the list once, comparing each node to its next,
/// and removes duplicate nodes by rewiring the pointers.
///
/// Time Complexity: O(n), where n is the number of nodes in the list.
/// Space Complexity: O(1) — done in-place without additional data structures.
///
/// Edge Cases:
/// • An empty list returns null.
/// • A list with one element returns as-is.
/// • Duplicates are removed in-place.
///
/// Example:
/// Input: 1 → 1 → 2 → 3 → 3
/// Output: 1 → 2 → 3
/// </summary>
public class RemoveDuplicatesFromSortedList
{
    public ListNode DeleteDuplicates(ListNode head) {
        var curr = head;

        while(curr != null && curr.next != null) {
            if(curr.val == curr.next.val) {
                curr.next = curr.next.next;
            } else {
                curr = curr.next;
            }
        }

        return head;
    }
}

public class DeleteDuplicatesTests {
    
    [Fact]
    public void DeletesDuplicatesInSortedList() {
        var input = BuildList(new[] { 1, 1, 2, 3, 3 });
        var expected = new[] { 1, 2, 3 };
        
        var result = new RemoveDuplicatesFromSortedList().DeleteDuplicates(input);
        Assert.Equal(expected, ToArray(result));
    }

    [Fact]
    public void HandlesEmptyList() {
        var result = new RemoveDuplicatesFromSortedList().DeleteDuplicates(null);
        Assert.Null(result);
    }

    [Fact]
    public void HandlesSingleElementList() {
        var input = BuildList(new[] { 5 });
        var result = new RemoveDuplicatesFromSortedList().DeleteDuplicates(input);
        Assert.Equal(new[] { 5 }, ToArray(result));
    }

    [Fact]
    public void NoDuplicates() {
        var input = BuildList(new[] { 1, 2, 3 });
        var result = new RemoveDuplicatesFromSortedList().DeleteDuplicates(input);
        Assert.Equal(new[] { 1, 2, 3 }, ToArray(result));
    }

    [Fact]
    public void AllDuplicates() {
        var input = BuildList(new[] { 7, 7, 7, 7 });
        var result = new RemoveDuplicatesFromSortedList().DeleteDuplicates(input);
        Assert.Equal(new[] { 7 }, ToArray(result));
    }

    // Helper methods
    private ListNode BuildList(int[] values) {
        var dummy = new ListNode(0);
        var curr = dummy;
        foreach (var v in values) {
            curr.next = new ListNode(v);
            curr = curr.next;
        }
        return dummy.next;
    }

    private int[] ToArray(ListNode head) {
        var result = new List<int>();
        while (head != null) {
            result.Add(head.val);
            head = head.next;
        }
        return result.ToArray();
    }
}