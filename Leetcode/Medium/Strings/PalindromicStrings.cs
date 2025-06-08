namespace Leetcode.Medium.Strings;

public class PalindromicStrings {
    public int CountSubstrings(string s) {
        int n = s.Length;
        int count = 0;

        for(int center = 0; center < (n * 2 - 1); center++) {
            int left = center / 2;
            int right =  left + (center % 2);

            while(left >= 0 && right < n && s[left] == s[right]) {
                count++;
                left--;
                right++;
            }
        }

        return count;
    }
}