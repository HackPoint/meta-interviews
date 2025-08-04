using Leetcode.Easy.DFS;
using Xunit;

namespace Leetcode.Medium.Backtracking;

/// <summary>
/// Generates all possible subsets (the power set) of the given integer array,
/// ensuring that duplicate subsets are not included in the result.
/// 
/// The input may contain duplicate elements.
/// 
/// Approach:
/// - Sort the array to group duplicates together
/// - Use backtracking to explore all subset possibilities
/// - Skip duplicates at the same recursion level (only pick the first occurrence)
/// - Track used elements with a boolean array to manage pruning correctly
///
/// Time Complexity: O(2^n) — for n elements, all subsets are considered
/// Space Complexity: O(n) — for recursion stack and temporary path
///
/// Example:
/// Input: [1,2,2]
/// Output: [[], [1], [1,2], [1,2,2], [2], [2,2]]
/// </summary>
public class SubsetsII
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        var result = new List<IList<int>>();
        List<int> path = new List<int>();
        bool[] used = new bool[nums.Length];
        // sort
        Array.Sort(nums);

        Backtracking(0);
        return result;

        void Backtracking(int index)
        {
            if (index == nums.Length)
            {
                result.Add(new List<int>(path)); // copy snapshot
                return;
            }

            Backtracking(index + 1);

            if (index > 0 && nums[index] == nums[index - 1] && !used[index - 1])
                return;

            // Include current number
            path.Add(nums[index]);
            used[index] = true;
            Backtracking(index + 1);
            used[index] = false;
            path.RemoveAt(path.Count - 1); // backtrack
        }
    }
}

public class SubsetsWithDupTests
{
    private readonly SubsetsII _solver = new();

    [Fact]
    public void Basic_Test_123()
    {
        var result = _solver.SubsetsWithDup(new[] { 1, 2, 3 });
        Assert.Equal(8, result.Count); // 2^3
    }

    [Fact]
    public void Duplicates_Test_122()
    {
        var result = _solver.SubsetsWithDup(new[] { 1, 2, 2 });
        var expected = new List<IList<int>>
        {
            new List<int>(), new List<int> { 1 }, new List<int> { 1, 2 }, new List<int> { 1, 2, 2 },
            new List<int> { 2 }, new List<int> { 2, 2 }
        };

        Assert.Equal(expected.Count, result.Count);
        foreach (var subset in expected)
            Assert.Contains(result, r => r.SequenceEqual(subset));
    }

    [Fact]
    public void AllDuplicates()
    {
        var result = _solver.SubsetsWithDup(new[] { 2, 2, 2 });
        var expected = new List<IList<int>>
        {
            new List<int>(), new List<int> { 2 }, new List<int> { 2, 2 }, new List<int> { 2, 2, 2 }
        };

        Assert.Equal(expected.Count, result.Count);
        foreach (var subset in expected)
            Assert.Contains(result, r => r.SequenceEqual(subset));
    }

    [Fact]
    public void EmptyArray()
    {
        var result = _solver.SubsetsWithDup(Array.Empty<int>());
        Assert.Single(result); // Only []
        Assert.Empty(result[0]);
    }

    [Fact]
    public void SingleElement()
    {
        var result = _solver.SubsetsWithDup(new[] { 5 });
        Assert.Equal(2, result.Count); // [], [5]
        Assert.Contains(result, r => r.Count == 0);
        Assert.Contains(result, r => r.Count == 1 && r[0] == 5);
    }
}