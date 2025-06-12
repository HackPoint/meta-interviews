namespace Leetcode.Design.Easy.Hashmap;

public class MyHashMap
{
    private const int Size = 769;
    private readonly List<LinkedList<(int key, int value)>> _buckets = new();

    public MyHashMap()
    {
        _buckets = new List<LinkedList<(int key, int value)>>(Size);
        for (int i = 0; i < Size; i++)
            _buckets.Add(new LinkedList<(int, int)>());
    }

    public void Put(int key, int value)
    {
        int index = Math.Abs(key % Size);
        var bucket = _buckets[index];
        var node = bucket.First;

        while (node != null)
        {
            if (node.Value.key == key)
            {
                node.Value = (key, value);
                return;
            }

            node = node.Next;
        }

        bucket.AddLast((key, value));
    }

    public int Get(int key)
    {
        int index = Math.Abs(key % Size);

        var bucket = _buckets[index];
        var node = bucket.First;
        while (node != null)
        {
            if (node.Value.key == key)
            {
                return node.Value.value;
            }

            node = node.Next;
        }

        return -1;
    }

    public void Remove(int key)
    {
        int index = Math.Abs(key % Size);
        var bucket = _buckets[index];
        var node = bucket.First;
        while (node != null)
        {
            if (node.Value.key == key)
            {
                var toRemove = node;
                node = node.Next; 
                bucket.Remove(toRemove);
                break;
            }
            else
            {
                node = node.Next;
            }
        }
    }
}