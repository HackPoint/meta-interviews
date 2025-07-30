using Leetcode.Easy.LinkedList.TwoPointer.LinkedLists;

namespace Leetcode.Easy.LinkedList.FastSlow;

public class MiddleOfLinkedList
{
    public ListNode MiddleNode(ListNode head) {
        ListNode slow = head;
        ListNode fast = head?.next;

        while(fast != null) {
            slow = slow?.next;
            fast = fast?.next?.next;
        }
        return slow;
    }
}