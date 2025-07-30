## LeetCode Algorithmic Patterns & Approaches (Complete & Consistent)

---

### 1. Sliding Window

* **Description**: Maintain a dynamic window using two pointers. Expand and shrink window to maintain a condition on a subarray or substring.
* **When to Apply**: Contiguous subarrays/substrings with specific conditions.
* **Common Keywords**: "window", "longest substring", "at most", "subarray of length k"

```csharp
int left = 0;
for (int right = 0; right < s.Length; right++) {
    // expand window
    while (/* invalid condition */) {
        left++; // shrink window
    }
    // process result
}
```

---

### 2. Two Pointers

* **Description**: Use two pointers from ends or same end to solve pair problems or array manipulations.
* **When to Apply**: Palindromes, remove duplicates, in-place merging.
* **Common Keywords**: "sorted array", "remove duplicates", "reverse"

```csharp
int left = 0, right = arr.Length - 1;
while (left < right) {
    if (arr[left] + arr[right] < target) left++;
    else right--;
}
```

---

### 3. Kadane's Algorithm

* **Description**: Find maximum sum of contiguous subarray using dynamic tracking.
* **When to Apply**: Max subarray sum.
* **Common Keywords**: "maximum sum", "contiguous"

```csharp
int maxSoFar = nums[0], maxEndingHere = nums[0];
for (int i = 1; i < nums.Length; i++) {
    maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
    maxSoFar = Math.Max(maxSoFar, maxEndingHere);
}
```

---

### 4. Prefix Sum

* **Description**: Precompute cumulative sums to answer range queries in O(1).
* **When to Apply**: Range sum, subarray sum.
* **Common Keywords**: "range sum", "subarray sum"

```csharp
int[] prefix = new int[nums.Length + 1];
for (int i = 0; i < nums.Length; i++) {
    prefix[i + 1] = prefix[i] + nums[i];
}
// sum from i to j: prefix[j + 1] - prefix[i]
```

---

### 5. Binary Search

* **Description**: Efficiently search or optimize within sorted/monotonic data.
* **When to Apply**: Sorted arrays, find min/max, decision problems.
* **Common Keywords**: "sorted", "minimize", "maximum"

```csharp
int left = 0, right = nums.Length - 1;
while (left <= right) {
    int mid = left + (right - left) / 2;
    if (nums[mid] == target) return mid;
    else if (nums[mid] < target) left = mid + 1;
    else right = mid - 1;
}
```

---

### 6. Bit Manipulation

* **Description**: Use bit operations to solve problems related to binary data or uniqueness.
* **When to Apply**: XOR uniqueness, masking, counting bits.
* **Common Keywords**: "XOR", "bit", "mask"

```csharp
int xor = 0;
for (int i = 0; i < nums.Length; i++) {
    xor ^= nums[i];
}
```

---

### 7. 1D Dynamic Programming

* **Description**: Solve recursively-defined problems with memoization or tabulation.
* **When to Apply**: Fib-style, counting paths, coin change.
* **Common Keywords**: "ways to", "min steps", "max sum"

```csharp
int[] dp = new int[n + 1];
dp[0] = 1;
for (int i = 1; i <= n; i++) {
    dp[i] = dp[i - 1] + dp[i - 2];
}
```

---

### 8. Backtracking

* **Description**: Try all combinations recursively, revert if invalid.
* **When to Apply**: All combinations, permutations.
* **Common Keywords**: "generate all", "backtrack"

```csharp
void Backtrack(List<int> path) {
    if (/* base case */) {
        result.Add(new(path));
        return;
    }
    foreach (var choice in choices) {
        path.Add(choice);
        Backtrack(path);
        path.RemoveAt(path.Count - 1);
    }
}
```

---

### 9. Union-Find

* **Description**: Maintain disjoint sets with efficient merges.
* **When to Apply**: Graph connectivity, cycles.
* **Common Keywords**: "union", "find", "connected"

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

* **Description**: Use a stack to maintain increasing/decreasing elements.
* **When to Apply**: Next greater/smaller element, histogram.
* **Common Keywords**: "next greater", "stock span"

