namespace Leetcode.Easy.LinkedList.DFS;

public class SymmetricTrees {
    public bool IsSymmetric(TreeNode root) {
        if(root == null) {
            return true;
        }
        return IsMirror(root.left, root.right);
        
        bool IsMirror(TreeNode left, TreeNode right) {
            if(left == null && right == null) return true;
            if(left == null || right == null) return false;
            if(left.val != right.val) return false;

            return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
        }
    }
}