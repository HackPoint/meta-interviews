using Leetcode.Easy.LinkedList.DFS;
using Xunit;

namespace Leetcode.Medium.BinaryTree.Postorder;


/// <summary>
/// 235. Lowest Common Ancestor of a Binary Search Tree (BST)
///
/// Problem:
/// Given the root of a BST and two nodes p and q (existing in the tree),
/// return their Lowest Common Ancestor (LCA) — the deepest node that has
/// both p and q as descendants (a node can be a descendant of itself).
///
/// Approach (BST-directed search):
/// In a BST, left subtree < node < right subtree.
/// - If p.val and q.val are both less than current node's value, LCA lies in the left subtree.
/// - If both are greater, LCA lies in the right subtree.
/// - Otherwise, the current node is the split point and thus the LCA
///   (covers cases where current == p or current == q).
///
/// Correctness:
/// The BST ordering guarantees that if p and q lie strictly on one side,
/// no node on the other side can be their LCA. The first node where p and q
/// are not on the same side is the lowest split point that dominates both.
///
/// Time Complexity:
/// O(h), where h is the height of the tree (O(log n) for balanced, O(n) worst‑case).
///
/// Space Complexity:
/// O(1) for iterative implementation; O(h) for recursive (call stack).
///
/// Edge Cases:
/// - p == q → LCA is that node itself.
/// - One node is ancestor of the other → ancestor is the LCA.
/// - Root can be the LCA if p and q are on different sides of the root.
///
/// Example:
/// Tree:      6
///          /   \
///         2     8
///        / \   / \
///       0   4 7   9
///          / \
///         3   5
/// p = 2, q = 8 → LCA = 6
/// p = 2, q = 4 → LCA = 2
/// </summary>
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

[Trait("Category", "Medium")] 
public class LowestCommonAncestorOfBinaryTreeTests { 
    private readonly LowestCommonAncestorOfBinaryTree _sut = new();

    [Fact]
    public void LowestCommonAncestor_WhenBothNodesExist_ReturnsLCA()
    {
        // Arrange
        var root = new TreeNode(3);
        root.left = new TreeNode(5);
        root.right = new TreeNode(1);
        root.left.left = new TreeNode(6);
        root.left.right = new TreeNode(2);
        root.right.left = new TreeNode(0);
        root.right.right = new TreeNode(8);

        // Act
        var result = _sut.LowestCommonAncestor(root, root.left, root.right);

        // Assert
        Assert.Equal(3, result.val);
    }

    [Fact]
    public void LowestCommonAncestor_WhenOneNodeIsDescendantOfAnother_ReturnsUpperNode()
    {
        // Arrange
        var root = new TreeNode(3);
        root.left = new TreeNode(5);
        root.right = new TreeNode(1);
        root.left.left = new TreeNode(6);

        // Act
        var result = _sut.LowestCommonAncestor(root, root.left, root.left.left);

        // Assert
        Assert.Equal(5, result.val);
    }

    [Fact]
    public void LowestCommonAncestor_WhenNodesAreInDifferentSubtrees_ReturnsCommonAncestor()
    {
        // Arrange
        var root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        // Act
        var result = _sut.LowestCommonAncestor(root, root.left, root.right);

        // Assert
        Assert.Equal(1, result.val);
    }
}