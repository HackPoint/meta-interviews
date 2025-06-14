using Leetcode.Easy.LinkedList.DFS;
using Leetcode.Medium.BT;
using Xunit;

namespace Leetcode.Medium.Tests;

public class FlattenBinaryTreeTests
{
    // Helper: build tree from array (nulls allowed)
    private TreeNode BuildTree(int?[] values)
    {
        if (values.Length == 0 || values[0] == null) return null;

        TreeNode root = new TreeNode(values[0]!.Value);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int i = 1;

        while (queue.Count > 0 && i < values.Length)
        {
            var node = queue.Dequeue();

            if (i < values.Length && values[i] != null)
            {
                node.left = new TreeNode(values[i].Value);
                queue.Enqueue(node.left);
            }

            i++;

            if (i < values.Length && values[i] != null)
            {
                node.right = new TreeNode(values[i].Value);
                queue.Enqueue(node.right);
            }

            i++;
        }

        return root;
    }

    // Helper: convert flattened right-skewed tree to list
    private List<int> FlattenedToList(TreeNode root)
    {
        var result = new List<int>();
        while (root != null)
        {
            result.Add(root.val);
            if (root.left != null)
                throw new System.Exception("Tree was not properly flattened: found a left child");
            root = root.right;
        }

        return result;
    }

    [Fact]
    public void Flatten_ExampleCase()
    {
        var root = BuildTree(new int?[] { 1, 2, 5, 3, 4, null, 6 });

        new FlattenBTToLL().Flatten(root);

        var result = FlattenedToList(root);
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
    }

    [Fact]
    public void Flatten_SingleNode()
    {
        var root = BuildTree([1]);

        new FlattenBTToLL().Flatten(root);

        var result = FlattenedToList(root);
        Assert.Equal(new List<int> { 1 }, result);
    }

    [Fact]
    public void Flatten_EmptyTree()
    {
        TreeNode root = null;

        new FlattenBTToLL().Flatten(root);

        Assert.Null(root);
    }

    [Fact]
    public void Flatten_LeftHeavyTree()
    {
        var root = BuildTree([1, 2, null, 3]);

        new FlattenBTToLL().Flatten(root);

        var result = FlattenedToList(root);
        Assert.Equal(new List<int> { 1, 2, 3 }, result);
    }

    [Fact]
    public void Flatten_RightHeavyTree()
    {
        var root = BuildTree([1, null, 2, null, 3]);

        new FlattenBTToLL().Flatten(root);

        var result = FlattenedToList(root);
        Assert.Equal(new List<int> { 1, 2, 3 }, result);
    }
}
