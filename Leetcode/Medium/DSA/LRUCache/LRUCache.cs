namespace Leetcode.Medium.DSA.LRUCache;

public class LRUCache
{
    private class Node
    {
        public int Key;
        public int Value;
        public Node Prev;
        public Node Next;
    }

    private readonly int _capacity;
    private readonly Dictionary<int, Node> _cache;
    private readonly Node _head;
    private readonly Node _tail;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, Node>(capacity * 2);

        _head = new Node();
        _tail = new Node();
        _head.Next = _tail;
        _tail.Next = _head;
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }
        MoveToFront(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            node.Value = value;
            MoveToFront(node);
        }
        else
        {
            if (_cache.Count >= _capacity)
            {
                var lru = _tail.Prev;
                Remove(lru);
                _cache.Remove(lru.Key);
            }

            var newNode = new Node { Key = key, Value = value };
            _cache[key] = newNode;
            InsertToFront(newNode);
        }
    }

    private void MoveToFront(Node node)
    {
        Remove(node);
        InsertToFront(node);
    }

    private void InsertToFront(Node node)
    {
        node.Next = _head.Next;
        node.Prev = _head;
        _head.Next.Prev = node;
        _head.Next = node;
    }

    private void Remove(Node node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }
}