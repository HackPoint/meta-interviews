using Leetcode.Easy.LinkedList.TwoPointer.LinkedLists;

namespace Leetcode.Hard.Heap.PriorityQueue;

public class MergeKSortedLists
{
    public ListNode MergeKLists(ListNode[] lists) {
        var pq = new PriorityQueue<ListNode, int>();

        foreach(var node in lists) {
            if(node != null) {
                pq.Enqueue(node, node.val);
            }
        }

        var dummy = new ListNode(0);
        var tail = dummy;

        while(pq.Count > 0) {
            var minNode = pq.Dequeue();

            tail.next = minNode;
            tail = tail.next;

            if(minNode.next != null) {
                pq.Enqueue(minNode.next, minNode.next.val);
            }
        }

        return dummy.next;
    }
}