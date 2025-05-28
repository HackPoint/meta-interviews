namespace Leetcode.Medium.DSA.LRUCache;

public class LRUCacheNotCustomImplementationNo2
{
    private class ListNode
    {
        public int Key { get; }
        public int Value { get; set; }

        public ListNode(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }

    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<ListNode>> _cache;
    private readonly LinkedList<ListNode> _usageOrder;

    public LRUCacheNotCustomImplementationNo2(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, LinkedListNode<ListNode>>(capacity);
        _usageOrder = new LinkedList<ListNode>();
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }

        _usageOrder.Remove(node);
        _usageOrder.AddFirst(node);
        return node.Value.Value;
    }


    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            node.Value.Value = value;
            _usageOrder.Remove(node);
            _usageOrder.AddFirst(node);
        }
        else
        {
            var newNode = new LinkedListNode<ListNode>(new ListNode(key, value));
            _usageOrder.AddFirst(newNode);
            _cache[key] = newNode;

            if (_cache.Count > _capacity)
            {
                var lruNode = _usageOrder.Last;
                if (lruNode != null)
                {
                    _cache.Remove(lruNode.Value.Key);
                    _usageOrder.RemoveLast();
                }
            }
        }
    }
}