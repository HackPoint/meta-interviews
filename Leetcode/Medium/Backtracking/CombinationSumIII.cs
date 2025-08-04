using Xunit;

namespace Leetcode.Medium.Backtracking;

/// <summary>
/// Problem: Find all valid combinations of `k` numbers that add up to `n`, 
/// using only numbers from 1 to 9. Each number can be used at most once.
/// 
/// Approach:
/// - Use backtracking to explore combinations starting from `1` to `9`.
/// - Maintain current combination (`path`) and remaining `target` sum.
/// - If path.Count == k and target == 0 → valid combination.
/// - Prune branches when:
///     - path.Count > k → too many numbers
///     - target < 0 → sum already too big
/// Time Complexity: O(C(9, k)) – bounded by 9-choose-k combinations
/// Space Complexity: O(k) – recursion stack and path size
/// 
/// Example:
/// Input: k = 3, n = 7
/// Output: [[1,2,4]]
/// </summary>
public class CombinationSumIII
{
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        var result = new List<IList<int>>();
        Backtrack(1, new List<int>(), k, n);
        return result;

        void Backtrack(int start, List<int> path, int k, int target)
        {
            if (path.Count == k && target == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            if (target < 0 || path.Count > k)
                return;

            for (int i = start; i <= 9; i++)
            {
                path.Add(i);
                Backtrack(i + 1, path, k, target - i);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}

public class CombinationSum3Tests
{
    [Theory]
    [MemberData(nameof(TestCases))]
    public void CombinationSum3_WorksCorrectly(int k, int n, List<List<int>> expected)
    {
        // Arrange
        var solution = new CombinationSumIII();

        // Act
        var actual = solution.CombinationSum3(k, n)
            .Select(x => x.OrderBy(i => i).ToList())
            .OrderBy(x => string.Join(",", x))
            .ToList();

        var expectedSorted = expected
            .Select(x => x.OrderBy(i => i).ToList())
            .OrderBy(x => string.Join(",", x))
            .ToList();

        // Assert
        Assert.Equal(expectedSorted.Count, actual.Count);
        for (int i = 0; i < expectedSorted.Count; i++)
        {
            Assert.Equal(expectedSorted[i], actual[i]);
        }
    }

    public static IEnumerable<object[]> TestCases =>
        new List<object[]>
        {
            new object[] {
                3, 7,
                new List<List<int>> {
                    new() { 1, 2, 4 }
                }
            },
            new object[] {
                3, 9,
                new List<List<int>> {
                    new() { 1, 2, 6 },
                    new() { 1, 3, 5 },
                    new() { 2, 3, 4 }
                }
            },
            new object[] {
                4, 1,
                new List<List<int>>() // Empty result
            },
            new object[] {
                9, 45,
                new List<List<int>> {
                    new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                }
            }
        };
}