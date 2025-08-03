using Xunit;

namespace Leetcode.Medium.Backtracking;

/// <summary>
/// Problem:
/// Given a string `s` containing letters and digits,
/// generate all possible permutations where each letter can be either lowercase or uppercase.
/// Digits remain unchanged.
///
/// Approach:
/// This problem is a classic backtracking search where at each character:
/// - If it's a digit, we continue with the same character.
/// - If it's a letter, we branch into two paths:
///   one with lowercase, one with uppercase.
/// 
/// We build the result using a char[] `path` and perform DFS-style recursion,
/// appending complete strings once we've reached the end of input.
///
/// Time Complexity:
/// - O(2^L * N), where:
///   - L = number of letters (each contributes 2 branches)
///   - N = length of the string (cost to build each result string)
///
/// Space Complexity:
/// - O(2^L * N) to store the results
/// - O(N) recursion depth for call stack
///
/// Correctness:
/// - We ensure each character is handled only once per level.
/// - Digits generate a single path, letters generate two.
/// - No mutation is shared between paths (char[] is reused safely via index overwrite).
///
/// Example:
/// Input: "a1b"
/// Paths:
/// → a1b
/// → a1B
/// → A1b
/// → A1B
/// </summary>
public class LetterCasePermutations
{
    public IList<string> LetterCasePermutation(string s)
    {
        var result = new List<string>();
        var path = new char[s.Length];

        Backtracking(0);

        return result;

        void Backtracking(int index)
        {
            if (index == s.Length)
            {
                result.Add(new string(path));
                return;
            }

            if (char.IsLetter(s[index]))
            {
                path[index] = char.ToLower(s[index]);
                Backtracking(index + 1);

                path[index] = char.ToUpper(s[index]);
                Backtracking(index + 1);
            }
            else
            {
                // digits only
                path[index] = s[index];
                Backtracking(index + 1);
            }
        }
    }
}

public class LetterCasePermutationTests
{
    private readonly LetterCasePermutations _solver = new();

    [Theory]
    [InlineData("a1b", new[] { "a1b", "a1B", "A1b", "A1B" })]
    [InlineData("3z4", new[] { "3z4", "3Z4" })]
    [InlineData("123", new[] { "123" })]
    [InlineData("a", new[] { "a", "A" })]
    [InlineData("", new[] { "" })]
    public void Generates_All_Permutations(string input, string[] expected)
    {
        var output = _solver.LetterCasePermutation(input);
        Assert.Equal(expected.OrderBy(x => x), output.OrderBy(x => x));
    }

    [Fact]
    public void Handles_Multiple_Letters()
    {
        var result = _solver.LetterCasePermutation("ab");
        Assert.Contains("ab", result);
        Assert.Contains("Ab", result);
        Assert.Contains("aB", result);
        Assert.Contains("AB", result);
        Assert.Equal(4, result.Count);
    }

    [Fact]
    public void Handles_Mixed_With_Digits()
    {
        var result = _solver.LetterCasePermutation("a1b2");
        Assert.Equal(4, result.Count); // 2 letters = 2^2 = 4 permutations
        Assert.Contains("A1B2", result);
        Assert.Contains("a1B2", result);
        Assert.Contains("A1b2", result);
        Assert.Contains("a1b2", result);
    }
}
