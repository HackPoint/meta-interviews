namespace Leetcode.Easy.LinkedList.TwoPointer.LinkedLists;

public class RemoveNthNodeFromEndOfList
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var dummy = new ListNode(0, head); // protect of head pointer deletion
        var fast = dummy;
        var slow = dummy;

        // move N times of fast node to point to the Node we need to remove
        for (int i = 0; i < n; i++)
            fast = fast.next;

        // synchronously move two pointers so fast will pont to start of the list and slow will be at 
        // need to remove node.
        while (fast.next != null)
        {
            fast = fast.next;
            slow = slow.next;
        }
        
        // remove the slow pointer
        slow.next = slow.next.next;
        return dummy.next;
    }
}