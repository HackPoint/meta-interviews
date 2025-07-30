using Xunit;

namespace Leetcode.MockInterviews;

public class FindMaximumScoreFromRemovingSubstrings
{
    public int MaximumGain(string s, int x, int y)
    {
        int score = 0;

        if (x > y) {
            score += RemovePairs(ref s, 'a', 'b', x);
            score += RemovePairs(ref s, 'b', 'a', y);
        } else {
            score += RemovePairs(ref s, 'b', 'a', y);
            score += RemovePairs(ref s, 'a', 'b', x);
        }
        return score;
    }

    private int RemovePairs(ref string s, char first, char second, int points)
    {
        var buffer = new Stack<char>();
        int score = 0;

        foreach (char c in s)
        {
            if (c == second && buffer.Count > 0 && buffer.Peek() == first)
            {
                buffer.Pop();
                score += points;
            }
            else
                buffer.Push(c);
        }

        s = new string(buffer.Reverse().ToArray());
        return score;
    }
}

public class FindMaximumScoreFromRemovingSubstringsTests
{
    [Fact]
    public void Should_FindMaxScoreFromRemoving_Strings()
    {
        var find = new FindMaximumScoreFromRemovingSubstrings();
        string s = "cdbcbbaaabab";
        int x = 4; // points for "ab"
        int y = 5; // points for "ba"
        int result = find.MaximumGain(s, x, y);

        Assert.Equal(19, result);
    }
}