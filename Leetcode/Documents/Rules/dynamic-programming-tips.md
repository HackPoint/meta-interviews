Excellent question. Recognizing when a problem is a **Dynamic Programming (DP)** problem is a key skill for Meta-level interviews.

Here’s a checklist and intuition map to **classify a problem as DP**:

---

### ✅ Signs That a Problem Is Dynamic Programming

1. **Optimal Substructure**
   The optimal solution can be formed from optimal solutions to subproblems.
   ➤ In House Robber:

    * The best you can do at house `i` depends on what you could do at `i-1` and `i-2`.

2. **Overlapping Subproblems**
   The same subproblems appear repeatedly.
   ➤ For example, to solve up to house `i`, you need the results of `i-1` and `i-2`.
   These can be reused instead of recomputed.

3. **Choices at Each Step**
   The problem usually involves a decision:

    * Rob this house or skip it?
    * Take this coin or not?
    * Cut here or cut later?

4. **Constraints Hinting at Exponential Brute-Force**
   If naive recursion would be exponential (e.g., trying every combination), DP helps optimize it.

5. **Memoization Feels Natural**
   When solving recursively, do you feel like you’re repeating the same calls? That’s memoization — a core DP tactic.

6. **Can Be Reduced to State(s)**
   You can represent the problem with a few variables:
   E.g. `dp[i] = max money up to house i`.

---

### 🧠 Quick Heuristic for Interview:

> If the problem involves **"max/min/sum of something with constraints or dependencies"**, especially in a sequence → it’s probably DP.

---

### ✅ Let’s Reapply to **House Robber**:

* **Substructure:**
  `dp[i] = max(dp[i-1], dp[i-2] + nums[i])`

* **Overlapping:**
  Every subproblem (like `dp[i-2]`) is reused in multiple higher problems.

* **Decision:**
  Rob `i` and skip `i-1`, or skip `i` and take `dp[i-1]`.

* **Constraint:**
  Can't rob adjacent houses.

✅ All clear signs of DP.

---

Want a cheat sheet for how to distinguish **DP vs Greedy vs Backtracking vs Recursion** in general?
