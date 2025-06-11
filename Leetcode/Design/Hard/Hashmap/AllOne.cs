namespace Leetcode.Design.Hard.Hashmap;

public class AllOne
{
    private readonly Dictionary<string, int> _keyToCount = new();
    private readonly Dictionary<int, BucketNode> _countToBucket = new();

    private readonly BucketNode _head = new(0);
    private readonly BucketNode _tail = new(0);

    public AllOne()
    {
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public void Inc(string key)
    {
        if (_keyToCount.TryGetValue(key, out int currentCount))
        {
            int newCount = currentCount + 1;
            _keyToCount[key] = newCount;

            BucketNode currentBucket = _countToBucket[currentCount];
            BucketNode nextBucket = _countToBucket.ContainsKey(newCount)
                ? _countToBucket[newCount]
                : InsertBucketAfter(currentBucket, newCount);
            nextBucket.AddKey(key);
            currentBucket.RemoveKey(key);
            if (currentBucket.IsEmpty())
            {
                RemoveBucket(currentBucket);
                _countToBucket.Remove(currentCount);
            }

            _countToBucket[newCount] = nextBucket;
        }
        else
        {
            _keyToCount[key] = 1;
            BucketNode firstBucket = _countToBucket.ContainsKey(1)
                ? _countToBucket[1]
                : InsertBucketAfter(_head, 1);
            firstBucket.AddKey(key);
            _countToBucket[1] = firstBucket;
        }
    }

    public void Dec(string key)
    {
        if (!_keyToCount.TryGetValue(key, out int currentCount)) return;

        BucketNode currentBucket = _countToBucket[currentCount];
        currentBucket.RemoveKey(key);

        if (currentCount == 1)
        {
            _keyToCount.Remove(key);
        }
        else
        {
            int newCount = currentCount - 1;
            _keyToCount[key] = newCount;

            BucketNode prevBucket = _countToBucket.ContainsKey(newCount)
                ? _countToBucket[newCount]
                : InsertBucketAfter(currentBucket.Prev, newCount);

            prevBucket.AddKey(key);
            _countToBucket[newCount] = prevBucket;
        }

        if (currentBucket.IsEmpty())
        {
            RemoveBucket(currentBucket);
            _countToBucket.Remove(currentCount);
        }
    }

    public string GetMaxKey()
    {
        return _tail.Prev != _head && _tail.Prev.Keys.Count > 0
            ? _tail.Prev.FirstKey()
            : string.Empty;
    }

    public string GetMinKey()
    {
        return _head.Next != _tail && _head.Next.Keys.Count > 0
            ? _head.Next.FirstKey()
            : string.Empty;
    }

    private BucketNode InsertBucketAfter(BucketNode prev, int count)
    {
        var newBucket = new BucketNode(count)
        {
            // Rewire next and prev pointers
            Next = prev.Next,
            Prev = prev
        };

        prev.Next.Prev = newBucket;
        prev.Next = newBucket;

        return newBucket;
    }

    private void RemoveBucket(BucketNode bucket)
    {
        bucket.Prev.Next = bucket.Next;
        bucket.Next.Prev = bucket.Prev;

        bucket.Next = null!;
        bucket.Prev = null!;
    }
}

public class BucketNode
{
    public int Count { get; set; }
    public LinkedList<string> Keys { get; } = new();
    public Dictionary<string, LinkedListNode<string>> KeyMap { get; } = new();

    public BucketNode Next { get; set; }
    public BucketNode Prev { get; set; }

    public BucketNode(int count)
    {
        Count = count;
    }

    public void AddKey(string key)
    {
        var node = Keys.AddLast(key);
        KeyMap[key] = node;
    }

    public void RemoveKey(string key)
    {
        if (KeyMap.TryGetValue(key, out var node))
        {
            Keys.Remove(node);
            KeyMap.Remove(key);
        }
    }

    public bool IsEmpty() => Keys.Count == 0;

    public string FirstKey() => Keys.First!.Value;
}