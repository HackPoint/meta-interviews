namespace Leetcode.Easy.Strings;

public class FirstUniqueCharacterInString {
    public int FirstUniqChar(string s) {
        Span<int> freq = stackalloc int[26];

        foreach (var ch in s) {
            freq[ch - 'a']++;
        }

        for (int i = 0; i < s.Length; i++) {
            if (freq[s[i] - 'a'] == 1) return i;
        }
        
        return -1;
    }
}