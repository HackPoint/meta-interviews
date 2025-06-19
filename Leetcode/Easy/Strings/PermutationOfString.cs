namespace Leetcode.Easy.Strings;

public class PermutationOfString
{
    public bool CheckInclusion(string s1, string s2)
    {
        int[] freqS1 = new int[26];
        int[] freqS2 = new int[26];

        foreach (char c in s1)
            freqS1[c - 'a']++;

        for (int right = 0; right < s2.Length; right++)
        {
            freqS2[s2[right] - 'a']++;
            if (right >= s1.Length)
                freqS2[s2[right - s1.Length] - 'a']--;

            if (IsMatch(freqS1, freqS2)) return true;
        }

        return false;
        
        bool IsMatch(int[] a, int[] b)
        {
            for (int i = 0; i < 26; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }
    
}