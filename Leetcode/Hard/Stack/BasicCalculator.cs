namespace Leetcode.Hard.Stack;

/// <summary>
/// Classification: Expression Evaluation
/// Algorithm: Iterative stack, one-pass manual parsing (no recursion)
/// Time  O(n)    | Space O(n) (stack for signs / partial sums)
/// </summary>
public class BasicCalculator
{
    public int Calculate(string s) {
        // 1) Предудаляем пробелы, чтобы не проверять ' ' в основном цикле
        Span<char> clean = stackalloc char[s.Length];
        int len = 0;
        foreach (char ch in s)
            if (ch != ' ') clean[len++] = ch;

        // 2) Стек для хранения пред. сумм и знаков при входе в '('
        var stackSum  = new Stack<int>();
        var stackSign = new Stack<int>();

        long result = 0;     // текущая сумма на уровне
        long num    = 0;     // текущее число
        int  sign   = 1;     // +1 или -1

        for (int i = 0; i < len; i++) {
            char ch = clean[i];

            // Быстрая проверка цифры: ASCII '0'..'9'
            if ((uint)(ch - '0') <= 9) {
                num = num * 10 + (ch - '0');
            }
            else if (ch == '+' || ch == '-') {
                result += sign * num;
                num = 0;
                sign = (ch == '+') ? 1 : -1;
            }
            else if (ch == '(') {
                // Сохраняем текущую сумму и знак
                stackSum.Push((int)result);
                stackSign.Push(sign);
                // Сбрасываем контекст
                result = 0;
                sign   = 1;
            }
            else if (ch == ')') {
                result += sign * num;      // завершаем подвыражение
                num = 0;
                result = stackSum.Pop() + stackSign.Pop() * result;
            }
        }
        // Добавляем последнее число после цикла
        result += sign * num;
        return (int)result;
    }
}