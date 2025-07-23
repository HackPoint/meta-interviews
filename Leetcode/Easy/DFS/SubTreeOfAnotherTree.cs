using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.DFS;

/// <summary>
/// Determines whether subRoot is a subtree of root.
/// A subtree must match both the structure and values of a subtree in root.
/// 
/// Time Complexity:  O(n * m)
///   - n: number of nodes in root
///   - m: number of nodes in subRoot (for each isSameTree call)
/// Space Complexity: O(h), where h is the height of the root tree (recursion stack)
/// </summary>
public class SubTreeOfAnotherTree
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        return dfs(root, subRoot);
    }

    /// <summary>
    /// Performs DFS on root to find a node that matches the start of subRoot.
    /// </summary>
    private bool dfs(TreeNode node, TreeNode subRoot)
    {
        if (node == null) return false;

        // Check if the subtree starting at current node matches subRoot
        if (IsSameTree(node, subRoot)) return true;

        // Continue DFS traversal: check left and right branches
        return dfs(node.left, subRoot) || dfs(node.right, subRoot);
    }

    /// <summary>
    /// Checks whether two trees are exactly the same in structure and node values.
    /// </summary>
    private bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true; // Both trees are empty → equal
        if (p == null || q == null) return false; // Only one is empty → not equal
        if (p.val != q.val) return false; // Different values → not equal

        // Recursively compare left and right children
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}