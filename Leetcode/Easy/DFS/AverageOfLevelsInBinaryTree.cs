using Leetcode.Easy.LinkedList.DFS;
using Xunit;

namespace Leetcode.Easy.DFS;

// <summary>
/// Solves LeetCode 637. Average of Levels in Binary Tree
///
/// Given a binary tree, this class provides two methods (BFS and DFS)
/// to compute the average value of the nodes on each level (depth) of the tree.
///
/// BFS Approach:
/// • Uses a queue to perform a level-order traversal (Breadth-First Search).
/// • For each level, it sums up all node values and divides by the number of nodes on that level.
/// • Nodes are processed in top-down, left-to-right order (level-by-level).
///
/// DFS Approach:
/// • Recursively traverses the tree using Depth-First Search.
/// • Maintains two lists: one for level sums and another for level node counts.
/// • At each level, adds the node's value to the correct index and increments the count.
/// • Averages are computed at the end by dividing total sum by count for each level.
///
/// Time Complexity:  O(n) for both BFS and DFS, where n = number of nodes in the tree
/// Space Complexity: O(w) for BFS (w = max width of tree), O(h) for DFS (h = height of tree)
///
/// Notes:
/// • BFS guarantees level-wise traversal, ideal for queue-based problems.
/// • DFS is more space efficient in balanced trees and provides a recursive solution.
/// • Both methods avoid null nodes and handle skewed trees correctly.
/// 
/// Example:
/// Input: [3,9,20,null,null,15,7]
/// Output: [3.0, 14.5, 11.0]
/// Explanation:
///   Level 0: [3] → avg = 3
///   Level 1: [9,20] → avg = (9+20)/2 = 14.5
///   Level 2: [15,7] → avg = (15+7)/2 = 11
/// </summary>
public class AverageOfLevelsInBinaryTree
{
    public IList<double> AverageOfLevelsBFS(TreeNode root)
    {
        if (root == null) return [];
        var result = new List<double>();

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            double levelSum = 0;

            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                if (node == null) continue; 
                levelSum += node.val;

                if (node.right != null) queue.Enqueue(node.right);
                if (node.left != null) queue.Enqueue(node.left);
            }

            result.Add(levelSum / levelSize);
        }

        return result;
    }
    
    public IList<double> AverageOfLevelsDFS(TreeNode root)
    {
        var levelSums = new List<double>();
        var levelCounts = new List<int>();

        DFS(root, 0, levelSums, levelCounts);

        var result = new List<double>();
        for (int i = 0; i < levelSums.Count; i++)
        {
            result.Add(levelSums[i] / levelCounts[i]);
        }

        return result;
    }

    private void DFS(TreeNode node, int level, List<double> levelSums, List<int> levelCounts)
    {
        if (node == null) return;

        // Если уровень новый, добавляем ячейки
        if (level == levelSums.Count)
        {
            levelSums.Add(node.val);
            levelCounts.Add(1);
        }
        else
        {
            levelSums[level] += node.val;
            levelCounts[level]++;
        }

        DFS(node.left, level + 1, levelSums, levelCounts);
        DFS(node.right, level + 1, levelSums, levelCounts);
    }
}

public class AverageOfLevelsTests
{
    [Fact]
    public void SingleNodeTree_ReturnsSingleValue()
    {
        var root = new TreeNode(10);
        var result = new AverageOfLevelsInBinaryTree().AverageOfLevelsDFS(root);
        Assert.Equal(new List<double> { 10.0 }, result);
    }

    [Fact]
    public void BalancedTree_ReturnsCorrectAverages()
    {
        var root = new TreeNode(3,
            new TreeNode(9),
            new TreeNode(20,
                new TreeNode(15),
                new TreeNode(7)));

        var result = new AverageOfLevelsInBinaryTree().AverageOfLevelsDFS(root);

        Assert.Equal(new List<double> { 3.0, 14.5, 11.0 }, result);
    }

    [Fact]
    public void SkewedLeftTree_ReturnsCorrectAverages()
    {
        var root = new TreeNode(5,
            new TreeNode(4,
                new TreeNode(3,
                    new TreeNode(2))));

        var result = new AverageOfLevelsInBinaryTree().AverageOfLevelsDFS(root);
        Assert.Equal(new List<double> { 5.0, 4.0, 3.0, 2.0 }, result);
    }

    [Fact]
    public void SkewedRightTree_ReturnsCorrectAverages()
    {
        var root = new TreeNode(1,
            null,
            new TreeNode(2,
                null,
                new TreeNode(3)));

        var result = new AverageOfLevelsInBinaryTree().AverageOfLevelsDFS(root);
        Assert.Equal(new List<double> { 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void EmptyTree_ReturnsEmptyList()
    {
        TreeNode root = null;
        var result = new AverageOfLevelsInBinaryTree().AverageOfLevelsDFS(root);
        Assert.Empty(result);
    }
}