namespace Leetcode.Easy.LinkedList.TwoPointer.Strings;

public class ReverseInPlaces
{
    public void ReverseInPlace(char[] s)
    {
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            (s[left], s[right]) = (s[right], s[left]);
            left++;
            right--;
        }
    }
}