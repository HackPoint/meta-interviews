namespace Leetcode.Medium.LinkedLists;

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}

public class CopyListWithRandomPointer
{
    public Node CopyRandomList(Node head)
    {
        if (head == null) return null;

        // Pass 1: Insert cloned nodes
        var current = head;
        while (current != null)
        {
            var copy = new Node(current.val)
            {
                next = current.next
            };
            current.next = copy;
            current = copy.next;
        }

        // Pass 2: Assign random pointers
        current = head;
        while (current != null)
        {
            current.next.random = current.random?.next;
            current = current.next.next;
        }

        // Pass 3: Detach original and cloned list
        var dummy = new Node(0);
        var copyCurrent = dummy;
        current = head;

        while (current != null)
        {
            var copy = current.next;
            copyCurrent.next = copy;
            copyCurrent = copy;

            current.next = copy.next; // restore
            current = current.next;
        }

        return dummy.next;
    }
}