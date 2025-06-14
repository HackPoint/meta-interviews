using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.DFS;

public class MaximumDepthOfBT
{
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;
        return System.Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }
}