namespace Leetcode.Easy.Strings;

public class DetectCapitals
{
    public bool DetectCapitalUse(string word)
    {
        int lower = 0, upper = 0;
        int total = word.Length;

        foreach (char c in word)
        {
            if (char.IsUpper(c))
            {
                upper++;
            }

            if (char.IsLower(c))
            {
                lower++;
            }
        }

        if (total - lower == 0) return true;
        if (total - upper == 0) return true;
        if (char.IsUpper(word[0]) && total - lower == 1) return true;

        return false;
    }
}