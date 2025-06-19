using Leetcode.Easy.Strings;
using Xunit;

namespace Leetcode.Easy.tests;

public class MergeStringAlternatelyTests
{
    [Fact]
    public void Should_Copy_ZigzagWay()
    {
        string word1 = "";
        string word2 = "pqr";
        string output = "pqr";

        MergeStringAlternately alternately = new MergeStringAlternately();
        string result = alternately.MergeAlternately(word1, word2);
        Assert.Equal(output, result);
        
    }
}