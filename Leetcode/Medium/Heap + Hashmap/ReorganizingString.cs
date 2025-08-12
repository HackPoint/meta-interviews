using Xunit;

namespace Leetcode.Medium.Heap___Hashmap;
/// <summary>
/// ✅ Rearranges characters so no two adjacent are the same.
/// ❌ Returns empty string if impossible.
///
/// 🛠 Approach:
/// 1. Count char frequencies (ASCII).
/// 2. If any freq > (n+1)/2 → impossible.
/// 3. Sort chars by frequency desc.
/// 4. Greedy: fill even indices first, then odd.
///
/// ⏱ Time: O(n + A log A), A=128 for ASCII.
/// 💾 Space: O(A).
///
/// 🧩 Example:
/// Input:  "aab"
/// Freq:   a=2, b=1 → sorted: a,b
/// Fill:   [a,_,a] → pos=0,2, then odd pos=1→b → "aba"
/// Output: "aba"
/// </summary>
public class ReorganizingString
{
    public string ReorganizeString(string s)
    {
        int n = s.Length;
        if (n <= 1) return s;

        // Count (ASCII)
        int[] cnt = new int[128];
        foreach (char c in s) cnt[c]++;

        // Early impossibility
        int max = 0;
        for (int i = 0; i < 128; i++)
            if (cnt[i] > max)
                max = cnt[i];
        if (max > (n + 1) / 2) return string.Empty;

        // Order chars by freq desc
        var chars = new char[128];
        for (int i = 0; i < 128; i++) chars[i] = (char)i;
        Array.Sort(chars, (a, b) => cnt[b].CompareTo(cnt[a]));

        // Fill even indices first, then odd (greedy placement)
        var res = new char[n];
        int pos = 0;
        foreach (char ch in chars)
        {
            int c = cnt[ch];
            while (c-- > 0)
            {
                if (pos >= n) pos = 1; // switch to odd positions
                res[pos] = ch;
                pos += 2;
            }
        }

        return new string(res);
    }
}

public class ReorganizingStringTests
{
    [Fact]
    public void BasicCase_Reorganizes()
    {
        var solver = new ReorganizingString();
        var result = solver.ReorganizeString("aab");
        Assert.Equal("aba", result);
    }

    [Fact]
    public void ImpossibleCase_ReturnsEmpty()
    {
        var solver = new ReorganizingString();
        var result = solver.ReorganizeString("aaab");
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void SingleChar_ReturnsSame()
    {
        var solver = new ReorganizingString();
        var result = solver.ReorganizeString("a");
        Assert.Equal("a", result);
    }

    [Fact]
    public void MultipleLetters_Works()
    {
        var solver = new ReorganizingString();
        var result = solver.ReorganizeString("vvvlo");
        Assert.True(IsValid(result));
    }

    private bool IsValid(string s)
    {
        for (int i = 1; i < s.Length; i++)
            if (s[i] == s[i - 1]) return false;
        return true;
    }
}