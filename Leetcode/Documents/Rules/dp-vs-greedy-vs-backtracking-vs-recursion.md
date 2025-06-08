Here’s a concise but powerful 🧠 **cheat sheet** to distinguish between:

---

## 📊 DP vs Greedy vs Backtracking vs Recursion – Interview-Level Cheat Sheet

| Technique                    | Key Clues / Questions                                                                                                                                        | Typical Use Cases                                                                   | Pros                                                        | Cons                                                        |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------ | ----------------------------------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| **Dynamic Programming** (DP) | Can I break the problem into **overlapping subproblems** with **optimal substructure**? <br> Do I need to **store previous results** to avoid recomputation? | Max profit, min cost, count paths, knapsack, LIS, edit distance                     | Very efficient once memoized <br> Handles global optimality | Needs extra space (DP table) <br> More complex to implement |
| **Greedy**                   | Can I always make the **locally optimal choice** and get the global optimum? <br> Is it provable that greedy leads to correct answer?                        | Activity selection, coin change (specific), intervals, Huffman coding, Kruskal/Prim | Fast, often O(n log n) <br> Elegant if correct              | Fails when local ≠ global optimum <br> Needs proof          |
| **Backtracking**             | Is the problem a **combinatorial search**? <br> Do I need to try **all combinations** but **prune invalid paths early**?                                     | Sudoku, N-Queens, Permutations, Subsets, Word Search                                | Finds all solutions <br> Easy to write recursively          | Exponential time in worst-case <br> Prone to TLE            |
| **Plain Recursion**          | Can the problem be solved by breaking it into smaller problems **without memoization**?                                                                      | Tree DFS, divide-and-conquer (e.g., MergeSort), Fibonacci (inefficient)             | Simple and expressive                                       | May be inefficient <br> Often needs DP or pruning           |

---

## 🔍 How to Decide at a Glance

| Question                                                            | If YES, Think...                   |
| ------------------------------------------------------------------- | ---------------------------------- |
| Do subproblems overlap?                                             | ➤ **DP**                           |
| Is the best choice always obvious and safe?                         | ➤ **Greedy**                       |
| Do I need to explore **all paths**, with backtrack/pruning?         | ➤ **Backtracking**                 |
| Can I just split the task recursively without worrying about reuse? | ➤ **Recursion / Divide & Conquer** |

---

## 🧠 Meta Interview Tip:

When stuck, ask yourself:

* "Can I solve a smaller version of this problem?"
* "Does this smaller solution help build the big one?"
* "Am I recalculating the same thing?"
* "Can I prove greedy choices lead to the best result?"

---

