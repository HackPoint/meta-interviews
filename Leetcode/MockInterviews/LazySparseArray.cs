namespace Leetcode.MockInterviews;

public interface ILazySparseArray
{
    int Get(int index);
    void Set(int index, int value);
    void SetAll(int value);
}

public class LazySparseArray : ILazySparseArray
{
    private readonly IDictionary<int, Entry> _cache = new Dictionary<int, Entry>();
    private int _globalVersion = 1;
    private int _globalValue;
    
    public int Get(int index)
    {
        if (_cache.TryGetValue(index, out var entry))
            return _globalValue;

        if (entry?.Version >= _globalVersion)
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