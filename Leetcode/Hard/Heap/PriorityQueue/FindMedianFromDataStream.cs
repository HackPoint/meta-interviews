namespace Leetcode.Hard.Heap.PriorityQueue;


/// <summary>
/// ✅ Classification: Heap, Design, Data Stream
/// ✅ Algorithm: Two Heaps (MaxHeap + MinHeap)
///
/// ✅ Explanation:
/// Maintains two heaps:
/// - MaxHeap (`low`) for the smaller half of numbers
/// - MinHeap (`high`) for the larger half of numbers
/// 
/// Invariant:
/// - Size of `low` is always ≥ `high`
/// - All elements in `low` ≤ all elements in `high`
/// 
/// Steps:
/// 1. Add number to the correct heap (based on value vs `low.Peek()`).
/// 2. Rebalance heaps so the size invariant holds.
/// 3. Median is:
///     - top of `low` if odd count
///     - average of tops if even count
/// 
/// This approach avoids sorting the entire stream each time.
/// 
/// ✅ Time Complexity:
/// - AddNum:     O(log n)
/// - FindMedian: O(1)
///
/// ✅ Space Complexity:
/// - O(n) total for storing all inserted numbers
/// 
/// 🔁 Use Case:
/// Real-time median tracking for dynamic data (e.g., sensor readings, live logs).
/// </summary>
public class MedianFinder {
    private readonly PriorityQueue<int, int> _low = new();
    private readonly PriorityQueue<int, int> _high = new();

    public void AddNum(int num) {
        if(_low.Count == 0 || num <= _low.Peek()) {
            _low.Enqueue(num, -num);
        } else {
            _high.Enqueue(num, num);
        }

        if(_low.Count > _high.Count + 1) {
            int moved = _low.Dequeue();
            _high.Enqueue(moved, moved);
        }

        if(_high.Count > _low.Count) {
            int moved = _high.Dequeue();
            _low.Enqueue(moved, -moved);
        }
    }
    
    public double FindMedian() {
        if(_low.Count == _high.Count) {
            return (_low.Peek() + _high.Peek()) / 2.0;
        }
        return _low.Peek();
    }
}