namespace Leetcode.Easy.Strings;

public class ValidPalindromeII
{
    public bool ValidPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (s[left] != s[right])
            {
                return IsPalindrome(left + 1, right) || IsPalindrome(left, right - 1);
            }

            left++;
            right--;
        }

        return true;

        bool IsPalindrome(int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                    return false;
                start++;
                end--;
            }

            return true;
        }
    }
}