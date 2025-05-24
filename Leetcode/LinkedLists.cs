using System.Text;

namespace Leetcode;

public class LinkedLists
{
    /// <summary>
    /// Input: l1 = [2,4,3], l2 = [5,6,4]
    /// Output: [7,0,8]
    /// Explanation: 342 + 465 = 807.
    /// </summary>
    /// <param name="l1"></param>
    /// <param name="l2"></param>
    /// <returns></returns>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode();
        var current = dummy;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            int val1 = l1?.val ?? 0;
            int val2 = l2?.val ?? 0;

            int total = val1 + val2 + carry;
            carry = total / 10;
            int digit = total % 10;

            current.next = new ListNode(digit);
            current = current.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return dummy.next;
    }

    public void PrintList(ListNode head)
    {
        var sb = new StringBuilder();
        var digits = new Stack<int>(); // to reconstruct the number

        while (head != null)
        {
            sb.Append(head.val);
            digits.Push(head.val);
            if (head.next != null)
                sb.Append(" → ");
            head = head.next;
        }

        sb.Append(" (");

        int multiplier = 1;
        int number = 0;
        while (digits.Count > 0)
        {
            number += digits.Pop() * multiplier;
            multiplier *= 10;
        }

        sb.Append(number);
        sb.Append(")");

        Console.WriteLine(sb);
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}