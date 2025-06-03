namespace Leetcode.Medium.LinkedLists;

public class LongestPalindromicSubstrings {
    string LongestPalindrome(string s) {
        int startIndex = 0, maxLen = 0;

        for (int i = 0; i < s.Length; ++i) {
            int len1 = ExpandAroundCenter(s, i, i);
            int len2 = ExpandAroundCenter(s, i, i + 1);
            int len = Math.Max(len1, len2);

            if (len > maxLen) {
                maxLen = len;
                startIndex = i - (len - 1) / 2;
            }
        }

        return s.Substring(startIndex, maxLen);
    }

    int ExpandAroundCenter(string s, int left, int right) {
        while (left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }

        return right - left - 1;
    }
}