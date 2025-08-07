using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.MockInterviews;

public class DeleteNodeInBST
{
    public TreeNode DeleteNode(TreeNode root, int key) {
        return Dfs(root, key);
    }
    
    private TreeNode Dfs(TreeNode node, int key) {
        if(node == null) return null;
        
        // left/right node to remove
        if(node.val > key) {
            node.left = Dfs(node.left, key);
        } else if( key > node.val) {
            node.right = Dfs(node.right, key);
        } else {
            // Node with the key found
            if(node.left == null) return node.right;
            if(node.right == null) return node.left;
            
            var minNode = GetMin(node.right);
            node.val = minNode.val;
            node.right = Dfs(node.right, minNode.val);
        }
        
        return node;
    }
    
    private TreeNode GetMin(TreeNode node) {
        while(node.left != null) node = node.left;
        return node;
    }
}