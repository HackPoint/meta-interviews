using Leetcode.Easy.Arrays;
using Xunit;

namespace Leetcode.Easy.tests;

public class SpecialArrayITests
{
    [Fact]
    public void IsArraySpecial()
    {
        int[] notSpecial = [1,5];
        SpecialArrayI array = new SpecialArrayI();
        Assert.Equal(array.IsArraySpecial(notSpecial), false);
    }
}