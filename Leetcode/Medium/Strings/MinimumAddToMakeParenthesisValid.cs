namespace Leetcode.Medium.Strings;

public class MinimumAddToMakeParenthesisValid
{
    public int MinAddToMakeValid(string s) {
        if(string.IsNullOrEmpty(s)) return 0;
        int balance = 0, insertions = 0;
        foreach(char c in s) {
            if(c == '(') {
                balance++;
            } else if(c == ')' && balance > 0) {
                balance--;
            } else {
                insertions++;
            }
        }
        
        return insertions + balance;
    }
}