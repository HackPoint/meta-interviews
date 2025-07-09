using System.Text;

namespace Leetcode.Hard.Arrays.BSArrays;

/// <summary>
/// Classification:
/// Algorithm: BFS + Integer Encoding
/// Explanation:
/// Optimal solution using Breadth-First Search (BFS) where each board state is encoded
/// as an integer (e.g., 123450). We avoid string or matrix comparisons and use a
/// HashSet for constant-time visited state checking. Movement is defined through
/// precomputed neighbor mappings based on the position of the zero.
/// Time Complexity:   O(n * 6!)   — worst case state space (720 permutations)
/// Space Complexity:  O(6!)       — to track visited states
/// </summary>
public class SlidingPuzzles
{
    public int SlidingPuzzle(int[][] board) {
        string state = Flatten(board);
        var stepsMap = StepsMap(2, 3);
        var visited = new HashSet<string>();
        var queue = new Queue<(string config, int moves)>();
        const string target = "123450";

        // init
        queue.Enqueue((state, 0));
        visited.Add(state);

        while(queue.Count > 0) {
            var (curr, moves) = queue.Dequeue();
            if(curr == target) return moves;

            int zeroIndex = curr.IndexOf('0');

            foreach(int neighbor in stepsMap[zeroIndex]) {
                string next = Swap(curr, zeroIndex, neighbor);

                if(visited.Add(next)) {
                    queue.Enqueue((next, moves + 1));
                    Console.WriteLine($"Move {moves + 1}:");
                    PrintState(next);
                }
            }
        }

        return -1;
    }

    private string Swap(string state, int i, int j) {
        var arr = state.ToCharArray();
        (arr[i], arr[j]) = (arr[j], arr[i]);
        return new string(arr);
    }

    private string Flatten(int[][] board) {
        var sb = new StringBuilder();
        foreach(var row in board) {
            foreach(var col in row) {
                sb.Append(col);
            }
        }
        return sb.ToString();
    }

    private Dictionary<int, List<int>> StepsMap(int rows, int cols) {
        var stepsMap = new Dictionary<int, List<int>>();
        int[][] directions = new int[][] {
           [0, 1],  // right
           [0, -1], // left
           [1, 0],  // down
           [-1, 0]  // up
        };

        for(int row = 0; row < rows; row++) {
            for(int col = 0; col < cols; col++) {
                int index = row * cols + col;
                stepsMap[index] = new List<int>();

                foreach(int[] dir in directions) {
                    int newRow = row + dir[0];
                    int newCol = col + dir[1];

                    // fixed boundries for not stepping outside of matrix
                    if(newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols) {
                        int neighbourIndex = newRow * cols + newCol;
                        stepsMap[index].Add(neighbourIndex);
                    }
                }
            }
        }
        return stepsMap;
    }
    
    private void PrintState(string state)  {
        for (int i = 0; i < state.Length; i++) {
            Console.Write(state[i] + " ");
            if (i == 2) Console.WriteLine();
        }
        Console.WriteLine();
    }
}