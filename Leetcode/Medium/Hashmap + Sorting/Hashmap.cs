using System.Collections;

namespace Leetcode.Medium.Hashmap___Sorting;

public class MyHashMap {
    private readonly int _size;
    private readonly List<(int key, int value)>[] _buckets;

    public MyHashMap() {
        _size = 1000;
        _buckets = new List<(int, int)>[_size];
        for (var i = 0; i < _size; i++) {
            _buckets[i] = new List<(int, int)>();
        }
    }

    public void Put(int key, int value) {
        int index = Hash(key);
        var bucket = _buckets[index];

        for (int i = 0; i < bucket.Count; i++) {
            if (bucket[i].key == key) {
                bucket[i] = (key, value); 
                return;
            }
        }

        bucket.Add((key, value)); 
    }

    public int Get(int key) {
        int index = Hash(key);
        var bucket = _buckets[index];
        foreach (var (k, v) in bucket) {
            if (k == key)
                return v;
        }
        return -1;
    }

    public void Remove(int key) {
        int index = Hash(key);
        var bucket = _buckets[index];

        for (int i = 0; i < bucket.Count; i++) {
            if (bucket[i].key == key) {
                bucket.RemoveAt(i);
                return;
            }
        }
    }

    private int Hash(int key) {
        return key % _size;
    }
}