```csharp
Stack<int> stack = new();
for (int i = 0; i < nums.Length; i++) {
    while (stack.Count > 0 && nums[i] > nums[stack.Peek()]) {
        int idx = stack.Pop();
    }
    stack.Push(i);
}
```

---

### 11. Topological Sort

* **Description**: Linear ordering of a DAG’s nodes respecting dependencies.
* **When to Apply**: Course scheduling, task dependency.
* **Common Keywords**: "prerequisite", "order", "schedule"

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
    foreach (int nei in graph[node]) {
        if (--indegree[nei] == 0) queue.Enqueue(nei);
    }
}
```

---

### 12. Trie (Prefix Tree)

* **Description**: A tree for storing prefixes of strings.
* **When to Apply**: Autocomplete, word search.
* **Common Keywords**: "starts with", "prefix search"

```csharp
class TrieNode {
    public Dictionary<char, TrieNode> Children = new();
    public bool IsEnd = false;
}
class Trie {
    TrieNode root = new();
    public void Insert(string word) {
        var node = root;
        foreach (var c in word) {
            if (!node.Children.ContainsKey(c))
                node.Children[c] = new();
            node = node.Children[c];
        }
        node.IsEnd = true;
    }
}
```

---

### 13. Graph BFS / DFS

* **Description**: Traverse graphs using breadth-first or depth-first strategies.
* **When to Apply**: Reachability, traversal, components.
* **Common Keywords**: "graph", "traverse", "reach"

```csharp
// BFS
Queue<int> q = new();
HashSet<int> visited = new();
q.Enqueue(start);
visited.Add(start);
while (q.Count > 0) {
    var node = q.Dequeue();
    foreach (var nei in graph[node]) {
        if (!visited.Contains(nei)) {
            visited.Add(nei);
            q.Enqueue(nei);
        }
    }
}
```

---

### 14. Heap / Priority Queue

* **Description**: Maintain order by priority for min/max problems.
* **When to Apply**: Top-K, streaming median.
* **Common Keywords**: "kth largest", "min heap", "priority"

```csharp
PriorityQueue<int, int> heap = new();
foreach (var num in nums) heap.Enqueue(num, num);
int top = heap.Dequeue();
```

---

### 15. Greedy

* **Description**: Always choose best local option, hoping for global optimal.
* **When to Apply**: Scheduling, intervals.
* **Common Keywords**: "minimum", "maximize"

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

* **Description**: Split input and combine results from halves.
* **When to Apply**: Subsets, brute-force limits.
* **Common Keywords**: "subset sum", "combination"

```csharp
List<int> SubsetSums(int[] arr) {
    List<int> result = new() { 0 };
    foreach (var x in arr) {
        int count = result.Count;
        for (int i = 0; i < count; i++)
            result.Add(result[i] + x);
    }
    return result;
}
```

---

### 17. Bitmask DP

* **Description**: Encode state in bits for DP.
* **When to Apply**: Subsets, visited states.
* **Common Keywords**: "bitmask", "state"

```csharp
Dictionary<(int, int), int> memo = new();
int Dp(int mask, int pos) {
    if (/* base case */) return 1;
    if (memo.ContainsKey((mask, pos))) return memo[(mask, pos)];
    int res = 0;
    // try options
    memo[(mask, pos)] = res;
    return res;
}
```

---

### 18. Sliding Window Maximum (Deque)

* **Description**: Maintain max/min in window using deque.
* **When to Apply**: Max/min in window of k.
* **Common Keywords**: "max in window", "sliding window max"

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

* **Description**: Sample k elements from stream with equal probability.
* **When to Apply**: Streaming, unknown length.
* **Common Keywords**: "random from stream"

```csharp
int? selected = null;
int count = 0;
foreach (var item in stream) {
    count++;
    if (Random.Shared.Next(count) == 0) selected = item;
}
```

---

### 20. Floyd’s Cycle Detection

* **Description**: Detect cycle in linked list via two pointers.
* **When to Apply**: Repeated states, cycles.
* **Common Keywords**: "loop", "cycle"

```csharp
ListNode slow = head, fast = head;
while (fast != null && fast.Next != null) {
    slow = slow.Next;
    fast = fast.Next.Next;
    if (slow == fast) return true;
}
return false;
```


