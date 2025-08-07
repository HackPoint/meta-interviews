using Leetcode.Easy.DFS;
using Xunit;

namespace Leetcode.Medium.Backtracking;

/// <summary>
/// Problem: 131. Palindrome Partitioning
///
/// Given a string `s`, partition `s` such that every substring of the partition is a palindrome.
/// Return all possible palindrome partitioning of `s`.
///
/// Approach:
/// - Use DFS + Backtracking to explore all partitions.
/// - At each recursive step, we iterate from the current index to the end of the string,
///   checking if the substring s[index..i] is a palindrome.
/// - If it is, we add it to the current path and recurse from i + 1.
/// - On backtrack, we remove the last added substring.
/// - If index == s.Length, we found a valid partition and add a snapshot of the current path.
///
/// Time Complexity:
/// - Worst-case: O(2^n * n)
///   - 2^n possible partitions, each taking up to O(n) time to copy the result.
/// - Palindrome check is O(n) per substring but amortized since many are skipped.
///
/// Space Complexity:
/// - O(n) recursion stack (depth of recursion)
/// - O(n) path list
/// - O(2^n * n) total output size in the worst case
///
/// Edge Cases:
/// - Empty string → returns [[]] (one empty partition)
/// - String with all identical characters (e.g. "aaa") → many valid partitions
///
/// Example:
/// Input: "aab"
/// Output: [["a","a","b"],["aa","b"]]
/// Explanation: All possible palindrome partitions.
/// </summary>
public class PalindromePartitions
{
    public IList<IList<string>> Partition(string s) {
        var res = new List<IList<string>>();
        var path = new List<string>();
        Dfs(0);
        return res;

        void Dfs(int index) {
            if(index == s.Length) {
                res.Add(new List<string>(path));
                return;
            }

            for(int i = index; i < s.Length; i++ ) {
                if(IsPalindrome(s, index, i)) {
                    path.Add(s.Substring(index, i - index + 1));
                    Dfs(i + 1);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }

    private bool IsPalindrome(string s, int start, int end) {
        while(start < end) {
            if(s[start++] != s[end--]) return false;
        }
        return true;
    }
}

public class PalindromePartitioningTests
{
    [Theory]
    [MemberData(nameof(GetPalindromeTestData))]
    public void TestPartition(string input, IList<IList<string>> expected)
    {
        // Arrange
        var solution = new PalindromePartitions();

        // Act
        var actual = solution.Partition(input);

        // Assert
        Assert.Equal(
            expected.Select(e => string.Join(",", e)).OrderBy(e => e),
            actual.Select(a => string.Join(",", a)).OrderBy(a => a)
        );
    }

    public static IEnumerable<object[]> GetPalindromeTestData()
    {
        yield return new object[]
        {
            "aab",
            new List<IList<string>>
            {
                new List<string> { "a", "a", "b" },
                new List<string> { "aa", "b" }
            }
        };

        yield return new object[]
        {
            "a",
            new List<IList<string>>
            {
                new List<string> { "a" }
            }
        };

        yield return new object[]
        {
            "racecar",
            new List<IList<string>>
            {
                new List<string> { "r", "a", "c", "e", "c", "a", "r" },
                new List<string> { "r", "a", "cec", "a", "r" },
                new List<string> { "r", "aceca", "r" },
                new List<string> { "racecar" }
            }
        };

        yield return new object[]
        {
            "aaa",
            new List<IList<string>>
            {
                new List<string> { "a", "a", "a" },
                new List<string> { "a", "aa" },
                new List<string> { "aa", "a" },
                new List<string> { "aaa" }
            }
        };

        yield return new object[]
        {
            "",
            new List<IList<string>>
            {
                new List<string>() // empty partition
            }
        };
    }
}
