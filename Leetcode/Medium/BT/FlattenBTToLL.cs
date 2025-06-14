using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BT;

public class FlattenBTToLL
{
    public void Flatten(TreeNode root) {
        if (root == null) return;

        // Flatten left and right subtrees recursively
        Flatten(root.left);
        Flatten(root.right);

        if (root.left != null) {
            // Save original right subtree
            TreeNode tempRight = root.right;

            // Move left to right
            root.right = root.left;
            root.left = null;

            // Move to the tail of the new right subtree
            TreeNode tail = root.right;
            while (tail.right != null) {
                tail = tail.right;
            }

            // Attach the saved right subtree
            tail.right = tempRight;
        }
    }
}