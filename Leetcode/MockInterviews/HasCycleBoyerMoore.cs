using Leetcode.Easy.LinkedList.TwoPointer.LinkedLists;

namespace Leetcode.MockInterviews;

public class HasCycleBoyerMoore
{
    public bool HasCycle(ListNode head) {
        if(head == null || head.next == null) return false;
        var slow = head;
        var fast = head.next;
        while(fast != null && fast.next != null) {
            if(slow == fast) return true;
            
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return false;
    }
}