using Leetcode.Easy.DFS;
using Xunit;

namespace Leetcode.Medium.Backtracking;

/// <summary>
/// 1593. Split a String Into the Max Number of Unique Substrings
/// ✅ Approach:
/// Use DFS backtracking with a HashSet to keep track of used substrings.
/// Try every possible split starting from the current index, skipping if the substring is already in the set.
/// Keep track of the maximum unique count found.
/// 
/// 🕒 Time Complexity: O(2^n) worst case, but n ≤ 16 so it passes.
/// 🗄 Space Complexity: O(n) for recursion depth + HashSet storage.
/// 📌 Notes:
/// - Pruning: If remaining characters + current count can't beat the best, stop exploring that branch.
/// - Order matters: Only forward splits are allowed.
/// </summary>
public class SplitStringIntoMaxUniqueSubstrings
{
    public int MaxUniqueSplit(string s)
    {
        int n = s.Length, best = 0;
        var used = new HashSet<string>();

        void Dfs(int i)
        {
            if (i == n) { best = Math.Max(best, used.Count); return; }
            if (used.Count + (n - i) <= best) return; // correct pruning

            for (int j = i + 1; j <= n; j++)
            {
                var sub = s.Substring(i, j - i);
                if (used.Add(sub)) { Dfs(j); used.Remove(sub); }
            }
        }

        Dfs(0);
        return best;
    }
}

public class SplitStringUniqueSubstringsTests
{
    [Fact]
    public void Example1()
    {
        var s = new SplitStringIntoMaxUniqueSubstrings();
        Assert.Equal(5, s.MaxUniqueSplit("ababccc")); // Example from LC
    }

    [Fact]
    public void Example2()
    {
        var s = new SplitStringIntoMaxUniqueSubstrings();
        Assert.Equal(2, s.MaxUniqueSplit("aba"));
    }

    [Fact]
    public void SingleCharacter()
    {
        var s = new SplitStringIntoMaxUniqueSubstrings();
        Assert.Equal(1, s.MaxUniqueSplit("a"));
    }

    [Fact]
    public void AllCharactersUnique()
    {
        var s = new SplitStringIntoMaxUniqueSubstrings();
        Assert.Equal(6, s.MaxUniqueSplit("abcdef"));
    }
}