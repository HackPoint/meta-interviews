using Xunit;

namespace Leetcode.Medium.DP.tests;

public class MinimumDeleteSumTests {
    [Theory]
    [InlineData("sea", "eat", 231)]       // удалить 's'=115 из s1 и 't'=116 из s2
    [InlineData("delete", "leet", 403)]   // удалить 'd'=100 и 'e'=101
    [InlineData("abc", "abc", 0)]         // строки уже одинаковые
    [InlineData("abc", "", 294)]          // удалить все символы из s1: 97+98+99
    [InlineData("", "abc", 294)]          // удалить все символы из s2
    [InlineData("a", "b", 195)]           // удалить 'a'=97 и 'b'=98
    [InlineData("abc", "cba", 390)]       // лучший путь: оставить 'c', удалить 'ab' и 'ba'
    public void MinimumDeleteSum_ReturnsExpected(string s1, string s2, int expected)
    {
        var solver = new MinASCIIDeleteSumForTwoStrings();
        int result = solver.MinimumDeleteSum(s1, s2);
        Assert.Equal(expected, result);
    }
}