namespace Leetcode.Easy.LinkedList.DFS;

public class BinaryTreeInOrderTraversal
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var list = new List<int>();
        if (root == null) return list;
        Traverse(root, list);
        return list;
    }

    private void Traverse(TreeNode root, IList<int> list)
    {
        if (root.left != null)
        {
            Traverse(root.left, list);
        }

        list.Add(root.val);
        
        if (root.right != null)
        {
            Traverse(root.right, list);
        }
    }
}