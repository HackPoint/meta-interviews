namespace Leetcode.Easy.Arrays;

public class TransposeMatrix
{
    public int[][] Transpose(int[][] matrix) {
        if (matrix == null || matrix.Length == 0) {
            return []; // Handle empty or null matrix
        }

        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int[][] transposedMatrix = new int[cols][];
        for (int i = 0; i < cols; i++) {
            transposedMatrix[i] = new int[rows];
        }

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                transposedMatrix[j][i] = matrix[i][j];
            }
        }
        return transposedMatrix;
    }
}