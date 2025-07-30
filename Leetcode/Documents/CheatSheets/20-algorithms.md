## LeetCode Algorithmic Patterns & Approaches


### 1. Sliding Window

* **Description**: Maintain a moving window over the array using two pointers. Adjust window size dynamically to satisfy a condition.
* **When to Apply**: Problems involving contiguous sequences and dynamic subarrays or substrings.
* **Common Keywords**: "subarray of length k", "at most", "longest substring", "window"

```csharp
int left = 0;
for (int right = 0; right < s.Length; right++) {
    // expand window
    while (/* condition invalid */) {
        // shrink from left
        left++;
    }
    // update result here
}
```

---

### 2. Two Pointers

* **Description**: Use two pointers to traverse the array either in opposite directions or from the same end to check pairs or conditions.
* **When to Apply**: Sorted arrays, palindrome checks, in-place merging.
* **Common Keywords**: "sorted array", "remove duplicates", "palindrome", "reverse"

```csharp
int left = 0, right = arr.Length - 1;
while (left < right) {
    if (arr[left] + arr[right] < target) left++;
    else right--;
}
```

---

### 3. Kadane's Algorithm

* **Description**: Track the max subarray sum by keeping current sum and global max updated as you iterate.
* **When to Apply**: Finding max sum of contiguous subarray.
* **Common Keywords**: "maximum sum subarray", "contiguous"

```csharp
int maxSoFar = nums[0], maxEndingHere = nums[0];
for (int i = 1; i < nums.Length; i++) {
    maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
    maxSoFar = Math.Max(maxSoFar, maxEndingHere);
}
return maxSoFar;
```

---

### 4. Prefix Sum

* **Description**: Build prefix sums to quickly calculate any range sum in O(1).
* **When to Apply**: Fast sum queries, subarray sums, range-based computations.
* **Common Keywords**: "range sum", "difference array", "subarray sum"

```csharp
int[] prefix = new int[nums.Length + 1];
for (int i = 0; i < nums.Length; i++) {
    prefix[i + 1] = prefix[i] + nums[i];
}
// sum from i to j: prefix[j + 1] - prefix[i]
```

---

### 5. Binary Search

* **Description**: Search a sorted array or optimize an answer by repeatedly halving the search range.
* **When to Apply**: Sorted arrays, optimization (min/max), answer space binary search.
* **Common Keywords**: "sorted", "binary search", "minimize", "maximum value"

```csharp
int left = 0, right = nums.Length - 1;
while (left <= right) {
    int mid = left + (right - left) / 2;
    if (nums[mid] == target) return mid;
    else if (nums[mid] < target) left = mid + 1;
    else right = mid - 1;
}
return -1;
```

---

### 6. Bit Manipulation

* **Description**: Use XOR, masking or shifting to solve problems with binary representation or unique numbers.
* **When to Apply**: Single number, bit counting, binary states.
* **Common Keywords**: "bit", "XOR", "mask", "binary"

```csharp
int xor = nums.Length;
for (int i = 0; i < nums.Length; i++) {
    xor ^= i ^ nums[i];
}
return xor;
```

---

### 7. Dynamic Programming (1D)

* **Description**: Solve problems by breaking them into subproblems and storing solutions in a table.
* **When to Apply**: Problems with overlapping subproblems and optimal substructure.
* **Common Keywords**: "number of ways", "minimum steps", "maximum value"

```csharp
int[] dp = new int[n + 1];
dp[0] = 1;
for (int i = 1; i <= n; i++) {
    dp[i] = dp[i - 1] + dp[i - 2];
}
return dp[n];
```

---

### 8. Backtracking

* **Description**: Explore all possible combinations recursively by making a decision, backtracking, and trying the next.
* **When to Apply**: Generate all permutations, combinations, or paths.
* **Common Keywords**: "all combinations", "generate", "backtrack", "permutation"

```csharp
void Backtrack(List<int> path, int[] options) {
    if (path.Count == targetLength) {
        result.Add(new List<int>(path));
        return;
    }
    foreach (var option in options) {
        path.Add(option);
        Backtrack(path, options);
        path.RemoveAt(path.Count - 1);
    }
}
```

---

### 9. Union-Find (Disjoint Set)

* **Description**: Efficiently track connected components with path compression.
* **When to Apply**: Connected components, grouping, dynamic connectivity.
* **Common Keywords**: "connected", "union", "find", "cycle detection"

```csharp
int Find(int x) {
    if (parent[x] != x) parent[x] = Find(parent[x]);
    return parent[x];
}
void Union(int x, int y) {
    parent[Find(x)] = Find(y);
}
```

---

### 10. Monotonic Stack

* **Description**: Stack that maintains increasing or decreasing order to solve next/previous greater/smaller element problems.
* **When to Apply**: Histogram, sliding window min/max, next greater element.
* **Common Keywords**: "next greater", "stock span", "largest rectangle"

```csharp
Stack<int> stack = new();
for (int i = 0; i < nums.Length; i++) {
    while (stack.Count > 0 && nums[i] > nums[stack.Peek()]) {
        int idx = stack.Pop();
        // process idx and nums[i]
    }
    stack.Push(i);
}
```

### 11. Topological Sort (Kahn's or DFS)

* **Description**: Determine the linear ordering of a Directed Acyclic Graph (DAG) based on dependencies.
* **When to Apply**: Task scheduling, dependency resolution, ordering.
* **Common Keywords**: "prerequisite", "order", "schedule", "dependency"

