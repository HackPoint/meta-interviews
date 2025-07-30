using Leetcode.Easy.LinkedList.DFS;
using Xunit;

namespace Leetcode.Easy.BT;

public class BinaryTreePath
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        var result = new List<string>();
        Dfs(root, string.Empty, result);
        return result;
    }

    private void Dfs(TreeNode node, string path, IList<string> result)
    {
        if (node == null) return;

        path += node.val.ToString();
        if (node.left == null && node.right == null)
            result.Add(path);
        else
        {
            path += "->";

            Dfs(node.left, path, result);
            Dfs(node.right, path, result);
        }
    }
}

public class BinaryTreePathsTests
{
    private TreeNode Tree(params int?[] values)
        => BinaryTreeHelper.FromLevelOrder(values);

    [Fact]
    public void Test_Example_1()
    {
        var root = Tree(1, 2, 3, null, 5);
        var solver = new BinaryTreePath();

        var result = solver.BinaryTreePaths(root);

        Assert.Contains("1->2->5", result);
        Assert.Contains("1->3", result);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Test_SingleNode()
    {
        var root = new TreeNode(42);
        var solver = new BinaryTreePath();

        var result = solver.BinaryTreePaths(root);

        Assert.Equal(new List<string> { "42" }, result);
    }

    [Fact]
    public void Test_Empty()
    {
        TreeNode root = null;
        var solver = new BinaryTreePath();

        var result = solver.BinaryTreePaths(root);

        Assert.Empty(result);
    }
}

public static class BinaryTreeHelper
{
    public static TreeNode FromLevelOrder(params int?[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null)
            return null;

        TreeNode root = new(values[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int i = 1;

        while (i < values.Length)
        {
            TreeNode current = queue.Dequeue();

            if (i < values.Length && values[i] != null)
            {
                current.left = new TreeNode(values[i].Value);
                queue.Enqueue(current.left);
            }

            i++;

            if (i < values.Length && values[i] != null)
            {
                current.right = new TreeNode(values[i].Value);
                queue.Enqueue(current.right);
            }

            i++;
        }

        return root;
    }
}