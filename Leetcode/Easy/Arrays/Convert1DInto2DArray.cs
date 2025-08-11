using Xunit;

namespace Leetcode.Easy.Arrays;

public class Convert1DInto2DArray
{
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        if (original.Length != m * n) return [];
        int[][] result = new int[m][];
        for (int i = 0; i < m; ++i)
            result[i] = new int[n];

        int row = 0, col = 0;
        foreach (int val in original)
        {
            result[row][col++] = val;
            if (col == n)
            {
                col = 0;
                row++;
            }
        }

        return result;
    }
}

public class Convert1DTo2DTests
{
    [Fact]
    public void ConvertTo2D_InvalidDimensions_ReturnsEmptyMatrix()
    {
        // Arrange
        var original = new[] { 1, 2, 3, 4, 5 };
        int m = 2, n = 2;
        var solution = new Convert1DInto2DArray();

        // Act
        var result = solution.Construct2DArray(original, m, n);

        // Assert
        Assert.Empty(result);
    }

    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new[] { 1, 2, 3, 4 },
                2,
                2,
                new int[][]
                {
                    [1, 2],
                    [3, 4]
                }
            },
            new object[]
            {
                new[] { 5, 6, 7, 8, 9, 10 },
                2,
                3,
                new int[][]
                {
                    [5, 6, 7],
                    [8, 9, 10]
                }
            },
            new object[]
            {
                new[] { 1, 2 },
                1,
                2,
                new int[][]
                {
                    [1, 2]
                }
            },
            new object[]
            {
                new[] { 1 },
                1,
                1,
                new int[][]
                {
                    [1]
                }
            }
        };
}