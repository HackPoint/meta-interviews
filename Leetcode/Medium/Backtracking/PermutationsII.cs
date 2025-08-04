using Xunit;

namespace Leetcode.Medium.Backtracking;

/// <summary>
/// Problem: 47. Permutations II
/// Given a collection of numbers that might contain duplicates, return all possible unique permutations.
/// 
/// Approach:
/// - Use Backtracking to explore all paths.
/// - Sort the array to make duplicate detection easier.
/// - Use a boolean `used[]` array to track elements already in the current permutation.
/// - Skip elements that are equal to the previous one and the previous has not been used in this level.
/// 
/// Time Complexity:
/// - O(N × N!) — N! total permutations, each copied in O(N)
/// Space Complexity:
/// - O(N) — recursion stack + used array
/// 
/// Edge Cases:
/// - Duplicates must be filtered
/// - Order of recursion must avoid repeated paths
/// 
/// Example:
/// Input: [1, 1, 2]
/// Output: [ [1,1,2], [1,2,1], [2,1,1] ]
/// </summary>
public class PermutationsII
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var result = new List<IList<int>>();
        var path = new List<int>();
        var used = new bool[nums.Length];
        Array.Sort(nums); // critical for skipping duplicates

        Backtrack();
        return result;

        void Backtrack()
        {
            if (path.Count == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i]) continue;

                // Skip duplicate numbers in the same recursive depth
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;

                used[i] = true;
                path.Add(nums[i]);
                Backtrack();
                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }
    }
}

public class PermuteUniqueTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void PermuteUnique_ReturnsCorrectPermutations(int[] nums, IList<IList<int>> expected)
    {
        var solver = new PermutationsII();
        var actual = solver.PermuteUnique(nums);

        // Compare counts
        Assert.Equal(expected.Count, actual.Count);

        // Compare sets of permutations (order-agnostic)
        var expectedSet = expected.Select(p => string.Join(",", p)).ToHashSet();
        var actualSet = actual.Select(p => string.Join(",", p)).ToHashSet();

        Assert.True(expectedSet.SetEquals(actualSet));
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new int[] {1, 1, 2},
            new List<IList<int>>
            {
                new List<int>{1, 1, 2},
                new List<int>{1, 2, 1},
                new List<int>{2, 1, 1}
            }
        };

        yield return new object[]
        {
            new int[] {0, 1, 0, 0, 9},
            new List<IList<int>>
            {
                new List<int>{0,0,0,1,9},
                new List<int>{0,0,0,9,1},
                new List<int>{0,0,1,0,9},
                new List<int>{0,0,1,9,0},
                new List<int>{0,0,9,0,1},
                new List<int>{0,0,9,1,0},
                new List<int>{0,1,0,0,9},
                new List<int>{0,1,0,9,0},
                new List<int>{0,1,9,0,0},
                new List<int>{0,9,0,0,1},
                new List<int>{0,9,0,1,0},
                new List<int>{0,9,1,0,0},
                new List<int>{1,0,0,0,9},
                new List<int>{1,0,0,9,0},
                new List<int>{1,0,9,0,0},
                new List<int>{1,9,0,0,0},
                new List<int>{9,0,0,0,1},
                new List<int>{9,0,0,1,0},
                new List<int>{9,0,1,0,0},
                new List<int>{9,1,0,0,0}
            }
        };
    }
}