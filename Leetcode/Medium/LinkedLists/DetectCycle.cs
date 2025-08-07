using Leetcode.Easy.LinkedList.TwoPointer.LinkedLists;
using Xunit;

namespace Leetcode.Medium.LinkedLists;

public class DetectCyclesFloydsAlgorithms
{
    public ListNode DetectCycle(ListNode head) {
        if(head == null || head.next == null) return null;
        var slow = head;
        var fast = head;
        
        
        while(fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
            
            if (slow == fast)
            {
                var ptr1 = head;
                var ptr2 = slow;

                while (ptr1 != ptr2) {
                    ptr1 = ptr1.next;
                    ptr2 = ptr2.next;
                }

                return ptr1;
            }
            
        }
        
        return null;
    }
}

public class DetectCycleTests
{
    private DetectCyclesFloydsAlgorithms solution = new();

    [Fact]
    public void DetectCycle_NoCycle_ReturnsNull()
    {
        var node1 = new ListNode(3);
        var node2 = new ListNode(2);
        var node3 = new ListNode(0);
        var node4 = new ListNode(-4);

        node1.next = node2;
        node2.next = node3;
        node3.next = node4;

        var result = solution.DetectCycle(node1);

        Assert.Null(result);
    }

    [Fact]
    public void DetectCycle_WithCycleAtNode2_ReturnsNode2()
    {
        var node1 = new ListNode(3);
        var node2 = new ListNode(2);
        var node3 = new ListNode(0);
        var node4 = new ListNode(-4);

        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node2; // цикл

        var result = solution.DetectCycle(node1);

        Assert.Equal(node2, result);
    }

    [Fact]
    public void DetectCycle_SingleNodeWithCycle_ReturnsNode()
    {
        var node1 = new ListNode(1);
        node1.next = node1; // сам на себя

        var result = solution.DetectCycle(node1);

        Assert.Equal(node1, result);
    }

    [Fact]
    public void DetectCycle_TwoNodesWithCycle_ReturnsHead()
    {
        var node1 = new ListNode(1);
        var node2 = new ListNode(2);
        node1.next = node2;
        node2.next = node1; // цикл

        var result = solution.DetectCycle(node1);

        Assert.Equal(node1, result);
    }

    [Fact]
    public void DetectCycle_NullHead_ReturnsNull()
    {
        var result = solution.DetectCycle(null);
        Assert.Null(result);
    }
}
