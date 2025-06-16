using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Medium.BT.LevelOrder;

public class BTZigzagLevelOrderTraversal
{
    private IList<IList<int>> _result = new List<IList<int>>();
    
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        int level = 0;
        Dfs(root, level);
        return _result;
    }
    
    private void Dfs(TreeNode node,int level) {
        if(node == null) return;
        if(level == _result.Count) _result.Add(new List<int>());

        if(level % 2 == 0) {
            _result[level].Add(node.val);
        } 

        if(level % 2 == 1) {
            _result[level].Insert(0, node.val);
        }

        Dfs(node.left, level + 1);
        Dfs(node.right, level + 1);
    }
}