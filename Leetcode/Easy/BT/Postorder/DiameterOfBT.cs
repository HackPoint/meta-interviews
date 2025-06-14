using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.BT.Postorder;

public class DiameterOfBT
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int globalMax = 0;

        int Dfs(TreeNode node)
        {
            if (node == null) return 0;

            int left = Dfs(node.left);
            int right = Dfs(node.right);

            globalMax = System.Math.Max(globalMax, left + right);

            return 1 + System.Math.Max(left, right);
        }

        Dfs(root);
        return globalMax;
    }
}