namespace Leetcode.Easy.Strings;

public class LongPressedNames
{
    /*
     * Input: name = "alex", typed = "aaleex"
       Output: true
       Explanation: 'a' and 'e' in 'alex' were long pressed.
     */
    bool IsLongPressedName(string name, string typed)
    {
        int left = 0, right = 0;
        while (typed.Length > right)
        {
            if (left < name.Length && name[left] == typed[right])
            {
                left++;
                right++;
            }
            else if (right > 0 && typed[right] == typed[right - 1])
                right++;
            else
                return false;
        }

        return left == name.Length;
    }
}