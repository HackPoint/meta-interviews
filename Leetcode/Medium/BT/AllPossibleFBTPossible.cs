using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BT;

public class AllPossibleFbtPossible {
    private readonly Dictionary<int, IList<TreeNode>> memo = new();

    public IList<TreeNode> AllPossibleFBT(int n) {
        if (n % 2 == 0) return [];
        if (n == 1) return [new TreeNode()];
        if (memo.TryGetValue(n, out var fbt)) return fbt;

        IList<TreeNode> result = new List<TreeNode>();
        for (int left = 1; left < n; left += 2) {
            int right = n - 1 - left;

            foreach (var leftTree in AllPossibleFBT(left)) {
                foreach (var rightTree in AllPossibleFBT(right)) {
                    var root = new TreeNode(0) {
                        left = Clone(leftTree),
                        right = Clone(rightTree)
                    };
                    result.Add(root);
                }
            }
        }

        memo[n] = result;
        return result;
    }
    
    private TreeNode Clone(TreeNode node) {
        if (node == null) return null;
        return new TreeNode(node.val, Clone(node.left), Clone(node.right));
    }
}