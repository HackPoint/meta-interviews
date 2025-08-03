using Xunit;

namespace Leetcode.Medium.Backtracking;


/// <summary>
/// Problem: 78. Subsets (https://leetcode.com/problems/subsets/)
/// 
/// Given an integer array `nums`, return all possible subsets (the power set).
/// The solution must not contain duplicate subsets.
/// 
/// Approach:
/// - Use backtracking to explore both "include" and "exclude" decisions for each element.
/// - On each recursion level, choose to either add or skip the current number.
/// - Base case: when index == nums.Length, record a snapshot of the current path.
/// - Store a **copy** of the current path in the result to avoid mutation.
/// 
/// Time Complexity: O(2^n * n)
///   - There are 2^n subsets, and copying each subset (path) takes up to O(n)
/// Space Complexity: O(n) for recursion stack and current path
/// 
/// Example:
/// Input: nums = [1,2,3]
/// Output: [[],[1],[2],[3],[1,2],[1,3],[2,3],[1,2,3]]
/// </summary>
public class Subsetss
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        List<int> path = new List<int>();

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
            
            // Include current number
            path.Add(nums[index]);
            Backtracking(index + 1);
            path.RemoveAt(path.Count - 1); // backtrack
        }
    }
}

public class SubsetsSolverTests
{
    private readonly Subsetss _solver = new();

    [Fact]
    public void Basic_Case_3Elements()
    {
        var nums = new[] { 1, 2, 3 };
        var result = _solver.Subsets(nums);

        Assert.Equal(8, result.Count);
        Assert.Contains(result, s => s.SequenceEqual(new[] { 1, 2 }));
        Assert.Contains(result, s => s.SequenceEqual(new[] { 2, 3 }));
        Assert.Contains(result, s => s.SequenceEqual(Array.Empty<int>()));
    }

    [Fact]
    public void SingleElement()
    {
        var nums = new[] { 5 };
        var result = _solver.Subsets(nums);

        Assert.Equal(2, result.Count);
        Assert.Contains(result, s => s.SequenceEqual(new[] { 5 }));
        Assert.Contains(result, s => s.SequenceEqual(Array.Empty<int>()));
    }

    [Fact]
    public void EmptyArray_ReturnsEmptySubset()
    {
        var nums = Array.Empty<int>();
        var result = _solver.Subsets(nums);

        Assert.Single(result);
        Assert.True(result[0].Count == 0);
    }

    [Fact]
    public void TwoElements_CheckAllSubsets()
    {
        var nums = new[] { 1, 2 };
        var result = _solver.Subsets(nums);

        var expected = new List<List<int>>
        {
            new(), new() { 1 }, new() { 2 }, new() { 1, 2 }
        };

        Assert.Equal(expected.Count, result.Count);
        foreach (var subset in expected)
            Assert.Contains(result, r => r.SequenceEqual(subset));
    }
}