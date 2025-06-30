using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BT.Inorder;

public class ValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root)
    {
        return Dfs(root, 0, 0);
    }

    private bool Dfs(TreeNode node, int min, int max)
    {
        if(node == null) return true;
        if (node.val <= min && max <= node.val)
            return false;

        return Dfs(node.left, min, node.val) && Dfs(node.right, node.val, max);
    }
}