namespace Leetcode.Medium.DSA.LRUCache;

public class LruCacheNotCustomImplementation
{
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> _cache;
    private readonly LinkedList<(int key, int value)> _usage;

    public LruCacheNotCustomImplementation(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, LinkedListNode<(int, int)>>(capacity);
        _usage = new LinkedList<(int, int)>();
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
            return -1;

        _usage.Remove(node);
        _usage.AddFirst(node);

        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        if (_cache.ContainsKey(key))
        {
            var existingNode = _cache[key];
            _usage.Remove(existingNode);
        }
        
        var newNode = new LinkedListNode<(int key, int value)>((key, value));
        _usage.AddFirst(newNode);
        _cache[key] = newNode;
        
        if (_cache.Count > _capacity)
        {
            var lru = _usage.Last;
            if (lru != null)
            {
                _cache.Remove(lru.Value.key);
                _usage.RemoveLast();
            }
        }
    }
}