using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BT.Inorder;

public class BSTIterator
{
    private readonly Stack<TreeNode> _stack;
    public BSTIterator(TreeNode root)
    {
        _stack = new Stack<TreeNode>();
        Traverse(root);
    }
    
    public int Next()
    {
        var rightNode = _stack.Pop();        
        if (rightNode.right != null)         
            Traverse(rightNode.right);       
        return rightNode.val;                
    }
    
    public bool HasNext() => _stack.Count > 0;

    private void Traverse(TreeNode node)
    {
        if (node == null)  return;
        _stack.Push(node);
        Traverse(node.left);
    }
}