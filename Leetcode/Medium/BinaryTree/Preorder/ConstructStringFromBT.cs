using System.Text;
using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.BT.Preorder;

public class ConstructStringFromBT
{
    public string Tree2str(TreeNode root)
    {
        if (root == null) return string.Empty;
        StringBuilder str = new();

        void Dfs(TreeNode node)
        {
            if (node == null) return;

            str.Append(node.val);

            if (node.left != null || node.right != null)
            {
                str.Append("(");
                Dfs(node.left);
                str.Append(")");
            }

            if (node.right != null)
            {
                str.Append("(");
                Dfs(node.right);
                str.Append(")");
            }
        }

        Dfs(root);

        return str.ToString();
    }
}