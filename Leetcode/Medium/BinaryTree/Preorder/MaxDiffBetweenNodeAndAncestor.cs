using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BinaryTree.Preorder;

/// <summary>
/// 1026. Maximum Difference Between Node and Ancestor
///
/// Problem:
/// Given a binary tree, find the maximum value of |ancestor.val - node.val|
/// for all pairs (ancestor, descendant) where ancestor is higher on the path
/// from the root to node (excluding node itself as its own ancestor).
///
/// Approach (Short, Easy, Fast):
/// - Use DFS from the root, carrying along two values: `minPath` and `maxPath`
///   — the minimum and maximum values seen so far along the current root-to-node path.
/// - At each node:
///     1. Update `minPath` and `maxPath` with node's value.
///     2. Compute the difference between node's value and both extremes.
///     3. Update a global `maxDiff` if this difference is larger than the previous max.
/// - Recurse into left and right children with updated `minPath` and `maxPath`.
///
/// Time Complexity:
/// - O(n): each node is visited exactly once.
///
/// Space Complexity:
/// - O(h): recursion stack, where h is the height of the tree.
///
/// Correctness & Edge Cases:
/// - Handles trees with only one node (result = 0).
/// - Works for skewed trees (worst-case height = n).
/// - Works for all values in the allowed range.
/// 
/// Example:
/// Input:
///     8
///    / \
///   3   10
///  / \    \
/// 1   6    14
///
/// Output:
/// - Max diff = |8 - 1| = 7.
/// </summary>
public class MaxDiffBetweenNodeAndAncestor {
    public int MaxAncestorDiff(TreeNode root) {
        int maxDiff = 0;
        Dfs(root, root.val, root.val);
        return maxDiff;

        void Dfs(TreeNode node, int minPath, int maxPath) {
            if(node == null) return;
            minPath = Math.Min(minPath, node.val);
            maxPath = Math.Max(maxPath, node.val);
          
            // compute diff vs current path extremes and keep the global maximum
            int diff = Math.Max(Math.Abs(node.val - minPath), Math.Abs(node.val - maxPath));
            maxDiff = Math.Max(maxDiff, diff);

            Dfs(node.left, minPath, maxPath);
            Dfs(node.right, minPath, maxPath);
        }
    }
}