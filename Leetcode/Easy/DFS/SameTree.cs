using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Easy.DFS;

public class SameTree
{
    public class Solution {
        public bool IsSameTree(TreeNode p, TreeNode q) {
            if(p == null && q == null) return true;
            if(p == null || q == null) return false;

            if(p.val != q.val) {
                return false;
            }

            return IsSameTree(p.left, q.left) && IsSameTree(q.right, p.right);
        }
    }
}