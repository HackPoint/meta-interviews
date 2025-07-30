using System.Text;
using Xunit;

namespace Leetcode.Medium.Arrays.Greedy;

/// <summary>
/// ✅ Given a string `s` and an integer `k`, this method **removes all adjacent duplicate characters**
/// in the string such that **exactly `k` duplicates in a row** are removed as a single operation.
/// This process repeats until no more such k-length duplicates remain.
///
/// 🧩 Example:
/// Input: s = "deeedbbcccbdaa", k = 3
/// Step-by-step removal:
/// - "deeedbbcccbdaa" → "ddbcccbdaa"  (removed "eee")
/// - "ddbcccbdaa" → "ddbbdaa"        (removed "ccc")
/// - "ddbbdaa" → "ddaa"              (removed "bb")
/// - "ddaa" → "aa"                   (removed "dd")
/// Output: "aa"
///
/// ⚙️ Approach:
/// - Use a `StringBuilder` to build the resulting string incrementally.
/// - Maintain a `Stack<int>` (`countStack`) in parallel to track **consecutive character counts**.
/// - For each character:
///   - If it matches the last character in `StringBuilder`, increment the count.
///     - If count reaches `k`, remove the last `k - 1` characters (current one is skipped).
///     - Otherwise, append character and push updated count.
///   - If it doesn't match, append character and push count 1.
/// - At the end, return the final built string.
///
/// 📈 Time Complexity:
/// - O(n), where n = length of the string
///   - Each character is processed once and added/removed from StringBuilder at most once.
/// - No nested iteration or recursive rebuilds.
///
/// 🧠 Space Complexity:
/// - O(n) for the `StringBuilder` (in worst case no deletions occur).
/// - O(n) for the `countStack`, which tracks run-lengths per character group.
///
/// 📌 Notes:
/// - This approach avoids using an explicit `(char, count)` stack, which is a common pattern,
///   by using `StringBuilder` as a compact main stack and a parallel count stack.
/// - Space-optimal and highly performant, suitable for large strings.
/// - Easily extendable to more complex "run-removal" rules.
///
/// 🧪 Edge Cases Covered:
/// - Entire string made of same character, e.g., s = "aaaa", k = 2 → "".
/// - No group ever reaches size `k`, e.g., s = "abc", k = 3 → "abc".
/// - Multiple groups overlap across deletions.
/// </summary>
public class RemoveDuplicatesStringsII
{
    public string RemoveDuplicates(string s, int k)
    {
        var sb = new StringBuilder(s.Length);
        var countStack = new Stack<int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (sb.Length > 0 && s[i] == sb[^1])
            {
                int newCount = countStack.Pop() + 1;
                if (newCount == k)
                    sb.Length -= k - 1;
                else
                {
                    sb.Append(s[i]);
                    countStack.Push(newCount);
                }
            }
            else
            {
                sb.Append(s[i]);
                countStack.Push(1);
            }
        }

        return sb.ToString();
    }
}

public class RemoveDuplicatesTests
{
    [Theory]
    [InlineData("abcd", 2, "abcd")] // нет повторений
    [InlineData("deeedbbcccbdaa", 3, "aa")] // несколько удалений подряд
    [InlineData("pbbcggttciiippooaais", 2, "ps")] // сложный случай с многими блоками
    [InlineData("aaa", 3, "")] // одна группа
    [InlineData("aabbccddeeffgg", 2, "")] // всё удаляется
    [InlineData("abcd", 1, "abcd")] // каждый символ удаляется
    [InlineData("aaaaa", 2, "a")] // остаётся один символ после цепочки удалений
    [InlineData("yfttttfbbbbnnnnffbgffffgbbbbgssssgthyyyy", 4, "ybth")] // хардкорный стресс-тест
    public void RemoveDuplicates_CorrectResult(string input, int k, string expected)
    {
        var solution = new RemoveDuplicatesStringsII();
        var result = solution.RemoveDuplicates(input, k);
        Assert.Equal(expected, result);
    }
}