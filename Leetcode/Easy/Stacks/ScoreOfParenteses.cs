namespace Leetcode.Easy.Stacks;

public class ScoreOfParenthesess
{
    public int ScoreOfParentheses(string s)
    {
        int depth = 0;
        int score = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                depth++;
            else
            {
                depth--;
                if (s[i - 1] == '(')
                    score += (int)System.Math.Pow(2, depth);
            }
        }

        return score;
    }
    /*public int ScoreOfParentheses(string s)
    {
        var stack = new Stack<int>();
        stack.Push(0);
        
        foreach (var c in s)
        {
            if (c == '(')
            {
                stack.Push(0);
            }
            else
            {
                int inner = stack.Pop();
                int outer = stack.Pop();
                int score = inner == 0 ? 1 : 2 * inner;
                stack.Push(outer + score);
            }
        }

        return stack.Pop();
    }*/
}