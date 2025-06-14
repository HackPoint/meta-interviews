namespace Leetcode.Easy.BT.Preorder;

public class NAryTree
{
    public IList<int> Preorder(Node root)
    {
        if (root == null) return Array.Empty<int>();
        var list = new List<int>();
        Traverse(root, list);

        return list;
    }

    private void Traverse(Node root, List<int> list)
    {
        if (root == null) return;
        list.Add(root.val);

        foreach (var child in root.children)
            Traverse(child, list);
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}