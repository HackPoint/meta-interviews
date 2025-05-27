namespace Leetcode.Easy.LinkedList.DFS;

public class PathSums {
    
    // Efficient: O(N) time and O(H) space (for recursion stack).
    public bool HasPathSum(TreeNode root, int targetSum) {
        if (root == null) return false;

        if (root.left == null && root.right == null) {
            return root.val == targetSum;
        }

        return HasPathSum(root.left, targetSum - root.val)
               || HasPathSum(root.right, targetSum - root.val);
    }
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}