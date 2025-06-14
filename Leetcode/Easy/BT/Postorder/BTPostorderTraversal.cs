using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.BT.Postorder;

public class BTPostorderTraversal
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var list = new List<int>();
        Dfs(root, list);
        return list;
    }

    private void Dfs(TreeNode node, List<int> list)
    {
        if (node == null) return;

        Dfs(node.left, list);
        Dfs(node.right, list);

        list.Add(node.val);
    }
}