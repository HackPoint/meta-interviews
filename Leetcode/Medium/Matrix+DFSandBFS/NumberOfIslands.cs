namespace Leetcode.Medium.Matrix_DFSandBFS;

public class NumberOfIslands {
    public int NumIslands(char[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        var visited = new bool[rows, cols];
        int count = 0;

        for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            if (!visited[i, j] && grid[i][j] == '1') {
                DFS(i, j);
                count++;
            }

        return count;

        void DFS(int row, int col) {
            if (row < 0 || row >= rows || col < 0 || col >= cols) return;
            if (visited[row, col] || grid[row][col] != '1') return;

            visited[row, col] = true;

            DFS(row + 1, col);
            DFS(row - 1, col);
            DFS(row, col + 1);
            DFS(row, col - 1);
        }
    }
}