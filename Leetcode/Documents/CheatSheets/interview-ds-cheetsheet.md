Perfect. Knowing **when to choose the right data structure** is just as crucial as selecting the right algorithm.

Below is a structured guide that explains:
1. **When to use each data structure**
2. **Why it’s optimal**
3. **Typical problem types where it's best**

---

## 📦 1. **Array / List (`int[]`, `List<T>`)**

### ✅ Use When:

- You need **constant-time indexing**
- You know the **exact size or max size** in advance
- Order matters, and you want **contiguous memory**

### 🧠 Recognize In Problems:

- “Find max sum in subarray”
- “Return list in order”
- “Sliding window problems”

### 🔍 Time:

|Operation|Time|
|---|---|
|Access by index|O(1)|
|Insert/remove|O(n)|
### ✅ Examples:

- `Max Subarray` (Kadane's)
- `Sliding Window Maximum`
- `Container With Most Water`

---

## 🔢 2. **HashMap / Dictionary (`Dictionary<TKey, TValue>`)**

### ✅ Use When:
- You need **fast lookups** or **counting**
- You want to **track frequency or position**
- Keys are unique and need fast access

### 🧠 Recognize In Problems:
- “Find first non-repeating character”
- “Track index where element was last seen”
- “Count elements that meet condition”

### 🔍 Time:

|Operation|Time|
|---|---|
|Insert/Get|O(1)|
|Space|O(n)|

### ✅ Examples:

- `Two Sum`
- `Longest Substring Without Repeating Characters`
- `Group Anagrams`

---

## 🔁 3. **HashSet / `HashSet<T>`**

### ✅ Use When:

- You need to **track uniqueness**
- Check **"have I seen this before?"**
- No need for values or indexing
### 🧠 Recognize In Problems:

- “Contains duplicates?”
- “Find cycle or seen states”

### 🔍 Time:

|Operation|Time|
|---|---|
|Insert/Check|O(1)|

### ✅ Examples:
- `Contains Duplicate`
- `Happy Number`
- `Linked List Cycle`

---

## 📚 4. **Stack (`Stack<T>`)**

### ✅ Use When:
- You need **Last-In-First-Out (LIFO)** behavior
- Track **open/close characters**, recursion, or **undo**

### 🧠 Recognize In Problems:
- “Valid parentheses”
- “Evaluate expressions”
- “Backtrack on removal”

### 🔍 Time:
| Push/Pop/Peek | O(1) |

### ✅ Examples:
- `Valid Parentheses`
- `Min Stack`
- `Daily Temperatures`

---

## 🚦 5. **Queue (`Queue<T>`) / Deque**

### ✅ Use When:
- You need **First-In-First-Out (FIFO)**
- Process in **level order** (like BFS)
- Sliding window with max/min

### 🧠 Recognize In Problems:
- “Shortest path”, “minimum operations”
- “Process level by level”

### 🔍 Time:

| Enqueue/Dequeue | O(1) |

### ✅ Examples:

- `Binary Tree Level Order Traversal`
- `Sliding Window Maximum` (Deque)
- `Rotting Oranges`

---

## 🌳 6. **Tree (BinaryTree, BST)**

### ✅ Use When:
- Hierarchical structure
- You need **ordered data**, parent/child
- Searching with divide-and-conquer

### 🧠 Recognize In Problems:
- “Inorder/Preorder traversal”
- “Lowest common ancestor”
- “Sorted structure but with hierarchy”

### ✅ Examples:
- `Validate BST`
- `Max Path Sum`
- `Kth Smallest in BST`

---

## 🌐 7. **Graph (`Adjacency List`, `Matrix`)**

### ✅ Use When:

- You model **relationships** between nodes
- Need **DFS/BFS**, shortest paths, or **connectivity**

### 🧠 Recognize In Problems:
- “Connected cities/networks”
- “Can visit all rooms?”
- “Find shortest path with obstacles”

### ✅ Examples:

- `Number of Islands`
- `Course Schedule`
- `Clone Graph`

---

## 🪜 8. **Trie (Prefix Tree)**

### ✅ Use When:

- You need **prefix search** / autocomplete
- Searching through many strings efficiently
- Repeated queries

### 🧠 Recognize In Problems:
- “StartsWith”
- “Suggest queries”
- “Count prefix matches”

### ✅ Examples:
- `Implement Trie`
- `Word Search II`
- `Longest Word in Dictionary`

---

## 🧮 9. **Heap / PriorityQueue**

### ✅ Use When:
- You need to **get the smallest/largest** quickly
- Streaming max/min over time

### 🧠 Recognize In Problems:
- “Kth largest element”
- “Schedule by order of priority”
- “Merge sorted lists”
### ✅ Examples:
- `Kth Largest Element in Array`
- `Merge K Sorted Lists`
- `Median from Data Stream`

---

## 🔁 10. **Linked List**

### ✅ Use When:
- You need **constant-time insertion/removal** from middle/head
- No need for random access
- Simulate memory pointers

### 🧠 Recognize In Problems:
- “Reverse list”
- “Cycle detection”
- “Merge K sorted lists (in-place)”

### ✅ Examples:
- `Reverse Linked List`
- `Linked List Cycle`
- `Add Two Numbers`

---

## ✅ Decision Table (Quick View)

|Use Case|Data Structure|
|---|---|
|Random access, ordered values|Array / List|
|Track frequency / lookup values|Dictionary|
|Check if element exists (unique)|HashSet|
|LIFO processing|Stack|
|FIFO processing / level order|Queue / Deque|
|Parent/child, hierarchy|Tree|
|Prefix or autocomplete|Trie|
|Process by priority|PriorityQueue / Heap|
|Sequence manipulation, pointers|Linked List|
|Connectivity, paths, neighbors|Graph (Adjacency list)|

---

## 👨‍🏫 How to Practice Choosing

1. Start from the **input** type and question:
    - Is it a list of numbers? → Array
    - Does it mention keys/values? → Dictionary
    - Mentions "unique" or "duplicates"? → HashSet
2. Match with the **required operations** (e.g., "fast lookup", "reverse", "level order", etc.)
3. Use this guide until your brain **automatically connects problem statements to structure**.

---
