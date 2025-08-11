using Xunit;

namespace Leetcode.Easy.Arrays;

/// <summary>
/// ✅ Given an integer array <paramref name="nums"/>, this method **computes the sum of all elements that occur exactly once**.
///
/// 🧩 Example:
/// Input: nums = [1, 2, 3, 2]
/// Frequency count:
/// - 1 → appears once → ✅ add 1
/// - 2 → appears twice → ❌ skip
/// - 3 → appears once → ✅ add 3
/// Sum = 1 + 3 = 4
///
/// ⚙️ Approach:
/// - Step 1: Use a <see cref="Dictionary{TKey, TValue}"/> (`unique`) to count occurrences of each number.
///   - If a number is **not in the dictionary**, insert it with count = 1.
///   - If it already exists, increment its count.
/// - Step 2: Iterate through the dictionary:
///   - If a number’s count is exactly 1 → add it to the sum.
///   - If a number appears more than once → skip it.
/// - Step 3: Return the computed sum.
///
/// 📈 Time Complexity:
/// - O(n), where n = number of elements in <paramref name="nums"/>.
///   - First pass: O(n) for counting.
///   - Second pass: O(k) where k = number of distinct elements.
///   - Overall: O(n).
///
/// 🧠 Space Complexity:
/// - O(k), where k = number of distinct integers in <paramref name="nums"/>.
///   - Dictionary stores counts for unique numbers only.
///
/// 📌 Notes:
/// - This is a **two-pass** solution: first pass counts occurrences, second pass computes the sum.
/// - Works with negative numbers, zero, and large integers.
/// - Deterministic — no reliance on ordering or sorting.
///
/// 🧪 Edge Cases Covered:
/// - Empty array → sum = 0.
/// - All elements unique → sum = sum of all elements.
/// - All elements identical → sum = 0.
/// - Mix of negative and positive unique numbers.
/// - Large value ranges and integer extremes.
/// </summary>
public class SumOfUniqueElements {
    public int SumOfUnique(int[] nums) {
        var unique = new Dictionary<int, int>();
        int sum = 0;

        foreach (var num in nums) {
            if (!unique.TryAdd(num, 1)) {
                unique[num]++;
            }
        }

        foreach (var kvp in unique) {
            if (kvp.Value == 1) {
                sum += kvp.Key;
            }
        }

        return sum;
    }
}

public class SumOfUniqueTests {
    // ---------- TwoPass vs OnePass: functional parity ----------

    [Theory]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 1, 1 }, 0)]
    [InlineData(new int[] { 1, 2, 3, 2 }, 4)] // 1 + 3
    [InlineData(new int[] { 2, 2, 3, 4, 4 }, 3)] // 3
    [InlineData(new int[] { -1, -2, -2, -3, -3, 7 }, 6)] // -1 + 7
    [InlineData(new int[] { 5, 5, 5 }, 0)]
    [InlineData(new int[] { 1, 2, 3, 4 }, 10)]
    public void TwoPass_And_OnePass_ShouldMatch(int[] nums, int expected) {
        var s = new SumOfUniqueElements();
        Assert.Equal(expected, s.SumOfUnique(nums));
    }

}