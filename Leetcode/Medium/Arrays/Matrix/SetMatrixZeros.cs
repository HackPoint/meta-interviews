using Xunit;

namespace Leetcode.Medium.Arrays.Matrix;

/// <summary>
/// Modifies the input matrix in-place such that if an element is 0,
/// its entire row and column are set to 0. Achieves O(1) space complexity
/// by using the first row and first column as markers.
/// 
/// 🔍 Algorithm:
/// - Scan first row and column separately to track if they contain any zero.
/// - Iterate through the matrix and mark row/col flags in the first row/column.
/// - Iterate again (excluding first row/col) and zero out cells based on flags.
/// - Finally, zero out the first row and first column if needed.
/// 
/// 🧠 Time Complexity: O(m × n)
/// 🧠 Space Complexity: O(1) — done in-place
/// 
/// ⚠️ Edge cases handled:
/// - 1x1 matrix
/// - Matrix with only one row or column
/// - Entire row or column being 0
/// - No 0s at all
/// </summary>
public class SetMatrixZeros
{
    public void SetZeroes(int[][] matrix)
    {
        bool firstRowHasZero = false;
        bool firstColHasZero = false;

        int rows = matrix.Length;
        int cols = matrix[0].Length;

        for (int col = 0; col < cols; col++)
        {
            if (matrix[0][col] == 0)
            {
                firstRowHasZero = true;
                break;
            }
        }

        for (int row = 0; row < rows; row++)
        {
            if (matrix[row][0] == 0)
            {
                firstColHasZero = true;
                break;
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    matrix[i][j] = 0;
            }
        }

        if (firstRowHasZero)
        {
            for (int col = 0; col < cols; col++) matrix[0][col] = 0;
        }

        if (firstColHasZero)
        {
            for (int row = 0; row < rows; row++) matrix[row][0] = 0;
        }
    }
}

public class SetMatrixZerosTests
{
    public static IEnumerable<object[]> MatrixZeroTestData => new[]
    {
        new object[]
        {
            new int[][]
            {
                new[] {0, 1, 2, 0},
                new[] {3, 4, 5, 2},
                new[] {1, 3, 1, 5}
            },
            new int[][]
            {
                new[] {0, 0, 0, 0},
                new[] {0, 4, 5, 0},
                new[] {0, 3, 1, 0}
            }
        }
    };

    [Theory]
    [MemberData(nameof(MatrixZeroTestData))]
    public void SetZeroes_ModifiesMatrixCorrectly(int[][] input, int[][] expected)
    {
        // Arrange
        var solution = new SetMatrixZeros();

        // Act
        solution.SetZeroes(input);

        // Assert
        for (int i = 0; i < input.Length; i++)
        {
            Assert.Equal(expected[i], input[i]);
        }
    }

    [Fact]
    public void SetZeroes_SingleElementZero()
    {
        int[][] matrix = { new[] { 0 } };
        var expected = new[] { new[] { 0 } };
        var solution = new SetMatrixZeros();
        solution.SetZeroes(matrix);
        Assert.Equal(expected[0], matrix[0]);
    }

    [Fact]
    public void SetZeroes_SingleElementNonZero()
    {
        int[][] matrix = { new[] { 5 } };
        var expected = new[] { new[] { 5 } };
        var solution = new SetMatrixZeros();
        solution.SetZeroes(matrix);
        Assert.Equal(expected[0], matrix[0]);
    }

    [Fact]
    public void SetZeroes_AllZeroMatrix()
    {
        int[][] matrix = {
            new[] {0, 0},
            new[] {0, 0}
        };
        var expected = new[] {
            new[] {0, 0},
            new[] {0, 0}
        };
        var solution = new SetMatrixZeros();
        solution.SetZeroes(matrix);
        Assert.Equal(expected[0], matrix[0]);
        Assert.Equal(expected[1], matrix[1]);
    }
}