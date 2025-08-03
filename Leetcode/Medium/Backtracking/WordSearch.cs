using Xunit;

namespace Leetcode.Medium.Backtracking;

/// <summary>
/// Problem:
/// Given a 2D board of characters and a word, return true if the word exists in the board.
/// The word must be constructed from letters of sequentially adjacent cells,
/// where "adjacent" cells are horizontally or vertically neighboring.
/// The same letter cell may not be used more than once.
///
/// Approach:
/// This is a classical backtracking and DFS search on a 2D matrix.
/// For each cell in the matrix:
/// - If the character matches the first letter of the word,
///   initiate a DFS search with backtracking.
/// 
/// During DFS:
/// - At each step, check 4 possible directions (up, down, left, right).
/// - If the current character matches the corresponding position in the word,
///   proceed recursively to the next character.
/// - Mark visited cells temporarily (e.g., by using '#' to avoid revisiting).
/// - Backtrack by restoring the character after recursion.
///
/// Optimization:
/// - Before DFS starts, `CanExist` checks if the board contains enough letters
///   to possibly form the word using frequency counting.
///   If it doesn't, we return early (prunes impossible inputs).
///
/// Time Complexity:
/// - Worst case: O(N * M * 4^L), where:
///   - N, M = board dimensions
///   - L = length of the word
///   For each cell, we can branch up to 4 directions at each step in the word.
/// 
/// Space Complexity:
/// - O(L) for the recursion stack (L = length of word)
/// - O(1) additional space if we mark cells in-place
///
/// Edge Cases Considered:
/// - Word uses the same cell twice (invalid)
/// - Single-cell board with/without match
/// - Diagonal matches (disallowed)
/// - Early pruning when board cannot satisfy word (frequency-based)
///
/// Exam
public class WordSearch
{
    public bool Exist(char[][] board, string word)
    {
        if (!CanExist(board, word)) return false;

        int n = board.Length;
        int m = board[0].Length;

        (int dx, int dy)[] directions =
        [
            (0, 1), // right
            (0, -1), // left
            (1, 0), // down
            (-1, 0) // up
        ];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                if (Dfs(row, col, 0))
                    return true;
            }
        }

        return false;

        bool Dfs(int row, int col, int position)
        {
            if (position == word.Length) return true; // Base case: all characters matched
            if (row < 0 || row >= n || col < 0 || col >= m) return false; // Out of bounds
            if (board[row][col] == '#' || board[row][col] != word[position])
                return false; // Already visited or mismatch

            // mark visited cell (visited) = '#"
            char temp = board[row][col];
            board[row][col] = '#';

            foreach (var dir in directions)
            {
                int newRow = row + dir.dx;
                int newCol = col + dir.dy;
                if (Dfs(newRow, newCol, position + 1))
                {
                    board[row][col] = temp; // unmark before return
                    return true;
                }
            }

            board[row][col] = temp; // backtrack
            return false;
        }
    }


    private bool CanExist(char[][] board, string word)
    {
        var boardFreq = new Dictionary<char, int>();
        foreach (var row in board)
        foreach (var c in row)
            boardFreq[c] = boardFreq.GetValueOrDefault(c) + 1;

        foreach (char c in word)
        {
            if (!boardFreq.ContainsKey(c)) return false;
            if (--boardFreq[c] < 0) return false;
        }

        return true;
    }
}

public class WordSearchTests
{
    private readonly WordSearch _solver = new();

    [Fact]
    public void Basic_TruePath_Horizontal()
    {
        char[][] board =
        {
            new[] { 'A', 'B', 'C', 'E' },
            new[] { 'S', 'F', 'C', 'S' },
            new[] { 'A', 'D', 'E', 'E' }
        };
        Assert.True(_solver.Exist(board, "ABCCED"));
    }

    [Fact]
    public void Basic_TruePath_Vertical()
    {
        char[][] board =
        {
            new[] { 'A', 'B' },
            new[] { 'C', 'D' }
        };
        Assert.True(_solver.Exist(board, "AC"));
    }

    [Fact]
    public void Basic_False_WrongPath()
    {
        char[][] board =
        {
            new[] { 'A', 'B', 'C', 'E' },
            new[] { 'S', 'F', 'C', 'S' },
            new[] { 'A', 'D', 'E', 'E' }
        };
        Assert.False(_solver.Exist(board, "ABCB"));
    }

    [Fact]
    public void Diagonal_NotAllowed_Fails()
    {
        char[][] board =
        {
            new[] { 'A', 'B' },
            new[] { 'C', 'D' }
        };
        Assert.False(_solver.Exist(board, "AD"));
    }

    [Fact]
    public void UsesSameCellTwice_Fails()
    {
        char[][] board =
        {
            new[] { 'A', 'A' }
        };
        Assert.False(_solver.Exist(board, "AAA"));
    }

    [Fact]
    public void WordIsSingleLetter_Exists()
    {
        char[][] board =
        {
            new[] { 'A', 'B' },
            new[] { 'C', 'D' }
        };
        Assert.True(_solver.Exist(board, "D"));
    }

    [Fact]
    public void WordIsSingleLetter_NotExists()
    {
        char[][] board =
        {
            new[] { 'A', 'B' },
            new[] { 'C', 'D' }
        };
        Assert.False(_solver.Exist(board, "E"));
    }

    [Fact]
    public void LongWord_NoMatch()
    {
        char[][] board =
        {
            new[] { 'A', 'B' },
            new[] { 'C', 'D' }
        };
        Assert.False(_solver.Exist(board, "ABCDEFGHIJKLMNOP"));
    }

    [Fact]
    public void EdgeCase_OneByOneBoard_AndMatch()
    {
        char[][] board =
        {
            new[] { 'X' }
        };
        Assert.True(_solver.Exist(board, "X"));
    }

    [Fact]
    public void EdgeCase_OneByOneBoard_NoMatch()
    {
        char[][] board =
        {
            new[] { 'X' }
        };
        Assert.False(_solver.Exist(board, "Y"));
    }
}