using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.BT.InOrder;

public class MinimumAbsoluteDifferenceInBst
{
    public int GetMinimumDifference(TreeNode root)
    {
        int minDiff = int.MaxValue;
        int? prev = null;

        void InOrder(TreeNode node)
        {
            if (node == null) return;

            // Left
            InOrder(node.left);

            // Node
            if (prev != null)
                minDiff = System.Math.Min(minDiff, node.val - prev.Value);

            prev = node.val;

            // Right
            InOrder(node.right);
        }

        InOrder(root);
        return minDiff;
    }

}