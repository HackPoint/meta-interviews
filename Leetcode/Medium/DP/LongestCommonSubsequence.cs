namespace Leetcode.Medium.DP;

/// <summary>
/// Computes the length of the Longest Common Subsequence (LCS) between two input strings.
///
/// A subsequence is a sequence that appears in the same relative order, but not necessarily contiguous.
/// LCS helps compare similarity between sequences — used in diff tools, bioinformatics, etc.
///
/// The algorithm uses Dynamic Programming (2D DP) to build a table of optimal LCS values for all prefixes:
/// • dp[i][j] represents the length of the LCS between the first i characters of text1 and first j of text2
/// • If characters match:    dp[i][j] = dp[i-1][j-1] + 1
/// • Else:                   dp[i][j] = max(dp[i-1][j], dp[i][j-1])
///
/// We can optionally optimize space to O(min(n, m)) by reusing two 1D arrays.
///
/// Time Complexity:  O(n * m)   where n = text1.Length, m = text2.Length  
/// Space Complexity: O(n * m)   (can be optimized to O(min(n, m)) with rolling arrays)
///
/// Key optimizations:
/// • Avoids redundant recomputation using memoized DP
/// • Proper boundary handling via (n+1)x(m+1) matrix avoids index edge-cases
/// </summary>
public class LongestCommonSubsequences
{
    public int LongestCommonSubsequence(string text1, string text2) {
        int n = text1.Length;
        int m = text2.Length;
        int[] dp = new int[m + 1];

        for(int i = 1; i <= n; i++) {
            int prev = 0;

            for(int j = 1; j <= m; j++) {
                int temp = dp[j];

                if(text1[i - 1] == text2[j - 1]) {
                    dp[j] = prev + 1;
                } else {
                    dp[j] = Math.Max(dp[j], dp[j - 1]);
                }

                prev = temp;
            }
        }
        

        return dp[m];
    }   
}