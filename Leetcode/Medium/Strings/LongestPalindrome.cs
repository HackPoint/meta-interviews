namespace Leetcode.Medium.Strings;

public class LongestPalindromes
{
    public int LongestPalindrome(string s)
    {
        Span<int> freq = stackalloc int[128];
        int longest = 0;

        foreach (char c in s)
        {
            freq[c - 'A']++;
            if (freq[c - 'A'] % 2 == 0)
            {
                longest += 2;
            }
        }

        foreach (var f in freq)
        {
            if (f % 2 == 1)
            {
                longest++;
                break;
            }
        }

        return longest;
    }
}