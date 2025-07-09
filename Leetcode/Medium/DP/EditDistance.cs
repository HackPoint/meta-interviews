namespace Leetcode.Medium.DP;

/*
         ""  r   o   s
      ----------------
   "" |  0   1   2   3
   h  |  1   1   2   3
   o  |  2   2   1   2
   r  |  3   2   2   2
   s  |  4   3   3   2å
   e  |  5   4   4   3
*/
public class EditDistance
{
    /// <summary>
    /// Classification:
    /// Algorithm: Dynamic Programming (1D Space Optimization)
    /// Explanation:
    /// Instead of a 2D DP array, we use two 1D arrays: `prev` (i-1 row) and `curr` (i row)
    /// Time Complexity: O(n * m)
    /// Space Complexity: O(m)
    /// </summary>
    public int MinDistanceI(string word1, string word2) {
        int n = word1.Length, m = word2.Length;

        if (n == 0) return m;
        if (m == 0) return n;

        int[] prev = new int[m + 1];
        int[] curr = new int[m + 1];

        // Base case: converting empty word1 to word2
        for (int j = 0; j <= m; j++) {
            prev[j] = j;
        }

        for (int i = 1; i <= n; i++) {
            curr[0] = i; // converting word1[..i] to empty string
            for (int j = 1; j <= m; j++) {
                if (word1[i - 1] == word2[j - 1]) {
                    curr[j] = prev[j - 1]; // no operation needed
                } else {
                    curr[j] = 1 + Math.Min(
                        prev[j],       // delete
                        Math.Min(
                            curr[j - 1],   // insert
                            prev[j - 1]    // replace
                        )
                    );
                }
            }
            // Move current to previous
            Array.Copy(curr, prev, m + 1);
        }

        return prev[m];
    }

    /// <summary>
    /// Classification:
    /// Algorithm: Dynamic Programming (2D Bottom-Up)
    /// Explanation:
    /// dp[i,j] stores the minimum operations needed to convert first i chars of word1 to first j chars of word2.
    /// Operations considered: insert, delete, replace.
    /// Time Complexity: O(n * m)
    /// Space Complexity: O(n * m)
    /// </summary>
    public int MinDistanceII(string word1, string word2)
    {
        int n = word1.Length, m = word2.Length;
        int[,] dp = new int[n + 1, m + 1];
        
        // Base cases
        for (int i = 0; i <= n; i++) dp[i, 0] = i;
        for (int j = 0; j <= m; j++) dp[0, j] = j;
        
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = 1 + Math.Min(
                        dp[i - 1, j],
                        Math.Min(dp[i, j - 1], dp[i - 1, j - 1])
                    );
                }
            }
        }

        return dp[n, m];
    }
}