using Xunit;

namespace Leetcode.Easy.Strings;

/// <summary>
/// Problem:
///     Given a pattern string (pattern) and a space-separated string (s),
///     determine if s follows the same pattern mapping rule:
///         - Each character in pattern must map to exactly one distinct word in s.
///         - Each word in s must map to exactly one distinct character in pattern.
///         - Mapping must be consistent throughout the strings.
/// 
/// Approach:
///     1. Split s into words by spaces.
///     2. If the number of words != length of pattern → immediately return false.
///     3. Use two dictionaries:
///         - p2w: maps pattern characters to words.
///         - w2p: maps words to pattern characters.
///     4. Iterate over pattern/words in parallel:
///         - If pattern char already mapped → check it matches current word.
///         - Else, ensure the word isn't already mapped to another char,
///           then add both mappings.
///     5. Return true if no mapping conflicts found.
/// 
/// Time Complexity:
///     O(n) — where n is the number of words (same as pattern length),
///     dictionary lookups are O(1) average.
/// 
/// Space Complexity:
///     O(n) — for the dictionaries storing the mappings.
/// 
/// Example:
///     pattern = "abba", s = "dog cat cat dog"
///     p2w: { 'a' -> "dog", 'b' -> "cat" }
///     w2p: { "dog" -> 'a', "cat" -> 'b' }
///     Returns true (consistent mapping).
/// </summary>
public class WordPatterns {
    public bool WordPattern(string pattern, string s) {
        var words = s.Split(' ');
        if (words.Length != pattern.Length) return false;

        var p2w = new Dictionary<char, string>(pattern.Length);
        var w2p = new Dictionary<string, char>(pattern.Length, StringComparer.Ordinal);

        for (int i = 0; i < pattern.Length; i++)
        {
            char c = pattern[i];
            string w = words[i];

            if (p2w.TryGetValue(c, out var mw)) { if (mw != w) return false; }
            else
            {
                if (w2p.TryGetValue(w, out _)) return false;
                p2w[c] = w; w2p[w] = c;
            }
        }
        return true;
    }
}

public class WordPatternTests {
    private readonly WordPatterns _sut = new();

    [Theory]
    [InlineData("abba", "dog cat cat dog", true)]
    [InlineData("abba", "dog cat cat fish", false)]
    [InlineData("aaaa", "dog dog dog dog", true)]
    [InlineData("abba", "dog dog dog dog", false)]
    [InlineData("abc", "dog cat dog", false)]
    public void WordPattern_ValidatesPatternCorrectly(string pattern, string s, bool expected) {
        // Act
        var result = _sut.WordPattern(pattern, s);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("", "dog")]
    public void WordPattern_WithEmptyInput_ReturnsFalse(string pattern, string s) {
        // Act
        var result = _sut.WordPattern(pattern, s);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void WordPattern_WithDifferentLengths_ReturnsFalse() {
        // Arrange
        var pattern = "abc";
        var s = "dog cat";

        // Act
        var result = _sut.WordPattern(pattern, s);

        // Assert
        Assert.False(result);
    }
}