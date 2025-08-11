using Xunit;

namespace Leetcode.Easy.Strings;

/// <summary>
/// 942. DI String Match
///
/// Problem:
/// Given a string s of length n consisting of 'I' (increase) and 'D' (decrease),
/// construct a permutation of [0..n] (n+1 distinct integers) such that:
///   - If s[i] == 'I' then perm[i]   < perm[i+1]
///   - If s[i] == 'D' then perm[i]   > perm[i+1]
///
/// Approach (Short, Easy, Fast):
/// - Two-pointer greedy with a low/high window over the remaining numbers.
/// - Initialize low = 0, high = n. For each i in [0..n-1]:
///     - If s[i] == 'I' → perm[i] = low;  low++
///     - Else ('D')     → perm[i] = high; high--
/// - After the loop, assign perm[n] = low (which equals high).
///
/// Why correct:
/// - At step i, choosing the current min or max guarantees we can still satisfy
///   all remaining constraints, and the chosen value immediately satisfies s[i].
/// - low and high always bound the unused numbers; they converge by 1 each step.
/// - Distinctness holds (we never reuse numbers), and final slot is the last value.
///
/// Time Complexity: O(n) — single pass.
/// Space Complexity: O(1) extra — output array of size n+1.
///
/// Example:
/// s = "IDID" (n=4)
/// low=0, high=4 → [I→0, D→4, I→1, D→3], last=2 → [0,4,1,3,2]
/// </summary>
public class DIStringMatch {
    public int[] DiStringMatch(string s) {
        int[] perm = new int[s.Length + 1];
        int low = 0, high = s.Length;

        for(int i = 0; i < s.Length; i++) {
            if(s[i] == 'I') {
                perm[i] = low++;
            } else {
                perm[i] = high--;
            }

        }

        perm[s.Length] = low;
        return perm;
    }
}

public class DiStringMatchTests
{
    // Adapter: update if your implementation class/method is named differently.
    private static int[] Solve(string s) => new DIStringMatch().DiStringMatch(s);

    private static void AssertValid(string s, int[] a)
    {
        // 1) a must be a permutation of 0..n
        int n = s.Length;
        Assert.Equal(n + 1, a.Length);
        var expected = Enumerable.Range(0, n + 1).OrderBy(x => x).ToArray();
        var actual = a.OrderBy(x => x).ToArray();
        Assert.Equal(expected, actual);

        // 2) inequalities must hold
        for (int i = 0; i < n; i++)
        {
            if (s[i] == 'I') Assert.True(a[i] < a[i + 1], $"Expected a[{i}] < a[{i+1}]");
            else             Assert.True(a[i] > a[i + 1], $"Expected a[{i}] > a[{i+1}]");
        }
    }

    [Theory]
    [InlineData("")]
    [InlineData("I")]
    [InlineData("D")]
    [InlineData("ID")]
    [InlineData("DI")]
    [InlineData("III")]
    [InlineData("DDD")]
    [InlineData("IDID")]
    [InlineData("DIDI")]
    public void BasicPatterns_ShouldProduceValidPermutation(string s)
    {
        var res = Solve(s);
        AssertValid(s, res);
    }

    [Fact]
    public void Example_IDID_ShouldMatchKnownValid()
    {
        string s = "IDID";
        var res = Solve(s);
        AssertValid(s, res);
        // One known valid answer is [0,4,1,3,2]; your solution may return another valid one.
        // We only assert correctness via constraints/permutation.
    }

    [Fact]
    public void LongAllI_ShouldBeStrictlyIncreasing()
    {
        string s = new string('I', 200);
        var res = Solve(s);
        AssertValid(s, res);
        for (int i = 0; i < s.Length; i++) Assert.True(res[i] < res[i + 1]);
    }

    [Fact]
    public void LongAllD_ShouldBeStrictlyDecreasing()
    {
        string s = new string('D', 200);
        var res = Solve(s);
        AssertValid(s, res);
        for (int i = 0; i < s.Length; i++) Assert.True(res[i] > res[i + 1]);
    }
}