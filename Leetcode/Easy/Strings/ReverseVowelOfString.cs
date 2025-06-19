namespace Leetcode.Easy.Strings;

public class ReverseVowelOfString
{
    public string ReverseVowels(string s)
    {
        Span<char> chars = s.Length <= 256 
            ? stackalloc char[s.Length]
            : new char[s.Length];

        s.AsSpan().CopyTo(chars);

        var vowels = new HashSet<char>("aeiouAEIOU");
        int left = 0, right = chars.Length - 1;

        while (left < right)
        {
            if (!vowels.Contains(chars[left])) { left++; continue; }
            if (!vowels.Contains(chars[right])) { right--; continue; }

            (chars[left], chars[right]) = (chars[right], chars[left]);
            left++;
            right--;
        }

        return new string(chars);
    }
    
    public string ReverseVowelsLower(string s)
    {
        char[] chars = s.ToCharArray();
        var vowels = new HashSet<char>(['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U']);
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            if (!vowels.Contains(chars[left]))
            {
                left++;
                continue;
            }

            if (!vowels.Contains(chars[right]))
            {
                right--;
                continue;
            }

            (chars[left], chars[right]) = (chars[right], chars[left]);
            left++;
            right--;
        }

        return new string(chars);
    }
}