namespace Leetcode.Design.Medium.Hashmap;

public class DynamicArrayO1
{
    private readonly Dictionary<int, Entry> _cache = new();
    private int _globalValue;
    private int _globalVersion = 1;

    public int Get(int index)
    {
        if (!_cache.TryGetValue(index, out var entry))
            return _globalValue;
        if (entry.Version >= _globalVersion)
            return entry.Value;
        
        return _globalValue;
    }

    public void Set(int index, int value)
    {
        _cache[index] = new Entry(_globalVersion, value);
    }

    public void SetAll(int value)
    {
        _globalVersion++;
        _globalValue = value;
    }
}

public record Entry(int Version, int Value);