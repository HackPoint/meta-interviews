using Leetcode.Medium.Arrays.Digits;
using Xunit;

namespace Leetcode.Medium.Tests;

public class CompressDigitsAndLettersTests
{
    [Fact]
    public void Should_Compress()
    {
        char[] chars = ['a', 'a', '1', '1', '1', 'b', '2', '2', '2', '2', 'c'];
        Assert.Equal(8, new CompressDigitsAndLetters().Compress(chars));
    }
}