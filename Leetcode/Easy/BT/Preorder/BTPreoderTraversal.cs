using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.BT.Preorder;

public class BTPreoderTraversal
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        if (root == null) return Array.Empty<int>();
        var list = new List<int>();
        // Visit (process the current value and add to list)
        Bfs(root, list);
        return list;
    }

    private void Bfs(TreeNode root, List<int> list)
    {
        if (root == null) return;
        list.Add(root.val);

        Bfs(root.left, list);
        Bfs(root.right, list);
    }
}