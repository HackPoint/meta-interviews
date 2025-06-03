namespace Leetcode.Easy.LinkedList.TwoPointer.Strings;

public class LongestCommonPrefixes
{
    public string LongestCommonPrefix(string[] strs)
    {
        string prefix = string.Empty;

        for (int i = 0; i < strs[0].Length; i++)
        {
            char c = strs[0][i];
            Console.WriteLine($"Checking char '{c}' at position {i}");
            for (int j = 1; j < strs.Length; j++)
            {
                if (i >= strs[j].Length || strs[j][i] != c)
                {
                    Console.WriteLine($"Mismatch found at string {j}, position {i}");
                    return prefix;
                }
            }
            prefix += c;
            Console.WriteLine($"Prefix now: {prefix}");
        }

        return prefix;
    }
}