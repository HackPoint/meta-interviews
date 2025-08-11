using Leetcode.Easy.LinkedList.DFS;
using Leetcode.Medium.BinaryTree.Inorder;
using Xunit;

namespace Leetcode.Medium.BinaryTree.Inorder;

/// <summary>
/// 99. Recover Binary Search Tree
///
/// Problem:
/// In a BST, exactly two nodes have had their values swapped, violating the BST property.
/// Restore the BST by swapping those two nodes back without changing the tree's structure.
///
/// Approach (Short, Easy, Fast):
/// - Use recursive inorder DFS, which visits BST nodes in ascending order when valid.
/// - Track `prev` (previously visited node), and detect when `prev.val > current.val`.
/// - On the first violation, store `first = prev`.
/// - On every violation, update `second = current`.
/// - After traversal, swap values of `first` and `second`.
///
/// Time Complexity:
/// - O(n) — visits each node once.
/// 
/// Space Complexity:
/// - O(h) — recursion stack, h = tree height (O(log n) for balanced BST, O(n) worst case).
///
/// Correctness & Edge Cases:
/// - Handles both cases:
///   1) Swapped nodes are adjacent in inorder sequence → one violation.
///   2) Swapped nodes are not adjacent → two violations.
/// - If already valid (no violations), `first` and `second` remain null (no swap).
///
/// Example:
/// Input (inorder):   [1, 3, 2, 4] → violates at (3, 2)
/// Output (inorder):  [1, 2, 3, 4] after swapping 3 and 2.
/// </summary>
public class RecoverBinarySearchTree {
    public void RecoverTree(TreeNode root) {
        TreeNode prev = null!;
        TreeNode first = null!;
        TreeNode second = null!;
        Dfs(root);
        
        // swap
        if (first == null || second == null) return; // already valid, no swap needed
        (first.val, second.val) = (second.val, first.val);

        // Inorder traversal detects two misplaced nodes:
        // whenever prev.val > curr.val, record (first = prev) once, and always update (second = curr)            
        void Dfs(TreeNode node) {
            if (node == null) return;

            Dfs(node.left);
            if (prev != null && prev.val > node.val) {
                if (first == null) first = prev;
                second = node;
            }

            prev = node;
            Dfs(node.right);
        }
    }
}

public class RecoverBinarySearchTreeTests {
    // ---------- Helpers ----------
    private static List<int> Inorder(TreeNode root) {
        var res = new List<int>();

        void Dfs(TreeNode n) {
            if (n == null) return;
            Dfs(n.left);
            res.Add(n.val);
            Dfs(n.right);
        }

        Dfs(root);
        return res;
    }

    private static TreeNode Bst_1_2_3() =>
        new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) };

    private static TreeNode Bst_1_3_4_5_6_7_8() =>
        new TreeNode(5) {
            left = new TreeNode(3) {
                left = new TreeNode(1),
                right = new TreeNode(4)
            },
            right = new TreeNode(7) {
                left = new TreeNode(6),
                right = new TreeNode(8)
            }
        };

    // ---------- Tests ----------

    [Fact]
    public void AdjacentSwap_ShouldRecover_To123() {
        // Correct: inorder [1,2,3]; break by swapping 2 and 3 (adjacent in inorder)
        var root = Bst_1_2_3();
        // swap values of root(2) and right(3) -> inorder becomes [1,3,2]
        int t = root.val;
        root.val = root.right.val;
        root.right.val = t;
        Assert.Equal(new List<int> { 1, 3, 2 }, Inorder(root)); // broken

        new RecoverBinarySearchTree().RecoverTree(root);

        Assert.Equal(new List<int> { 1, 2, 3 }, Inorder(root));
    }

    [Fact]
    public void NonAdjacentSwap_ShouldRecover_To1345678() {
        // Correct: inorder [1,3,4,5,6,7,8]; break by swapping 1 and 7 (non-adjacent)
        var root = Bst_1_3_4_5_6_7_8();
        int tmp = root.right.val; // 7
        root.right.val = root.left.left.val; // 1
        root.left.left.val = tmp; // 7
        Assert.Equal(new List<int> { 7, 3, 4, 5, 6, 1, 8 }, Inorder(root)); // broken

        new RecoverBinarySearchTree().RecoverTree(root);

        Assert.Equal(new List<int> { 1, 3, 4, 5, 6, 7, 8 }, Inorder(root));
    }

    [Fact]
    public void AlreadyValid_ShouldRemainValid() {
        var root = Bst_1_2_3();
        var before = Inorder(root);

        new RecoverBinarySearchTree().RecoverTree(root);

        Assert.Equal(before, Inorder(root));
    }

    [Fact]
    public void Skewed_LeftChain_NonAdjacentSwap_ShouldRecover() {
        // Build skewed:    3
        //                 /
        //                2
        //               /
        //              1
        var root = new TreeNode(3) {
            left = new TreeNode(2) { left = new TreeNode(1) }
        };
        // Swap 1 and 3 (non-adjacent): inorder becomes [3,2,1]
        int t = root.val;
        root.val = root.left.left.val;
        root.left.left.val = t;
        Assert.Equal(new List<int> { 3, 2, 1 }, Inorder(root)); // broken

        new RecoverBinarySearchTree().RecoverTree(root);

        Assert.Equal(new List<int> { 1, 2, 3 }, Inorder(root));
    }
}