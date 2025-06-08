using System.Text;

namespace Leetcode.Easy.Stacks;

public class RemoveOutermostParentheses
{
    public string RemoveOuterParentheses(string s)
    {
        var sb = new StringBuilder();
        int depth = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                if (depth > 0)
                    sb.Append('(');
                depth++;
            }
            else
            {
                depth--;
                if (depth > 0)
                    sb.Append(')');
            }
        }
        return sb.ToString();
    }
}