using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.DFS.Tests;

using Xunit;

public class InvertBinaryTreeTests
{
    [Fact]
    public void Invert_EmptyTree_ReturnsNull()
    {
        TreeNode root = null;
        var result = new InvertBT().InvertTree(root);
        Assert.Null(result);
    }

    [Fact]
    public void Invert_SingleNodeTree_ReturnsSameNode()
    {
        var root = new TreeNode(1);
        var result = new InvertBT().InvertTree(root);
        Assert.Equal(1, result.val);
        Assert.Null(result.left);
        Assert.Null(result.right);
    }

    [Fact]
    public void Invert_BalancedTree_CorrectlyInverts()
    {
        // Input:       4
        //            /   \
        //           2     7
        //          / \   / \
        //         1   3 6   9

        var root = new TreeNode(4,
            new TreeNode(2, new TreeNode(1), new TreeNode(3)),
            new TreeNode(7, new TreeNode(6), new TreeNode(9)));

        var result = new InvertBT().InvertTree(root);

        // Expected:     4
        //             /   \
        //            7     2
        //           / \   / \
        //          9   6 3   1

        Assert.Equal(4, result.val);
        Assert.Equal(7, result.left.val);
        Assert.Equal(2, result.right.val);
        Assert.Equal(9, result.left.left.val);
        Assert.Equal(6, result.left.right.val);
        Assert.Equal(3, result.right.left.val);
        Assert.Equal(1, result.right.right.val);
    }

    [Fact]
    public void Invert_SkewedTree_LeftToRight()
    {
        // Input:   1
        //         /
        //        2
        //       /
        //      3

        var root = new TreeNode(1, new TreeNode(2, new TreeNode(3), null), null);
        var result = new InvertBT().InvertTree(root);

        // Output: 1
        //          \
        //           2
        //            \
        //             3

        Assert.Equal(1, result.val);
        Assert.Null(result.left);
        Assert.Equal(2, result.right.val);
        Assert.Null(result.right.left);
        Assert.Equal(3, result.right.right.val);
    }
}

