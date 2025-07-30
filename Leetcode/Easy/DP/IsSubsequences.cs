using Xunit;

namespace Leetcode.Easy.DP;

public class IsSubsequences
{
    public bool IsSubsequence(string s, string t)
    {
        int i = 0, j = 0;
        while (i < s.Length && j < t.Length)
        {
            if (s[i] == t[j])
                i++;

            j++;
        }

        return i == s.Length;
    }
}

public class IsSubsequencesTests
{
    [Fact]
    public void Should_ReturnOnDefaultCase()
    {
        string s = "abc";
        string t = "ahbgdc";

        var seq = new IsSubsequences();
        
        Assert.Equal(true, seq.IsSubsequence(s, t));
    }
}