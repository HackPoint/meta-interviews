using Leetcode.Easy.Arrays;
using Xunit;

namespace Leetcode.Easy.tests;

public class FindLuckyNumberTests
{
    [Fact]
    public void FindLuckyNumber()
    {
        var luckyNumber = new FindLuckyNumber();
        // int lucky = luckyNumber.FindLucky([2, 2, 3, 4]);
        int lucky = luckyNumber.FindLucky([1,2,2,3,3,3]);
        
        Assert.Equal(3, lucky);
    }
}