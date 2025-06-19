using System.Text;

namespace Leetcode.Easy.Strings;

public class MergeStringAlternately
{
    public string MergeAlternately(string word1, string word2)
    {
        var sb = new StringBuilder();
        int left = 0, right = 0;
        while (word1.Length > left || right < word2.Length)
        {
            if (word1.Length > left)
                sb.Append(word1[left]);
            if (word2.Length > right)
                sb.Append(word2[right]);
            left++;
            right++;
        }

        return sb.ToString();
    }
}