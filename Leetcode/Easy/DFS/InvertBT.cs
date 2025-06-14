using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.DFS;

public class InvertBT
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;
            
        // swapping
        TreeNode current = root.left;
        root.left = InvertTree(root.right);
        root.right = InvertTree(current);

        return root;
    }
}