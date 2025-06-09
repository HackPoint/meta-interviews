using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.BT;

public class BalancedBinaryTree {
    public bool IsBalanced(TreeNode root) {
        return Dfs(root) != -1;
    }

    private int Dfs(TreeNode node) {
        if(node == null) return 0;

        int left = Dfs(node.left);
        if(left == -1) return -1;
        int right = Dfs(node.right);
        if(right == -1) return -1;

        if(System.Math.Abs(left - right) > 1) return -1;
        return 1 + System.Math.Max(left, right);
    }
}