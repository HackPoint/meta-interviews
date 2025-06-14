✅ 1. Practice Problems by Complexity Class

| Complexity     | Sample Problem                                                                          | Link                  |
|----------------|-----------------------------------------------------------------------------------------|-----------------------|
| **O(1)**       | [Check if Number is Even](https://leetcode.com/problems/power-of-two/) (constant check) | Basic math            |
| **O(log n)**   | [Binary Search](https://leetcode.com/problems/binary-search/)                           | 🔁 Divide and conquer |
| **O(n)**       | [Maximum Subarray](https://leetcode.com/problems/maximum-subarray/)                     | Kadane's algorithm    |
| **O(n log n)** | [Merge Intervals](https://leetcode.com/problems/merge-intervals/)                       | Sorting involved      |
| **O(n²)**      | [Two Sum - Brute Force](https://leetcode.com/problems/two-sum/)                         | Naive solution        |
| **O(n³)**      | [Brute-force Submatrix Sum](https://leetcode.com/problems/submatrix-sum-queries/)       | 3 nested loops        |
| **O(2ⁿ)**      | [Subsets II](https://leetcode.com/problems/subsets-ii/)                                 | Backtracking          |
| **O(n!)**      | [Permutations](https://leetcode.com/problems/permutations/)                             | All permutations      |
| **O(sqrt(n))** | [Count Primes](https://leetcode.com/problems/count-primes/)                             | Sieve of Eratosthenes |
| **O(kⁿ)**      | [Word Search](https://leetcode.com/problems/word-search/)                               | DFS with pruning      |

✅ 2. Complexity Analysis Walkthrough Checklist
🧮 Use this checklist for every problem:

| Step | Question                                                           |
|------|--------------------------------------------------------------------|
| 1    | How many **layers of loops or recursion**?                         |
| 2    | Are we **copying data** (e.g. `path + [x]`) or modifying in-place? |
| 3    | Are we doing **extra work per node/call** (e.g. sorting, lookup)?  |
| 4    | Are we traversing a tree/graph/list — how many **nodes** total?    |
| 5    | Are we storing intermediate results (e.g. memo, result list)?      |
| 6    | What's the **maximum recursion depth** or call stack?              |
| 7    | Are there **duplicate calls** due to missing memoization?          |
| 8    | Final answer: time = #calls × cost per call?                       |

✅ 3. Visual Recursion Tree Example
Let's say we call dfs(i) that branches into 2 calls unless i == n.

🎄 Recursion Tree for dfs(i) with i < n branching to dfs(i+1) and dfs(i+2):
```scss
dfs(0)
├── dfs(1)
│   ├── dfs(2)
│   │   ├── ...
│   │   └── ...
│   └── dfs(3)
└── dfs(2)
├── ...
└── ...
```
Each level has more calls → total calls grow exponentially → O(2ⁿ)
