✅ 1D DP Template 

```csharp
// <summary>
/// Universal 1D DP template for problems with linear state transitions.
/// You define:
/// • Base cases (e.g. dp[0], dp[1])
/// • Recurrence relation (e.g. dp[i] = f(dp[i-1], dp[i-2], ..., input[i]))
/// • Transition direction (forward or backward)
///
/// Time Complexity: O(n)
/// Space Complexity: O(n) → can be optimized to O(1) if only last k states are needed
/// </summary>
public int SolveDP(int[] input) {
    int n = input.Length;
    if (n == 0) return 0;

    // Step 1: Define DP array (or 2 variables if optimized)
    int[] dp = new int[n + 1];

    // Step 2: Initialize base cases
    dp[0] = <initial_value>;  // often 1 or 0
    dp[1] = <depends_on_problem>; // base case for index 1 (if needed)

    // Step 3: Build up the solution
    for (int i = 2; i <= n; i++) {
        // Typical transitions, customize for your recurrence
        if (<condition using input[i - 1]>) {
            dp[i] += dp[i - 1];
        }
        if (i >= 2 && <condition using input[i - 2] and input[i - 1]>) {
            dp[i] += dp[i - 2];
        }
    }

    // Step 4: Return result
    return dp[n];
}

```

| Component         | What You Should Define                     |
|-------------------|--------------------------------------------|
| `dp[i]`           | Meaning of state (e.g., ways to reach i)   |
| `dp[0]` / `dp[1]` | Base cases (empty string, 1st step, etc.)  |
| Transition        | `dp[i] = dp[i - 1] + dp[i - 2]` or similar |
| Boundary checks   | Prevent negative indices or invalid inputs |
| Optimizations     | Use 2 variables if only last states needed |


### 🔁 Optimized Space Template (O(1) space)

```csharp
public int SolveDP_Optimized(int[] input) {
    int n = input.Length;
    if (n == 0) return 0;

    int prev = <dp[0]>;
    int curr = <dp[1]>;

    for (int i = 2; i <= n; i++) {
        int next = 0;

        if (<condition>) {
            next += curr;
        }
        if (<condition>) {
            next += prev;
        }

        prev = curr;
        curr = next;
    }

    return curr;
}

```