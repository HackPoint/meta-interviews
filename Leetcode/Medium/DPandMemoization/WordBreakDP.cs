namespace Leetcode.Medium.DpAndMemoization;

public class WordBreakDp {
    public bool WordBreakI(string s, IList<string> wordDict) {
        var cache = new HashSet<string>(wordDict);
        Span<bool> dp = stackalloc bool[s.Length + 1];
        dp[0] = true;

        for(int i = 1; i <= s.Length; i++) {
            for(int j = 0; j < i; j++) {
                if(dp[j] && cache.Contains(s.Substring(j, i - j))) {
                    dp[i] =true;
                    break;
                }
            }
        }
        return dp[s.Length];
    }
    
    public bool WordBreakII(string s, IList<string> wordDict) {
        var cache = new HashSet<string>(wordDict);
        int n = s.Length;
        var minLen = wordDict.Min(w => w.Length);
        var maxLen = wordDict.Max(w => w.Length);

        Span<bool> dp = stackalloc bool[n + 1];
        dp[0] = true;

        ReadOnlySpan<char> span = s;

        for (int i = 1; i <= n; i++) {
            for (int len = minLen; len <= Math.Min(maxLen, i); len++) {
                if (!dp[i - len]) continue;

                if (cache.Contains(span.Slice(i - len, len).ToString())) {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n];
    }
}