namespace Leetcode.Easy.Strings;

public class LengthOfLastWords
{
    public int LengthOfLastWord(string s)
    {
        return s.Trim().Split(' ')[^1].Length;
    }
}