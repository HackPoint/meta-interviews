namespace Leetcode.Design.Medium.Set;

public class RandomizedSet {
    private readonly List<int> _set;
    private readonly Dictionary<int, int> _map;

    public RandomizedSet() {
        _set = new();
        _map = new();
    }
    
    public bool Insert(int val) {
        if(_map.ContainsKey(val)) {
            return false;
        }

        _set.Add(val);
        _map.Add(val, _set.Count - 1);
        return true;
    }
    
    public bool Remove(int val) {
        if(!_map.ContainsKey(val)) return false;

        int index = _map[val];
        int lastElement = _set[^1];
        _set[index] = lastElement;
        _map[lastElement] = index;

        _set.RemoveAt(_set.Count - 1);
        _map.Remove(val);
        return true;
    }
    
    public int GetRandom() {
        int randomIndex = Random.Shared.Next(0, _set.Count);
        return _set[randomIndex];
    }
}