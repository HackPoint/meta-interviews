namespace Leetcode.Medium.Strings;

public class ValidParenthesisString
{
    public bool CheckValidString(string s)
    {
        char any = '*', open = '(', close = ')';
        int minOpen = 0;
        int maxOpen = 0;

        foreach (char c in s)
        {
            if (c == open)
            {
                minOpen++;
                maxOpen++;
            }
            else if (c == close)
            {
                minOpen--;
                maxOpen--;
            }
            else if (any == c)
            {
                maxOpen++;
                minOpen--;
            }
            
            if (maxOpen < 0)
            {
                return false;
            }

            minOpen = Math.Max(minOpen, 0);
        }

      
        return minOpen == 0;
    }

    /*void Backtrack(StringBuilder sb, int open, int close, int depth, IList<string> result) {
        if (sb.Length == 2 * depth) {
            result.Add(sb.ToString());
            return;
        }

        if (open < depth) {
            sb.Append('(');
            Backtrack(sb, open + 1, close, depth, result);
            sb.Length--;
        }

        if (close < open) {
            sb.Append(')');
            Backtrack(sb, open, close + 1, depth, result);
            sb.Length--;
        }
    }*/
}