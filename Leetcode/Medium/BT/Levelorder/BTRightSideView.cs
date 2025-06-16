using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BT.LevelOrder;

public class BTRightSideView
{
    private IList<int> _result = new List<int>();
    public IList<int> RightSideView(TreeNode root)
    {
        Dfs(root, 0);
        return _result;
    }
    
    private void Dfs(TreeNode node, int level) {
        if (node == null) return;

        if (level == _result.Count)
            _result.Add(node.val);

        Dfs(node.right, level + 1);
        Dfs(node.left, level + 1);
    }
}