namespace Leetcode.MockInterviews;

public class BasicCalculatorII
{
    public int Calculate(string s) {
        var stack = new Stack<int>();
        char sign = '+';
        int num = 0;
        int n = s.Length;
        
        for(int i = 0; i < n; i++) {
            char c = s[i];
            
            if(char.IsDigit(c)) {
                num = num * 10 + (c - '0');
            }
            
            if((!char.IsDigit(c) && c != ' ') || i == n - 1) {
                switch(sign) {
                    case '+': stack.Push(num); break;
                    case '-': stack.Push(-num); break;
                    case '*': stack.Push(stack.Pop() * num); break;
                    case '/': stack.Push(stack.Pop() / num); break;                        
                }
                sign = c;
                num = 0;
            }
        }
        
        return stack.Sum();
    }
}