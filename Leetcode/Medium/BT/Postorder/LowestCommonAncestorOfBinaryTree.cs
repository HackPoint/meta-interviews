using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BT.Postorder;

public class LowestCommonAncestorOfBinaryTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        return Dfs(root, p, q);
    }

    private TreeNode Dfs(TreeNode node, TreeNode p, TreeNode q)
    {
        if (node == null) return null;
        if (node == p || node == q) return node;

        var left = Dfs(node.left, p, q);
        var right = Dfs(node.right, p, q);

        if (left != null && right != null) return node;
        return left ?? right;
    }
}