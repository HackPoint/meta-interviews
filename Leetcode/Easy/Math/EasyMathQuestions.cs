namespace Leetcode.Easy.Math;

public class EasyMathQuestions
{
    public bool IsPalindrome(int x) {
        if(x < 0 || (x % 10 == 0 && x != 0)) return false;
        int reversed = 0;
        while(x > reversed) {
            int digit = x % 10;
            reversed = reversed * 10 + digit;
            x = x / 10;
        }
        return x == reversed || x == reversed / 10;
    }
    
    public int TitleToNumber(string columnTitle) {
        int result = 0;
        foreach(char c in columnTitle) {
            int val = c - 'A' + 1;
            result = result * 26 + val;
        }

        return result;
    }
}