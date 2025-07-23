namespace Leetcode.Medium.Graphs.Bfs;

public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

/// <summary>
/// Clones an undirected graph using BFS traversal.
/// Time Complexity: O(N + E) — N nodes and E edges
/// Space Complexity: O(N)
/// </summary>
public class CloneGraphs
{
    public Node CloneGraph(Node node) {
        if (node == null) return null;
        
        var visited = new Dictionary<Node, Node>();
        var clone = new Node(node.val);
        visited[node] = clone;

        var q = new Queue<Node>();
        q.Enqueue(node);

        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            foreach (var neighbor in curr.neighbors)
            {
                if (!visited.ContainsKey(neighbor))
                {
                    var neighborClone = new Node(neighbor.val);
                    visited[neighbor] = neighborClone;
                    q.Enqueue(neighbor);
                }
                visited[curr].neighbors.Add(visited[neighbor]);
            }
        }

        return clone;
    }
}