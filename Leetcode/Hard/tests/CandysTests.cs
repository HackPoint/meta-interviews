using Leetcode.Hard.Arrays;
using Xunit;

namespace Leetcode.Hard.tests;

public class CandysTests
{
    private readonly Candys _candys = new Candys();

    [Theory]
    [InlineData(new int[] { 5 }, 1)] // один ребёнок
    [InlineData(new int[] { 1, 1, 1, 1 }, 4)] // все рейтинги равны
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 15)] // строго возрастающий
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, 15)] // строго убывающий
    [InlineData(new int[] { 1, 3, 2, 2, 1 }, 7)] // «горка» посередине
    [InlineData(new int[] { 1, 0, 2 }, 5)] // пример из описания
    [InlineData(new int[] { 1, 2, 2 }, 4)] // равные в конце
    public void Candy_VariousPatterns_ReturnsExpected(int[] ratings, int expected)
    {
        int actual = _candys.Candy(ratings);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Candy_PeaksAndValleys()
    {
        int[] ratings = { 1, 6, 2, 3, 4, 1, 2 };
        // candies: [1,2,1,2,3,1,2] → сумма = 12
        Assert.Equal(12, _candys.Candy(ratings));
    }

    [Fact]
    public void Candy_LargePlateau()
    {
        int[] ratings = Enumerable.Repeat(5, 100).Concat(new[] { 6 }).ToArray();
        // первые 100 детей получают по 1, последний — 2 → сумма = 102
        Assert.Equal(102, _candys.Candy(ratings));
    }

    [Fact]
    public void Candy_SingleDropAtEnd()
    {
        int[] ratings = { 3, 3, 4, 5, 1 };
        // candies: [1,1,2,3,1] → сумма = 8
        Assert.Equal(8, _candys.Candy(ratings));
    }
}