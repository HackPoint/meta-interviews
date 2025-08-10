using Xunit;

namespace Leetcode.Easy.Strings;

/// <summary>
/// Problem:
///     Determines if two strings s and t are isomorphic.
///     Two strings are isomorphic if the characters in s can be replaced to get t,
///     with each character mapping to exactly one other character and vice versa.
///     Mapping must be consistent across the entire string and preserve order.
/// 
/// Approach:
///     Uses two fixed-size int arrays (length 256 for ASCII) to store character mappings:
///         - mapST[c] stores the mapped character from s to t
///         - mapTS[c] stores the mapped character from t to s
///     Arrays are initialized with -1, meaning "no mapping yet".
///     Iterate over both strings simultaneously:
///         1. If a character already has a mapping, ensure it matches the current one.
///         2. If a character has no mapping yet, create it in both directions.
///         3. If any mismatch occurs, return false.
///     If loop completes without conflicts, strings are isomorphic.
/// 
/// Time Complexity:
///     O(n), where n = length of the strings (single pass, constant-time lookups).
/// 
/// Space Complexity:
///     O(1) — arrays are fixed size (256), independent of input length.
/// 
/// Correctness:
///     Handles repeated characters, distinct character constraints, and order preservation.
///     Ensures bijective mapping by maintaining both forward and reverse maps.
/// 
/// Example:
///     s = "egg", t = "add"
///     Iteration 1: 'e' ↔ 'a' (new mapping)
///     Iteration 2: 'g' ↔ 'd' (new mapping)
///     Iteration 3: 'g' ↔ 'd' (matches existing mapping)
///     → returns true.
/// </summary>
public class IsomorphicStrings {
    public bool IsIsomorphic(string s, string t) {
        if(s.Length != t.Length) return false;
        int len = s.Length;
   
        int[] mapSt = new int[256];
        int[] mapTs = new int[256];
        Array.Fill(mapSt, -1);
        Array.Fill(mapTs, -1);

        for(int i = 0; i < len; i++) {
            int cs = s[i];
            int ct = t[i];

            // If already mapped, check consistency
            if (mapSt[cs] != -1 && mapSt[cs] != ct) return false;
            if (mapTs[ct] != -1 && mapTs[ct] != cs) return false;

            // If not mapped, create mapping
            mapSt[cs] = ct;
            mapTs[ct] = cs;
        }

        return true;
    }
}

public class IsomorphicStringsTests
{
    // 🔧 Update this adapter if your class name differs.
    private static bool Iso(string s, string t) => new IsomorphicStrings().IsIsomorphic(s, t);

    [Theory]
    [InlineData("egg",   "add",   true)]
    [InlineData("foo",   "bar",   false)]
    [InlineData("paper", "title", true)]
    [InlineData("ab",    "aa",    false)]   // two different map to same
    [InlineData("",      "",      true)]
    [InlineData("a",     "a",     true)]
    [InlineData("abab",  "baba",  true)]    // a->b, b->a
    [InlineData("abba",  "abab",  false)]   // conflict: last 'a' would need 'b'
    public void BasicPairs(string s, string t, bool expected)
    {
        Assert.Equal(expected, Iso(s, t));
    }

    [Fact]
    public void DifferentLengths_ShouldBeFalse()
    {
        Assert.False(Iso("ab", "abc"));
    }

    [Fact]
    public void LargeRepeatPattern_ShouldBeTrue()
    {
        // "abcd" ↔ "wxyz" repeated -> valid bijection
        string s = new string("abcd".ToCharArray(), 0, 1).PadLeft(1000, 'a'); // many 'a'
        string t = new string("wxyz".ToCharArray(), 0, 1).PadLeft(1000, 'w'); // many 'w'
        Assert.True(Iso(s, t));
    }
}
