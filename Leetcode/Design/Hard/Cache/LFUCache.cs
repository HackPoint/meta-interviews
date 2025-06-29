namespace Leetcode.Design.Hard.Cache;

public class LFUCache {
    private int _minFrequency = 0;
    private readonly Dictionary<int, Node> _cache;
    private readonly Dictionary<int, LinkedList<Node>> _freqList;
    private readonly int _capacity;

    private class Node {
        public int Key;
        public int Value;
        public int Frequency;
    }

    public LFUCache(int capacity) {
        _capacity = capacity;
        _cache = new Dictionary<int, Node>(capacity * 2);
        _freqList = new Dictionary<int, LinkedList<Node>>(capacity * 2);
    }

    public int Get(int key) {
        if (!_cache.ContainsKey(key)) return -1;

        var node = _cache[key];
        int oldFrequency = node.Frequency;
        _freqList[oldFrequency].Remove(node);

        if (_minFrequency == oldFrequency && _freqList[oldFrequency].Count == 0) {
            _minFrequency++;
        }

        node.Frequency++;

        EnsureFreqList(node.Frequency);

        _freqList[node.Frequency].AddLast(node);

        return node.Value;
    }

    public void Put(int key, int value) {
        if (_cache.ContainsKey(key)) {
            var node = _cache[key];
            node.Value = value;
            int oldFrequency = node.Frequency;
            _freqList[oldFrequency].Remove(node);

            if (_minFrequency == oldFrequency && _freqList[oldFrequency].Count == 0) {
                _minFrequency++;
            }

            node.Frequency++;

            EnsureFreqList(node.Frequency);
            _freqList[node.Frequency].AddLast(node);
        }
        else {
            if (_cache.Count >= _capacity) {
                if (_freqList[_minFrequency].Count == 0)
                    return;
                var nodeToEvict = _freqList[_minFrequency].First.Value;
                _freqList[_minFrequency].RemoveFirst();
                _cache.Remove(nodeToEvict.Key);
            }

            var newNode = new Node {
                Key = key,
                Value = value,
                Frequency = 1
            };

            _cache[key] = newNode;

            if (!_freqList.ContainsKey(1))
                _freqList[1] = new LinkedList<Node>();

            _freqList[1].AddLast(newNode);
            _minFrequency = 1;
        }
    }

    private void EnsureFreqList(int freq) {
        if (!_freqList.ContainsKey(freq))
            _freqList[freq] = new LinkedList<Node>();
    }
}