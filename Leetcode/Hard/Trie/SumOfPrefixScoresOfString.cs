using Leetcode.Easy.DFS;
using Xunit;

namespace Leetcode.Hard.Trie;

/// <summary>
/// Problem: 2416. Sum of Prefix Scores of Strings
///
/// Given an array of strings `words`, this method computes a score for each word.
/// The score of a word is defined as the total number of words in the array that share
/// each of its prefixes. The result is an array of integers, where each value corresponds
/// to the score of the word at that index.
///
/// Approach:
/// We use a Trie (prefix tree) to build a frequency counter of all prefixes.
/// 1. For each word, insert it into the Trie.
///    At each character, increment a counter `Count` to record how many words passed through that node.
/// 2. For each word, traverse the Trie again and accumulate the `Count` of each prefix node visited.
///    The sum of these counts gives the prefix score for that word.
///
/// Time Complexity:
/// - O(N * L), where N is the number of words and L is the average length of each word:
///   * O(N * L) to build the Trie (insertion)
///   * O(N * L) to calculate prefix scores (lookup)
///
/// Space Complexity:
/// - O(N * L) for Trie node storage (in worst case, all prefixes are unique)
///
/// Correctness:
/// - Prefix counts are updated during insertion.
/// - Prefix sums are aggregated per word with guaranteed correctness as traversal mirrors insertion path.
///
/// Example:
/// Input: ["abc", "ab", "bc", "b"]
/// Output: [5, 3, 2, 1]
/// Explanation:
///   - "abc": shares "a", "ab", "abc" with ["abc", "ab"] → 2+2+1 = 5
///   - "ab":  shares "a", "ab"         → 2+1 = 3
///   - "bc":  shares "b", "bc"         → 2+1 = 2
///   - "b":   shares "b"               → 1
/// </summary>

public class SumOfPrefixScoresOfString
{
    public int[] SumPrefixScores(string[] words)
    {
        TrieNode[] trie = new TrieNode[2000000];
        int nextIndex = 1; // index 0 — root

        // Init root node
        trie[0] = new TrieNode();

        int[] result = new int[words.Length];

        // Step 1: insert all words, building prefix counts
        foreach (var word in words)
        {
            int nodeIndex = 0;
            foreach (char c in word)
            {
                int charIndex = c - 'a';

                if (trie[nodeIndex].Children == null)
                    trie[nodeIndex].Children = new int[26];

                int next = trie[nodeIndex].Children[charIndex];
                if (next == 0)
                {
                    trie[nextIndex] = new TrieNode();
                    trie[nodeIndex].Children[charIndex] = nextIndex;
                    next = nextIndex;
                    nextIndex++;
                }

                nodeIndex = next;
                trie[nodeIndex].Count++;
            }
        }

        // Step 2: calculate score for each word
        for (int i = 0; i < words.Length; i++)
        {
            int nodeIndex = 0;
            int score = 0;

            foreach (char c in words[i])
            {
                int charIndex = c - 'a';
                nodeIndex = trie[nodeIndex].Children[charIndex];
                score += trie[nodeIndex].Count;
            }

            result[i] = score;
        }

        return result;
    }
    
    private struct TrieNode
    {
        public int[] Children;
        public int Count;
    }

}

public class SumOfPrefixScoresOfStringTests
{
    [Theory]
    [InlineData(new string[] { "a", "ab", "abc", "abcd" }, new int[] { 4, 7, 9, 10 })]
    [InlineData(new string[] { "abc", "ab", "bc", "b" }, new int[] { 5, 4, 3, 2 })]
    [InlineData(new string[] { "a", "b", "c" }, new int[] { 1, 1, 1 })]
    [InlineData(new string[] { "dog", "do", "dove", "dot" }, new int[] {9, 8, 10, 9 })]
    public void TestSumPrefixScores(string[] words, int[] expected)
    {
        var solution = new SumOfPrefixScoresOfString();
        var result = solution.SumPrefixScores(words);
        Assert.Equal(expected, result);
    }
}