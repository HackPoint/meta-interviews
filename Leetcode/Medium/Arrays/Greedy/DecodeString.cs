using System.Text;
using Xunit;

namespace Leetcode.Medium.Arrays.Greedy;

public class DecodeStrings
{
    public string DecodeString(string s)
    {
        var countStack = new Stack<int>();
        var builderStack = new Stack<StringBuilder>();
        var current = new StringBuilder();
        int i = 0;

        while (i < s.Length)
        {
            if (char.IsDigit(s[i]))
            {
                int count = 0;

                // Efficient digit accumulation: supports multi-digit like 12[ab]
                while (i < s.Length && char.IsDigit(s[i]))
                {
                    count = count * 10 + (s[i] - '0');
                    i++;
                }

                countStack.Push(count);
            }
            else if (s[i] == '[')
            {
                builderStack.Push(current);
                current = new StringBuilder();
                i++;
            }
            else if (s[i] == ']')
            {
                int repeat = countStack.Pop();
                var prev = builderStack.Pop();
                for (int r = 0; r < repeat; r++)
                    prev.Append(current);

                current = prev;
                i++;
            }
            else // regular character
            {
                current.Append(s[i]);
                i++;
            }
        }

        return current.ToString();
    }
}

public class DecodeStringTests
{
    [Fact]
    public void Should_Parse_NumbersAsIt_Reads_String()
    {
        var decoder = new DecodeStrings();
        string res = decoder.DecodeString("12[ab]");
        Assert.Equal(24, res.Length);
        Assert.Equal("abababababababababababab", res);
    }
}