using Xunit;

namespace Leetcode.MockInterviews;

public interface ILruCache<in TKey, TValue>
{
    /// <summary>
    /// Gets value by key; returns true if found and outputs the value.
    /// Must mark the key as most-recently used.
    /// </summary>
    TValue Get(TKey key);

    /// <summary>
    /// Inserts or updates the key with value.
    /// Must mark as most-recently used and evict least-recently used on overflow.
    /// </summary>
    void Put(TKey key, TValue value);
}

public class LruCache(int capacity) : ILruCache<int, int>
{
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> _cache = new(capacity: capacity);
    private readonly LinkedList<(int key, int value)> _usage = new();

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
            throw new KeyNotFoundException();

        _usage.Remove(node);
        _usage.AddFirst(node);

        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var existingNode))
            _usage.Remove(existingNode);
        
        if (_cache.Count == capacity)
        {
            var lru = _usage.Last;
            if (lru != null)
            {
                _cache.Remove(lru.Value.key);
                _usage.RemoveLast();
            }
        }
        
        var newNode = new LinkedListNode<(int key, int value)>((key, value));
        _usage.AddFirst(newNode);
        _cache[key] = newNode;
    }
}

/// <summary>
/// Tests for ILruCache<TKey,TValue> contract:
/// - Get(key) returns value and marks key as MRU; throws KeyNotFoundException if absent
/// - Put(key, value) inserts/updates, marks as MRU, evicts LRU on overflow
/// Replace `new LruCache<int,int>(capacity)` with your implementation.
/// </summary>
public sealed class LruCacheInterfaceTests
{
    private static ILruCache<int,int> Create(int capacity)
        => new LruCache(capacity); // ⬅ replace with your class

    [Fact]
    public void Get_Throws_WhenKeyMissing()
    {
        var cache = Create(2);
        Assert.Throws<KeyNotFoundException>(() => cache.Get(42));
    }

    [Fact]
    public void Put_EvictsLeastRecentlyUsed_OnOverflow()
    {
        var cache = Create(2);
        cache.Put(1, 10);           // [1]
        cache.Put(2, 20);           // [2,1]  (2 = MRU)
        // LRU is 1
        cache.Put(3, 30);           // evict 1 → [3,2]

        Assert.Equal(20, cache.Get(2));    // still present
        Assert.Equal(30, cache.Get(3));    // present

        Assert.Throws<KeyNotFoundException>(() => cache.Get(1)); // evicted
    }

    [Fact]
    public void Get_MovesKeyToMostRecentlyUsed()
    {
        var cache = Create(2);
        cache.Put(1, 10);           // [1]
        cache.Put(2, 20);           // [2,1]

        // Access 1 → becomes MRU: order [1,2]
        Assert.Equal(10, cache.Get(1));

        // Overflow now should evict 2 (current LRU), not 1
        cache.Put(3, 30);           // evicts 2 → [3,1]

        Assert.Equal(10, cache.Get(1));
        Assert.Equal(30, cache.Get(3));
        Assert.Throws<KeyNotFoundException>(() => cache.Get(2));
    }
}
