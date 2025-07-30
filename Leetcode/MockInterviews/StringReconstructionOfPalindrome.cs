using Xunit;

namespace Leetcode.MockInterviews;

/// <summary>
/// Given an array of strings, this method counts how many **unique palindrome strings**
/// can be formed by concatenating any two **distinct** words (i ≠ j).
///
/// A palindrome is a string that reads the same forward and backward (e.g., "abba").
///
/// ⚙️ Approach:
/// - Iterate over all ordered pairs (i, j) where i ≠ j.
/// - For each pair, concatenate words[i] + words[j].
/// - Use a helper method `IsPalindrome` to check if the result is a palindrome.
/// - Store each unique valid result in a HashSet<string>.
/// - Finally, return the number of unique palindromic concatenations.
///
/// 📈 Time Complexity:
/// - O(n² * k), where:
///   - n is the number of words
///   - k is the average length of each string
/// - Each of the O(n²) combinations may generate a string of length up to 2k,
///   and checking if it's a palindrome takes O(k).
///
/// 🧠 Space Complexity:
/// - O(n² * k) in the worst case (if all combinations produce unique palindromes).
/// - Additional O(1) auxiliary space in each loop iteration.
/// 
/// 📌 Notes:
/// - The algorithm ensures uniqueness by storing the full concatenated strings in a HashSet.
/// - This is a brute-force solution. It’s correct but not optimized for large inputs.
/// - Optimizations may include trie-based prefix matching or reverse-word maps.
///
/// 🧪 Example:
/// Input: ["bat", "tab", "cat"]
/// Pairs: "bat"+"tab" = "battab" (✅), "tab"+"bat" = "tabbat" (✅)
/// Output: 2
/// </summary>
public class StringReconstructionOfPalindrome
{
    public int ReconstructAPalindrome(string[] words)
    {
        var set = new HashSet<string>();
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (i == j) continue;

                string word = words[i] + words[j];
                if (IsPalindrome(word))
                    set.Add(word);
            }
        }

        return set.Count;
    }

    private bool IsPalindrome(string word)
    {
        int left = 0, right = word.Length - 1;

        while (left < right)
            if (word[left++] != word[right--])
                return false;

        return true;
    }
}

public class StringReconstructionOfPalindromeTests
{
    [Theory]
    [InlineData(new[] { "ab", "ba" }, 2)]
    [InlineData(new[] { "bat", "tab", "cat" }, 2)]
    [InlineData(new[] { "", "aba", "xyz" }, 1)]
    [InlineData(new[] { "abc", "def", "ghi" }, 0)]
    [InlineData(new[] { "ab", "ba", "ab", "ba" }, 2)]
    [InlineData(new[] { "a", "aa", "aaa" }, 3)]
    public void Should_Reconstruct_ValidateAPalindrome(string[] words, int expected)
    {
        var reconstruct = new StringReconstructionOfPalindrome();
        var actual = reconstruct.ReconstructAPalindrome(words);
        Assert.Equal(expected, actual);
    }
}