using System.Text;
using Xunit;

namespace Leetcode.Medium.Heap___Hashmap;

public class SortCharactersByFrequency
{
    /// <summary>
    /// Returns the input string with its characters sorted by descending frequency.
    /// Tie-break rule: for equal frequencies, characters are ordered by ascending char code.
    ///
    /// Approach:
    /// 1) Count frequencies using a Dictionary<char,int>.
    /// 2) Order pairs by Value desc, then by Key asc for determinism.
    /// 3) Build the result by appending each character 'frequency' times.
    ///
    /// Time Complexity: O(n + m log m), where n = s.Length, m = distinct chars in s.
    /// Space Complexity: O(m) for the frequency map and output builder.
    /// </summary>
    public string FrequencySort(string s)
    {
        var freq = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (!freq.TryAdd(c, 1))
                freq[c]++;
        }

        // Sort by frequency desc (then by char asc for determinism)
        var ordered = freq.OrderByDescending(kv => kv.Value)
            .ThenBy(kv => kv.Key);

        // Build result efficiently
        var sb = new StringBuilder(s.Length);
        foreach (var (ch, fr) in ordered)
        {
            sb.Append(new string(ch, fr));
        }

        return sb.ToString();
    }


    /// <summary>
    /// Returns the input string with its characters sorted by descending frequency,
    /// implemented via a fixed-size frequency array for ASCII input.
    ///
    /// Assumption:
    /// - Input 's' contains only ASCII characters in range [0..127].
    ///
    /// Approach:
    /// 1) Count into int[128] freq.
    /// 2) Prepare a parallel 'chars' array for indices 0..127.
    /// 3) Sort 'chars' using a custom comparer: freq desc, then char asc.
    /// 4) Append each char 'freq[char]' times to build the result.
    ///
    /// Time Complexity: O(n + 128 log 128) ≈ O(n)
    /// Space Complexity: O(128) for freq/char arrays + output builder.
    /// </summary>
    public string FrequencySortArray(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;

        // 1. Count frequencies into array
        int[] freq = new int[128]; // assuming ASCII
        foreach (char c in s)
        {
            freq[c]++;
        }

        // 2. Sort characters by frequency desc
        var chars = new char[128];
        for (int i = 0; i < 128; i++)
            chars[i] = (char)i;

        Array.Sort(chars, (a, b) =>
        {
            int cmp = freq[b].CompareTo(freq[a]); // freq desc
            if (cmp != 0) return cmp;
            return a.CompareTo(b); // tie-break by char
        });

        // 3. Build result
        var sb = new StringBuilder(s.Length);
        foreach (char ch in chars)
        {
            int count = freq[ch];
            if (count > 0)
                sb.Append(new string(ch, count));
        }

        return sb.ToString();
    }
}

public class SortCharactersByFrequencyTests
{
    private readonly SortCharactersByFrequency _solver = new();

    [Fact]
    public void FrequencySort_Example_RaaeAedere()
    {
        // e:4, a:3, r:2, d:1
        // With tie-break by char asc, deterministic result should be: eeee + aaa + rr + d
        string s = "raaeaedere";
        string expected = "eeeeaaarrd";

        string actual = _solver.FrequencySort(s);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FrequencySortArray_Example_RaaeAedere_ASCII()
    {
        string s = "raaeaedere";
        string expected = "eeeeaaarrd";

        string actual = _solver.FrequencySortArray(s);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FrequencySort_Empty_ReturnsEmpty()
    {
        string s = "";
        string actual = _solver.FrequencySort(s);
        Assert.Equal("", actual);
    }

    [Fact]
    public void FrequencySortArray_Empty_ReturnsEmpty()
    {
        string s = "";
        string actual = _solver.FrequencySortArray(s);
        Assert.Equal("", actual);
    }

    [Fact]
    public void FrequencySort_SingleChar_ReturnsSame()
    {
        string s = "x";
        string actual = _solver.FrequencySort(s);
        Assert.Equal("x", actual);
    }

    [Fact]
    public void FrequencySortArray_SingleChar_ReturnsSame_ASCII()
    {
        string s = "x";
        string actual = _solver.FrequencySortArray(s);
        Assert.Equal("x", actual);
    }

    [Fact]
    public void FrequencySort_AllEqualFrequencies_TieBreakByCharAsc()
    {
        // a:2, b:2, c:2 → expect "aabbcc"
        string s = "bbaacc";
        string expected = "aabbcc";

        string actual = _solver.FrequencySort(s);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FrequencySortArray_AllEqualFrequencies_TieBreakByCharAsc_ASCII()
    {
        string s = "bbaacc";
        string expected = "aabbcc";

        string actual = _solver.FrequencySortArray(s);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FrequencySort_MixedCase_TieBreakByCharAsc_SeparatesCases()
    {
        // 'A'(65):1, 'a'(97):2, 'B'(66):1, 'b'(98):2
        // Order by freq desc: a(2), b(2), A(1), B(1)
        // For ties of equal freq: by char asc → 'a'<'b', 'A'<'B'
        string s = "AaBbabb a".Replace(" ", ""); // "AaBbabba"
        string expected = "aaabbbAB";

        string actual = _solver.FrequencySort(s);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FrequencySortArray_MixedCase_ASCII_ThrowsOnNonAscii()
    {
        // ASCII only: ensure non-ASCII throws
        string s = "abc";
        var ex = Record.Exception(() => _solver.FrequencySortArray(s));
        Assert.Null(ex);

        // Non-ASCII example: 'é' (if you decide to test)
        // string nonAscii = "abé";
        // Assert.Throws<ArgumentOutOfRangeException>(() => _solver.FrequencySortArray(nonAscii));
    }

    [Fact]
    public void FrequencySort_LargeUniformInput_CorrectAndFastEnough()
    {
        string s = new string('z', 1000);
        string actual = _solver.FrequencySort(s);
        Assert.Equal(s, actual);
    }

    [Fact]
    public void FrequencySortArray_LargeUniformInput_CorrectAndFastEnough_ASCII()
    {
        string s = new string('z', 1000);
        string actual = _solver.FrequencySortArray(s);
        Assert.Equal(s, actual);
    }
}