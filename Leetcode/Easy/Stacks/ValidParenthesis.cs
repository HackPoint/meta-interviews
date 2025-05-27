namespace Leetcode.Easy.Stacks;

public class ValidParenthesis {
    public bool IsValid(string s) {
        if(string.IsNullOrEmpty(s)) return false;
        var p = new Dictionary<char, char> {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'}
        };
        var stack = new Stack<char>();
        foreach (var c in s) {
            if (p.ContainsKey(c)) {
                stack.Push(c);
            }
            else {
                if (stack.Count == 0) return false;
                char open = stack.Pop();
                if (p[open] != s[c]) return false;
            }
        }
        return stack.Count == 0;
    }
}
