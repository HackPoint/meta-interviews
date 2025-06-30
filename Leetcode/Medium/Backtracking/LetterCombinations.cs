namespace Leetcode.Medium.Backtracking;

public class LetterCombinationsPerformanceImprovement
{
    private static readonly string[] digitToLetters =
    [
        "", "", "abc", "def", "ghi",
        "jkl", "mno", "pqrs", "tuv", "wxyz"
    ];

    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits))
            return [];

        int n = digits.Length;
        Span<char> buffer = stackalloc char[n];
        var result = new List<string>(CalculateCapacity(digits));
        Backtrack(0, digits, buffer, result);
        Console.WriteLine(string.Join("\n", result.Select(list => "[" + string.Join(", ", list) + "]")));

        return result;
    }

    private void Backtrack(int index, string digits, Span<char> buffer, List<string> result)
    {
        if (index == digits.Length)
        {
            result.Add(string.Create(buffer.Length, buffer, (span, state) => state.CopyTo(span)));
            return;
        }

        int digit = digits[index] - '0';
        string letters = digitToLetters[digit];

        foreach (char letter in letters)
        {
            buffer[index] = letter;
            Backtrack(index + 1, digits, buffer, result);
        }
    }

    private int CalculateCapacity(string digits)
    {
        int total = 1;
        foreach (char c in digits)
            total *= digitToLetters[c - '0'].Length;
        return total;
    }
}