## 🧠 0. How to Decide Algorithm Type

Ask these guiding questions:

| Question                              | Strategy                            |
| ------------------------------------- | ----------------------------------- |
| "Is array sorted / can I sort it?"    | Two Pointers, Greedy, Binary Search |
| "Do I scan ranges / substrings?"      | Sliding Window, Prefix Sum          |
| "Need optimal count/min/max result?"  | Dynamic Programming                 |
| "All combinations / all valid paths?" | Backtracking or DFS                 |
| "Shortest path / minimum steps?"      | BFS (especially on grids/graphs)    |
| "Cyclic behavior or repeated state?"  | Fast-Slow Pointers, Floyd’s         |
| "Unique item / bit behavior?"         | Bit Manipulation, XOR               |
| "Graph / tree traversal?"             | DFS/BFS, Recursion                  |

---

## 🔁 1. Two Pointers

**Use When:**

* You're dealing with sorted arrays or palindromes
* Need to **find pairs**, shrink windows, or move from both ends

**Key Phrases:**

* "Find pair that sums to X"
* "Remove duplicates in-place"
* "Compare from both ends"

**Common Pattern:**

* `left++`, `right--` or iterate `j` while fixing `i`

**Examples:**

* Two Sum II (Sorted Input)
* Valid Palindrome
* 3Sum

---

## 🔀 2. Sliding Window

**Use When:**

* You need to find or optimize a **subarray/substring**
* “Longest/Shortest substring that satisfies condition”

**Variants:**

* **Fixed-size**: e.g., max average of size k
* **Dynamic-size**: grow/shrink until condition fails

**Key Phrases:**

* “Substring with...”
* “At most / at least k”
* “No duplicates, distinct elements”

**Examples:**

* Longest Substring Without Repeating Characters
* Minimum Size Subarray Sum
* Permutation in String

---

## 🔁 3. Fast & Slow Pointers (Floyd’s Cycle Detection)

**Use When:**

* You suspect **cycle detection** or **duplicate values** in structure that acts like a list

**Key Phrases:**

* "Detect cycle"
* "Find duplicate without extra space"
* "Find start of cycle"

**Examples:**

* Linked List Cycle
* Find the Duplicate Number
* Happy Number

---

## 🧮 4. Prefix Sum

**Use When:**

* You need to **calculate subarray sums efficiently**
* Repeated sum range queries or target sum checks

**Key Phrases:**

* “Sum of range (i, j)”
* “Number of subarrays with sum K”

**Examples:**

* Subarray Sum Equals K
* Range Sum Query
* Product of Array Except Self

---

## 🔁 5. Sorting

**Use When:**

* You can simplify logic by sorting first
* Often paired with two pointers or greedy

**Key Phrases:**

* “Group items”
* “Min moves”, “Closest pair”, “Earliest time”

**Examples:**

* Merge Intervals
* Meeting Rooms
* Kth Largest Element

---

## 🌲 6. Depth-First Search (DFS)

**Use When:**

* You need to explore **all paths**, trees, or graphs
* Use recursion or explicit stack

**Key Phrases:**

* “Count all paths”, “Can reach X?”
* “Recursive backtracking”

**Examples:**

* Number of Islands
* Clone Graph
* Binary Tree Paths

---

## 🌊 7. Breadth-First Search (BFS)

**Use When:**

* You want the **shortest path** or **minimum steps**
* Graph traversal or grid exploration **level-by-level**

**Key Phrases:**

* “Minimum steps to...”
* “Fewest number of operations”

**Examples:**

* Word Ladder
* Rotting Oranges
* Binary Tree Level Order Traversal

---

## ⛏️ 8. Backtracking

**Use When:**

* You’re **generating combinations**, permutations, or solving **constraint problems**

**Key Phrases:**

* “Find all valid...”
* “Generate all ways...”
* “Return all combinations”

**Examples:**

* N-Queens
* Subsets, Permutations
* Word Search

---

## 📐 9. Dynamic Programming (DP)

**Use When:**

* You can break the problem into **subproblems**
* The problem involves **optimization**: max/min/count

**Key Phrases:**

* “Max profit”, “Min cost”, “Number of ways”

**DP Variants:**

* 1D DP (e.g., Climbing Stairs)
* 2D DP (e.g., Longest Common Subsequence)
* Knapsack-style (capacity, weights)
* State DP (cache by multiple variables)

**Examples:**

* Longest Increasing Subsequence
* House Robber
* Edit Distance

---

## 🔧 10. Greedy

**Use When:**

* You can make **locally optimal decisions** that build to global solution
* Sorting is often a first step

**Key Phrases:**

* “Maximize”, “Minimize”, “Earliest”, “Non-overlapping”

**Examples:**

* Jump Game
* Non-overlapping Intervals
* Gas Station

---

## ⚡ 11. Bit Manipulation

**Use When:**

* You need to **optimize space** or do **binary logic**
* Set, unset, or check bits; XOR tricks

**Key Phrases:**

* “Number appears once”
* “Bitwise trick”
* “Power of two”

**Examples:**

* Single Number
* Counting Bits
* Subsets (binary masks)

---

## 🌳 12. Tree & Graph Recursion

**Use When:**

* You must **traverse, build or reduce** hierarchical data
* Requires bottom-up or top-down analysis

**Examples:**

* Lowest Common Ancestor
* Binary Tree Maximum Path Sum
* Serialize/Deserialize Tree

---

## 🧠 Bonus: Recognizing Binary Search Tricks

Use **Binary Search** on:

* Sorted arrays
* **Answers** (like in "minimum capacity" or "kth element")
* Optimization problems (search for minimum that satisfies a condition)

**Key Phrases:**

* “Minimize the max”
* “Find smallest/largest value such that...”
* “Kth something...”

**Examples:**

* Koko Eating Bananas
* Find Minimum in Rotated Sorted Array
* Median of Two Sorted Arrays

---

