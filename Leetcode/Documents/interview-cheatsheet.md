## 🔁 **1. Two Pointers**

**Use when:**
- You’re working with a **sorted array** or **palindrome**
- Need to find **pairs** or **subarrays** meeting a condition

**Key indicators:**
- "Find pair that sums to target"
- "Compare elements from both ends"
- "In-place operations"

**Common operations:**
- `left++`, `right--` (shrinking)
- One pointer iterates, the other moves as needed

**Examples:**
- `Two Sum II - Input Array Is Sorted`
- `Valid Palindrome`
- `3Sum`
---
## 🔀 **2. Sliding Window**

**Use when:**
- You need to track a **subarray/substring** meeting a dynamic condition
- Look for **longest**, **shortest**, or **fixed length**

**Key indicators:**
- "Substring", "Subarray"
- "At most / at least k", "no duplicates"

**Variants:**
- Fixed window (length `k`)
- Dynamic window (until condition breaks)

**Examples:**
- `Longest Substring Without Repeating Characters`
- `Minimum Size Subarray Sum`
- `Permutation in String`

---
## 🔁 **3. Fast & Slow Pointers (Cycle Detection)**

**Use when:**
- The array or structure acts like a **linked list**
- Need to **detect cycles** or find **entry point**

**Key indicators:**
- "Repeated element"
- "Cycle in linked list"

**Examples:**
- `Linked List Cycle`
- `Find the Duplicate Number` (Floyd’s Algorithm)

---
## 🧮 **4. Prefix Sum**

**Use when:**
- You do **repeated range sum queries**
- Need to check for **subarray conditions**

**Key indicators:**
- "Sum between i and j"
- "Subarrays with a given sum"

**Examples:**
- `Subarray Sum Equals K`
- `Product of Array Except Self`

---

## 🔁 **5. Sorting**

**Use when:**
- You need to simplify comparison, group elements
- You want to make **greedy decisions** or **pairing**

**Key indicators:**
- "Closest", "minimum moves", "group similar"

**Common sorts:**
- `Array.Sort()`
- Custom comparator

**Examples:**
- `Merge Intervals`
- `Meeting Rooms`
- `Kth Largest Element`

---

## 🌲 **6. Depth-First Search (DFS)**

**Use when:**
- You need to **explore all paths**
- Solve **recursively** or simulate **backtracking**
- Graph/tree traversal

**Key indicators:**
- "All paths", "Reachability", "Maze"
- Use with stack or recursion

**Examples:**
- `Number of Islands`
- `Binary Tree Paths`
- `Clone Graph`

---
## 🌊 **7. Breadth-First Search (BFS)**

**Use when:**
- You need to find **shortest path in unweighted graph**
- Explore **level-by-level** or **minimum steps**

**Key indicators:**
- "Fewest moves", "Minimum operations", "Level order"

**Examples:**
- `Word Ladder`
- `Rotting Oranges`
- `Binary Tree Level Order Traversal`

---

## ⛏️ **8. Backtracking**

**Use when:**
- You need to **generate all combinations**
- Problem has **constraints** and **pruning**

**Key indicators:**
- "Find all valid", "Generate all combinations"
- Needs **undoing a choice**

**Examples:**
- `Generate Parentheses`
- `N-Queens`
- `Subsets`, `Permutations`

---

## 📐 **9. Dynamic Programming (DP)**

**Use when:**
- You solve a problem **using previous results**
- Overlapping subproblems
- You’re optimizing for **max/min/count**

**Key indicators:**
- "Max profit", "Min cost", "Number of ways"

**DP types:**
- 1D (e.g., Fibonacci)
- 2D (e.g., Longest Common Subsequence)
- Knapsack-style

**Examples:**
- `Climbing Stairs`
- `House Robber`
- `Longest Palindromic Subsequence`

---

## 🔧 **10. Greedy**

**Use when:**
- You can make **locally optimal choices** that lead to a global solution
- Sorting + decision

**Key indicators:**
- "Minimize", "Maximize", "Earliest", "Last"

**Examples:**
- `Jump Game`
- `Non-overlapping Intervals`
- `Gas Station`

---

## ⚡ **11. Bit Manipulation**

**Use when:**
- Working with **binary digits**, flags, or optimizing space

**Key indicators:**
- "Number appears once"
- "Flip bits", "Set/unset/check bit"

**Examples:**
- `Single Number`
- `Power of Two`
- `Counting Bits`

---

## 🌳 **12. Tree/Graph + Recursion**

**Use when:**
- You must traverse all nodes
- Build or break down based on **recursive structure**

**Examples:**
- `Binary Tree Maximum Path Sum`
- `Lowest Common Ancestor`

---

## 📚 How to Decide in Practice

1. **Is input sorted or can be?**  
   → Consider two pointers or sorting
2. **Need all combinations or explore paths?**  
   → Use backtracking or DFS
3. **Want shortest path / minimum steps?**  
   → Use BFS
4. **Problem has optimal substructure?**  
   → Try dynamic programming
5. **Scan substring or range in array?**  
   → Use sliding window
6. **Just one unmatched item / clever math?**  
   → Try XOR, prefix sums, or bit tricks
---
