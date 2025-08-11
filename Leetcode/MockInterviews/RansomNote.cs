using Xunit;

namespace Leetcode.MockInterviews;

/// <summary>
/// LeetCode 383: Ransom Note
/// https://leetcode.com/problems/ransom-note/
/// Given two strings ransomNote and magazine, return true if ransomNote can be constructed
/// by using the letters from magazine, false otherwise.
/// Each letter in magazine can only be used once in ransomNote.
/// Time: O(m + n) where m is length of magazine and n is length of ransomNote
/// Space: O(1) as we use fixed size array of 26 chars
/// </summary>
public class RansomNote {
    public bool CanConstruct(string ransomNote, string magazine) {
        Span<int> freq = stackalloc int[26];
        foreach (var ch in magazine) {
            freq[ch - 'a']++;
        }

        foreach (var ch in ransomNote) {
            if (--freq[ch - 'a'] < 0) {
                return false; // Not enough characters in magazine
            }
        }

        return true; // All characters in ransomNote can be constructed from magazine
    }
}
public class RansomNoteTests
{
    private readonly RansomNote _solution = new();

    [Theory]
    [InlineData("a", "b", false)]
    [InlineData("aa", "ab", false)]
    [InlineData("aa", "aab", true)]
    [InlineData("", "", true)]
    [InlineData("abc", "abcde", true)]
    [InlineData("abb", "ab", false)]
    public void CanConstruct_ValidInput_ReturnsExpectedResult(string ransomNote, string magazine, bool expected)
    {
        var result = _solution.CanConstruct(ransomNote, magazine);
        Assert.Equal(expected, result);
    }
}