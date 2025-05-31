using System.Text;

namespace Leetcode.Medium.Backtracking;

public class GenerateParanthesises {
    /*
     * Input: n=3
     * Output: ["((()))","(()())","(())()","()(())","()()()"]
     */
// GenerateParenthesis(3);
    IList<string> GenerateParenthesis(int n) {
        IList<string> result = new List<string>();
        Backtrack(new StringBuilder(), 0, 0, n, result);
        Console.WriteLine(string.Join("\n", result.Select(list => "[" + string.Join(", ", list) + "]")));
        return result;
    }

    void Backtrack(StringBuilder sb, int open, int close, int depth, IList<string> result) {
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
    }
}