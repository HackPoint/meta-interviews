using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Hard.BT.Postorder;

public class BTMaximumPathSum
{
    private int _globalMax = int.MinValue;
    public int MaxPathSum(TreeNode root)
    {
        int Dfs(TreeNode node)
        {
            if (node == null) return 0;

            // local: sum of two hands (left/right)
            int left = Math.Max(0, Dfs(node.left));
            int right = Math.Max(0, Dfs(node.right));

            // update: globalMax
            _globalMax = Math.Max(_globalMax, (left + right));

            // return: max of one ot the hands (left or right)
            return 1 + Math.Max(left, right);
        }
        Dfs(root);
        return _globalMax;
    }
}