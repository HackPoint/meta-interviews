namespace Leetcode.Roadmap_Workthrough.Array_Strings;

public class SpiralMatrix
{
    /// <summary>
    ///  layer-by-layer boundary control
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public static IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();
        int n = matrix[0].Length;
        int m = matrix.Length;

        int top = 0, bottom = m - 1, left = 0, right = n - 1;
        while (top <= bottom && left <= right)
        {
            // ➡ left to right
            for (int col = left; col <= right; col++)
                result.Add(matrix[top][col]);
            top++;

            // ⬇ top to bottom
            for (int row = top; row <= bottom; row++)
                result.Add(matrix[row][right]);
            right--;

            // ⬅ right to left
            if (top <= bottom)
            {
                for (int col = right; col >= left; col--)
                    result.Add(matrix[bottom][col]);
                bottom--;
            }

            // ⬆ bottom to top
            if (left <= right)
            {
                for (int row = bottom; row >= top; row--)
                    result.Add(matrix[row][left]);
                left++;
            }
        }

        return result;
    }
}