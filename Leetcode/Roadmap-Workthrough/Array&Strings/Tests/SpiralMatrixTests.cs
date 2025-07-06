using Xunit;

namespace Leetcode.Roadmap_Workthrough.Array_Strings.Tests;

public class SpiralMatrixTests
{
    [Fact]
    public void Should_SpiralTheMatrix()
    {
        int[][] matrix =
        [
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        ];

        SpiralMatrix.SpiralOrder(matrix);
    }
}