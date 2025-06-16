using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.BT.InOrder;

public class BTFromPreorderAndInorderTraversal {
    private int preIndex = 0;
    private Dictionary<int, int> inorderIndexMap = new();

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        for (int i = 0; i < inorder.Length; i++) {
            inorderIndexMap[inorder[i]] = i;
        }

        return DFS(preorder, 0, inorder.Length - 1);
    }

    private TreeNode DFS(int[] preorder, int inStart, int inEnd) {
        if (inStart > inEnd) return null;

        int rootVal = preorder[preIndex++];
        var root = new TreeNode(rootVal);

        int inIndex = inorderIndexMap[rootVal];

        root.left = DFS(preorder, inStart, inIndex - 1);
        root.right = DFS(preorder, inIndex + 1, inEnd);

        return root;
    }
}