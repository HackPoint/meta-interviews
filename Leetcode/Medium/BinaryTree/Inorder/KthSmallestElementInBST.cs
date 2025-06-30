using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BT.Inorder;

public class KthSmallestElementInBST
{
    private int _globalCount;
    private int _globalResult;

    public int KthSmallest(TreeNode root, int k)
    {
        Dfs(root, k);
        return _globalResult;
    }

    private void Dfs(TreeNode node, int k)
    {
        if (node == null) return;

        Dfs(node.left, k);
        _globalCount++;

        if (_globalCount == k)
        {
            _globalResult = node.val;
            return; // early stoppage
        }

        Dfs(node.right, k);
    }
}