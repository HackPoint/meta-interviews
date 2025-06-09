using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.BT;

public class MinimumDepthOfBT {
    public int MinDepth(TreeNode root) {
        if (root == null) return 0;

        var queue = new Queue<(TreeNode node, int depth)>();
        queue.Enqueue((root, 1));

        while (queue.Count > 0) {
            var (node, depth) = queue.Dequeue();

            // If this is the first leaf node we find, return its depth
            if (node.left == null && node.right == null)
                return depth;

            if (node.left != null)
                queue.Enqueue((node.left, depth + 1));

            if (node.right != null)
                queue.Enqueue((node.right, depth + 1));
        }

        return 0;
    }
}