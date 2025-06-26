using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BT.Preorder;

public class InsertIntoBinarySearchTree
{
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if(root == null) return new TreeNode(val);
        Dfs(root);
        return root;

        void Dfs(TreeNode node) {
            if(node == null) return;

            if(node.val > val) {
                if(node.left == null) {
                    node.left = new TreeNode(val);
                } else {
                    Dfs(node.left);
                }
            }

            if(node.val < val) {
                if(node.right == null) {
                    node.right = new TreeNode(val);    
                } else {
                    Dfs(node.right);
                }            
            }
        }
    }
}