namespace Leetcode.Medium.DP;

/// <summary>
/// Calculates the number of ways to decode a given string of digits into letters,
/// where '1' maps to 'A', '2' to 'B', ..., and '26' to 'Z'.
///
/// This solution uses Dynamic Programming with a 1D array `dp`,
/// where `dp[i]` represents the number of ways to decode the substring `s[0..i-1]`.
///
/// For each position `i` (starting from 2), the algorithm checks two conditions:
/// • If the current digit `s[i - 1]` is valid (not '0'), then `dp[i] += dp[i - 1]`
/// • If the two-digit number `s[i - 2..i - 1]` is between "10" and "26", then `dp[i] += dp[i - 2]`
///
/// Edge cases are handled:
/// • A leading '0' invalidates decoding, so `dp[1]` is set to 0 in that case
/// • Empty string returns 0
///
/// Time Complexity:  O(n)
/// Space Complexity: O(n) — but can be reduced to O(1) using two variables
///
/// Example:
/// Input: "226"
/// Possible decodings: "BZ" (2 26), "VF" (22 6), "BBF" (2 2 6) → Output: 3
/// </summary>
public class DecodeWays
{
    public int NumDecodings(string s) {
        int n = s.Length;
        if(n == 0) return 0;

        int[] dp = new int[n + 1];

        dp[0] = 1;
        dp[1] = s[0] != '0' ? 1 : 0;

        for(int i = 2; i <= n; i++) {
            if(s[i - 1] != '0') {
                dp[i] += dp[i - 1];
            } 

            if (s[i - 2] == '1' || (s[i - 2] == '2' && s[i - 1] <= '6')) {
                dp[i] += dp[i - 2];
            }

        }

        return dp[n];
    }
}