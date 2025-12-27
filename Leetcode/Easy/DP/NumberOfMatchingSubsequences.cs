using Xunit;

namespace Leetcode.Easy.DP;

public class MatchingSubsequences
{
    public int NumMatchingSubseq(string s, string[] words)
    {
        var buckets = new Queue<string>[128];
        for (int i = 0; i < 128; i++) buckets[i] = new();
        foreach (var w in words) buckets[w[0]].Enqueue(w);

        int count = 0;
        foreach (char c in s)
        {
            int size = buckets[c].Count;
            while (size-- > 0)
            {
                var word = buckets[c].Dequeue();
                if (word.Length == 1) count++;
                else buckets[word[1]].Enqueue(word[1..]);
            }
        }

        return count;
    }
}

public class MatchingSubsequencesTests
{
    [Fact]
    public void ExampleCase()
    {
        var solver = new MatchingSubsequences();
        Assert.Equal(3, solver.NumMatchingSubseq(
            "abcde", new[] { "a", "bb", "acd", "ace" }));
    }

    [Fact]
    public void AllMatch()
    {
        var solver = new MatchingSubsequences();
        Assert.Equal(2, solver.NumMatchingSubseq(
            "abc", new[] { "abc", "ac" }));
    }

    [Fact]
    public void NoneMatch()
    {
        var solver = new MatchingSubsequences();
        Assert.Equal(0, solver.NumMatchingSubseq(
            "abc", new[] { "d", "ef", "gh" }));
    }

    [Fact]
    public void DuplicateWords()
    {
        var solver = new MatchingSubsequences();
        Assert.Equal(4, solver.NumMatchingSubseq(
            "abcabc", new[] { "abc", "abc", "ac", "ac" }));
    }

    [Fact]
    public void SingleCharWords()
    {
        var solver = new MatchingSubsequences();
        Assert.Equal(3, solver.NumMatchingSubseq(
            "aaa", new[] { "a", "a", "a" }));
    }
}