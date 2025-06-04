namespace Leetcode.Easy.Strings;

public class ValidAnagram
{
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) return false;
        
        Span<int> left = stackalloc int[26];
        foreach (char c in s)
            left[c - 'a']++;
        
        Span<int> right = stackalloc int[26];
        foreach (char c in t)
            right[c - 'a']++;

        return right.SequenceCompareTo(left) == 0;
    }
}