```csharp
int[] indegree = new int[n];
List<int>[] graph = new List<int>[n];
for (int i = 0; i < n; i++) graph[i] = new();
foreach (var edge in edges) {
    graph[edge[0]].Add(edge[1]);
    indegree[edge[1]]++;
}
Queue<int> queue = new();
for (int i = 0; i < n; i++) if (indegree[i] == 0) queue.Enqueue(i);
while (queue.Count > 0) {
    int node = queue.Dequeue();
    foreach (int neighbor in graph[node]) {
        if (--indegree[neighbor] == 0) queue.Enqueue(neighbor);
    }
}
```

---

### 12. Trie (Prefix Tree)

* **Description**: Tree data structure for efficient prefix-based word operations.
* **When to Apply**: Dictionary, autocomplete, prefix lookup.
* **Common Keywords**: "starts with", "word search", "dictionary"

```csharp
class TrieNode {
    public Dictionary<char, TrieNode> Children = new();
    public bool IsEnd = false;
}
class Trie {
    private TrieNode root = new();
    public void Insert(string word) {
        var node = root;
        foreach (char c in word) {
            if (!node.Children.ContainsKey(c)) node.Children[c] = new TrieNode();
            node = node.Children[c];
        }
        node.IsEnd = true;
    }
    public bool Search(string word) {
        var node = root;
        foreach (char c in word) {
            if (!node.Children.ContainsKey(c)) return false;
            node = node.Children[c];
        }
        return node.IsEnd;
    }
}
```

---

### 13. Graph BFS/DFS

* **Description**: Explore all nodes in a graph using breadth-first or depth-first strategies.
* **When to Apply**: Graph traversal, shortest path, connected components.
* **Common Keywords**: "graph", "traverse", "reachable", "shortest path"

```csharp
// BFS
Queue<int> queue = new();
HashSet<int> visited = new();
queue.Enqueue(start);
visited.Add(start);
while (queue.Count > 0) {
    int node = queue.Dequeue();
    foreach (int neighbor in graph[node]) {
        if (!visited.Contains(neighbor)) {
            visited.Add(neighbor);
            queue.Enqueue(neighbor);
        }
    }
}
```

---

### 14. Heap / Priority Queue

* **Description**: Maintain a data structure to access the highest or lowest priority element in O(log n) time.
* **When to Apply**: Top-K, streaming median, best-first search.
* **Common Keywords**: "kth largest", "median", "priority"

```csharp
PriorityQueue<int, int> minHeap = new();
foreach (var num in nums) minHeap.Enqueue(num, num);
int smallest = minHeap.Dequeue();
```

---

### 15. Greedy

* **Description**: Make the best local choice at each step in hope of global optimum.
* **When to Apply**: Interval scheduling, resource allocation.
* **Common Keywords**: "minimum number of", "maximize profit", "earliest/latest"

```csharp
intervals.Sort((a, b) => a[1].CompareTo(b[1]));
int count = 0, end = int.MinValue;
foreach (var interval in intervals) {
    if (interval[0] >= end) {
        count++;
        end = interval[1];
    }
}
```

---

### 16. Meet in the Middle

* **Description**: Split input into halves and combine results to reduce time complexity.
* **When to Apply**: Subset problems, when full brute-force is too slow.
* **Common Keywords**: "subset sum", "combination sum", "partition"

```csharp
List<int> GenerateSubsetSums(int[] arr) {
    List<int> result = new() { 0 };
    foreach (int num in arr) {
        int count = result.Count;
        for (int i = 0; i < count; i++) {
            result.Add(result[i] + num);
        }
    }
    return result;
}
```

---

### 17. Bitmask DP

* **Description**: Use bit representation to encode state for DP and reduce space/time.
* **When to Apply**: Subset enumeration, state compression, permutations.
* **Common Keywords**: "state", "bitmask", "visited set", "dp on subsets"

```csharp
Dictionary<(int, int), int> memo = new();
int Dp(int mask, int pos) {
    if (/* base case */) return 1;
    if (memo.ContainsKey((mask, pos))) return memo[(mask, pos)];
    int result = 0;
    // try all options
    memo[(mask, pos)] = result;
    return result;
}
```
---

### 18. Sliding Window Maximum (Deque)

* **Description**: Use deque to maintain useful elements for max-in-window.
* **When to Apply**: Fixed-size sliding max/min problems.
* **Common Keywords**: "maximum of window size k", "range max"

```csharp
LinkedList<int> deque = new();
List<int> result = new();
for (int i = 0; i < nums.Length; i++) {
    if (deque.Count > 0 && deque.First.Value <= i - k) deque.RemoveFirst();
    while (deque.Count > 0 && nums[i] >= nums[deque.Last.Value]) deque.RemoveLast();
    deque.AddLast(i);
    if (i >= k - 1) result.Add(nums[deque.First.Value]);
}
```

---

### 19. Reservoir Sampling

* **Description**: Pick random element from a stream with equal probability using constant space.
* **When to Apply**: Stream processing, unknown length data.
* **Common Keywords**: "random from stream", "constant space sampling"

```csharp
int? selected = null;
int count = 0;
foreach (var item in stream) {
    count++;
    if (Random.Shared.Next(count) == 0) selected = item;
}
```

---

### 20. Floyd's Cycle Detection

* **Description**: Detect a cycle in linked list using fast and slow pointer.
* **When to Apply**: Linked list cycles, repeated states.
* **Common Keywords**: "loop", "cycle", "repetition", "circular list"

```csharp
ListNode slow = head, fast = head;
while (fast != null && fast.Next != null) {
    slow = slow.Next;
    fast = fast.Next.Next;
    if (slow == fast) return true;
}
return false;
```

---
