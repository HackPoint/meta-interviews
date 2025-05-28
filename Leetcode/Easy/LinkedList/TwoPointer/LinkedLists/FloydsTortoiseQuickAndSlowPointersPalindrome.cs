namespace Leetcode.Easy.LinkedList.TwoPointer.LinkedLists;

public class FloydsTortoiseQuickAndSlowPointersPalindrome
{
    public bool IsPalindrome(ListNode head)
    {
        if (head is null || head.next is null) return true;

        var slow = head;
        var fast = head;

        while (fast is not null && fast.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        // reverse second half
        var secondHalf = Reverse(slow);
        var firstHalf = head;

        while (secondHalf is not null) 
        {
            if (firstHalf.val != secondHalf.val)
            {
                return false;
            }

            firstHalf = firstHalf.next;
            secondHalf = secondHalf.next;
        }

        return true;
    }

    private ListNode Reverse(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;

        while (curr is not null)
        {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}