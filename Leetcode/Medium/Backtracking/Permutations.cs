using Xunit;

namespace Leetcode.Medium.Backtracking;

/// <summary>
/// Problem: 46. Permutations
/// Given an array of distinct integers, return all possible permutations of the array.
///
/// Approach:
/// - This is a classic **Backtracking + DFS** problem where we build permutations
///   by swapping elements in-place at each recursive level.
/// - We recursively fix the element at `index`, and for each position from `index` to end:
///     - Swap the current element into the `index` position.
///     - Recurse to the next index.
///     - Backtrack by swapping back (restoring previous state).
///
/// - Invariant:
///   - At each level of recursion, elements before `index` are fixed,
///     and we permute elements from `index` onward.
///
/// Time Complexity: O(N!) where N = nums.Length
///   - There are N! permutations
///   - Each permutation takes O(N) to copy (in worst case)
///
/// Space Complexity: O(N) for recursion stack
///   - Output space excluded (since it's required to return all permutations)
///
/// Correctness Notes:
/// - Handles all lengths from 0 (empty array) to N > 1
/// - Uses in-place swapping to avoid unnecessary allocations
/// - Deep copies (via `new List<int>(nums)`) ensure results are not overwritten
///
/// Example:
/// Input: [1,2,3]
/// Output: [[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,2,1], [3,1,2]]
/// </summary>
public class Permutations
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();

        Backtracking(0);
        return result;

        void Backtracking(int index)
        {
            if (index == nums.Length)
            {
                result.Add(new List<int>(nums)); // copy snapshot
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {
                Swap(nums, index, i);
                Backtracking(index + 1);
                Swap(nums, index, i); // backtrack
            }
        }
    }

    private void Swap(int[] nums, int index, int p)
    {
        (nums[index], nums[p]) = (nums[p], nums[index]);
    }
}

public class PermuteTests
{
    [Theory]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 1, 2 }, 2)] // 2! = 2 permutations
    [InlineData(new int[] { 1, 2, 3 }, 6)] // 3! = 6 permutations
    public void Returns_Correct_Number_Of_Permutations(int[] input, int expectedCount)
    {
        var solution = new Permutations();
        var result = solution.Permute(input);
        Assert.Equal(expectedCount, result.Count);
    }

    [Fact]
    public void Handles_EmptyArray()
    {
        var solution = new Permutations();
        var result = solution.Permute([]);
        Assert.Single(result);
        Assert.Empty(result[0]); // Only one permutation: empty
    }

    [Fact]
    public void Contains_Expected_Permutations()
    {
        var solution = new Permutations();
        var result = solution.Permute([1, 2]);

        var expected = new List<IList<int>>
        {
            new List<int> { 1, 2 },
            new List<int> { 2, 1 }
        };

        Assert.All(expected, e => Assert.Contains(e, result, new ListComparer()));
    }

    private class ListComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int>? x, IList<int>? y)
        {
            if (x == null || y == null || x.Count != y.Count)
                return false;

            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i]) return false;
            }

            return true;
        }

        public int GetHashCode(IList<int> obj) => 0; // not used
    }
}