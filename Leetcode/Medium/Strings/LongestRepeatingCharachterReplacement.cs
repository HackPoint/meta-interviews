namespace Leetcode.Medium.Strings;

public class LongestRepeatingCharacterReplacement {
    public int CharacterReplacement(string s, int k) {
        int[] freq = new int[26];
        int left = 0;
        int maxLen = 0,  maxFreq = 0;

        for(int right = 0; right < s.Length; right++) {
            freq[s[right] - 'A']++;
            maxFreq = Math.Max(freq[s[right] - 'A'], maxFreq);
            
            if((right - left + 1) - maxFreq > k) {
                freq[s[left] - 'A']--;
                left++;
            }
            maxLen = Math.Max(maxLen, (right - left + 1));
        }
        return maxLen;
    }
}