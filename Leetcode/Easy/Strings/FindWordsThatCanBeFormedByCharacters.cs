namespace Leetcode.Easy.Strings;

public class FindWordsThatCanBeFormedByCharacters
{
    public int CountCharacters(string[] words, string chars)
    {
        int totalLength = 0;
        Span<int> charsFreq = stackalloc int[26];
        foreach (char ch in chars)
            charsFreq[ch - 'a']++;

        foreach (string word in words)
        {
            int[] wordFreq = new int[26];
            foreach (char ch in word)
                wordFreq[ch - 'a']++;

            bool isValid = true;

            for (char c = 'a'; c <= 'z'; c++)
            {
                if (wordFreq[c - 'a'] > charsFreq[c - 'a'])
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
                totalLength += word.Length;
        }

        return totalLength;
    }
}