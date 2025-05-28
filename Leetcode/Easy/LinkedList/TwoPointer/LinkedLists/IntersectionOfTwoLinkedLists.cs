namespace Leetcode.Easy.LinkedList.TwoPointer.LinkedLists;

public class IntersectionOfTwoLinkedLists
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA is null || headB is null)
            return null;

        var currentA = headA;
        var currentB = headB;

        while (currentA != currentB)
        {
            currentA = currentA is null ? headB : currentA.next;
            currentB = currentB is null ? headA : currentB.next;
        }

        return currentA;
    }
}