using Xunit;

namespace Leetcode.Easy.Strings;

public class FirstUniqueCharacterInString {
    public int FirstUniqChar(string s) {
        Span<int> freq = stackalloc int[26];

        foreach (var ch in s) {
            freq[ch - 'a']++;
        }

        for (int i = 0; i < s.Length; i++) {
            if (freq[s[i] - 'a'] == 1) return i;
        }

        return -1;
    }
}

public class FirstUniqueCharacterInStringTest {
    [Fact]
    public void ReturnsIndexForStringWithAllUniqueCharacters() {
        var solution = new FirstUniqueCharacterInString();
        var result = solution.FirstUniqChar("abcdef");
        Assert.Equal(0, result);
    }

    [Fact]
    public void ReturnsIndexForLastUniqueCharacterInString() {
        var solution = new FirstUniqueCharacterInString();
        var result = solution.FirstUniqChar("aabbccd");
        Assert.Equal(6, result);
    }

    [Fact]
    public void ReturnsNegativeOneForStringWithRepeatingCharactersOnly() {
        var solution = new FirstUniqueCharacterInString();
        var result = solution.FirstUniqChar("abababab");
        Assert.Equal(-1, result);
    }

    [Fact]
    public void ReturnsIndexForStringWithRepeatingCharactersThenUnique() {
        var solution = new FirstUniqueCharacterInString();
        var result = solution.FirstUniqChar("aaaaaz");
        Assert.Equal(5, result);
    }


    [Fact]
    public void ReturnsIndexForFirstUniqueCharacter() {
        var solution = new FirstUniqueCharacterInString();
        var result = solution.FirstUniqChar("leetcode");
        Assert.Equal(0, result);
    }

    [Fact]
    public void ReturnsNegativeOneWhenNoUniqueCharacterExists() {
        var solution = new FirstUniqueCharacterInString();
        var result = solution.FirstUniqChar("aabbcc");
        Assert.Equal(-1, result);
    }

    [Fact]
    public void ReturnsIndexForSingleCharacterString() {
        var solution = new FirstUniqueCharacterInString();
        var result = solution.FirstUniqChar("z");
        Assert.Equal(0, result);
    }

    [Fact]
    public void ReturnsIndexForFirstUniqueCharacterInMixedString() {
        var solution = new FirstUniqueCharacterInString();
        var result = solution.FirstUniqChar("loveleetcode");
        Assert.Equal(2, result);
    }

    [Fact]
    public void ReturnsNegativeOneForEmptyString() {
        var solution = new FirstUniqueCharacterInString();
        var result = solution.FirstUniqChar("");
        Assert.Equal(-1, result);
    }
}