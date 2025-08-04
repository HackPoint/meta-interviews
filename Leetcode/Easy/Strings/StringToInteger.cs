using Xunit;

namespace Leetcode.Easy.Strings;

/// <summary>
/// Converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).
/// The function discards leading whitespaces, handles optional '+'/'-' sign,
/// reads digits until a non-digit is found, and clamps the result between Int32.MinValue and Int32.MaxValue.
///
/// Approach:
/// - Trim whitespace
/// - Check for optional sign
/// - Convert digits to integer
/// - Check for overflow before multiplying/adding
///
/// Time Complexity: O(n) — where n is the length of the input string
/// Space Complexity: O(1) — constant extra space
///
/// Edge Cases:
/// - Overflow beyond 32-bit range
/// - Input contains non-digit characters
/// - Leading whitespace
/// - Empty string or string without digits
///
/// Example:
/// Input: "   -42"
/// Output: -42
/// </summary>
public class StringToInteger
{
    public int MyAtoi(string s)
    {
        const int MAX = int.MaxValue;
        const int MIN = int.MinValue;

        int n = s.Length; // size of string
        int result = 0;
        int sign = 1;

        int index = 0;

        // 1. Skip leading whitespaces
        while (index < n && s[index] == ' ')
        {
            index++;
        }

        if (index == n) return 0;

        // 2. Handle optional '+' or '-' sign
        if (s[index] == '+')
        {
            sign = 1;
            index++;
        }
        else if (s[index] == '-')
        {
            sign = -1;
            index++;
        }

        // 3. Convert digits and handle overflow
        while (index < n && char.IsDigit(s[index]))
        {
            int digit = s[index] - '0';

            // Check overflow condition BEFORE multiplying
            if (result > (MAX - digit) / 10)
                return sign == 1 ? MAX : MIN;

            result = result * 10 + digit;
            index++;
        }

        return sign * result;
    }

    public class StringToIntegerTests
    {
        private readonly StringToInteger _solution = new();

        [Theory]
        [InlineData("42", 42)]
        [InlineData("   -42", -42)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        [InlineData("-91283472332", int.MinValue)] // underflow
        [InlineData("91283472332", int.MaxValue)] // overflow
        [InlineData("", 0)]
        [InlineData("   ", 0)]
        [InlineData("+1", 1)]
        [InlineData("+-12", 0)]
        [InlineData("00000-42a1234", 0)]
        [InlineData("   +0 123", 0)]
        public void Atoi_CorrectResult(string input, int expected)
        {
            var result = _solution.MyAtoi(input);
            Assert.Equal(expected, result);
        }
    }
}