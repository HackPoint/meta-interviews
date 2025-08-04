using Xunit;

namespace Leetcode.Medium.Backtracking;

/// <summary>
/// Generates all unique combinations of candidates that sum up to the target.
/// Each number in candidates may be used at most once in the combination.
/// Duplicates in candidates are handled by sorting and skipping same values at the same level.
/// 
/// Approach:
/// - Sort the input array to efficiently skip duplicates and break early.
/// - Use backtracking to explore combinations.
/// - Skip duplicates at the same recursive level to avoid duplicate subsets.
/// - Stop recursion when the remaining target becomes negative.
/// 
/// Time Complexity: O(2^n), where n is the number of candidates (in worst case explores all subsets)
/// Space Complexity: O(n) for recursion stack and current path
/// 
/// Example:
/// Input: candidates = [10,1,2,7,6,1,5], target = 8
/// Output: [[1,1,6],[1,2,5],[1,7],[2,6]]
/// </summary>
public class CombinationSumII
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates); // Optional: early pruning optimization
        List<IList<int>> result = new List<IList<int>>();

        // Backtracking
        Backtrack(0, target, new List<int>(), result, candidates);
        return result;
    }

    private void Backtrack(int start, int target, List<int> path, List<IList<int>> result, int[] candidates)
    {
        if (target == 0)
        {
            result.Add([..path]); // Found valid combination
            return;
        }

        if (start >= candidates.Length || candidates[start] > target)
            return; // Early pruning if the smallest available number is already too big

        if (target < 0) return;
        
        for (int i = start; i < candidates.Length; i++)
        {
            int candidate = candidates[i];

            // Skip duplicates
            if (i > start && candidate == candidates[i - 1])
                continue;

            // Another early pruning for current candidate
            if (candidate > target)
                break;

            path.Add(candidate);
            Backtrack(i + 1, target - candidate, path, result, candidates);
            path.RemoveAt(path.Count - 1); // Backtrack
        }
    }
}

public class CombinationSum2Tests
{
    [Fact]
    public void Basic_Case_Example()
    {
        var sut = new CombinationSumII(); // Assuming the method is in a class named Solution
        var result = sut.CombinationSum2(new[] { 10, 1, 2, 7, 6, 1, 5 }, 8);

        var expected = new List<IList<int>>
        {
            new List<int> { 1, 1, 6 },
            new List<int> { 1, 2, 5 },
            new List<int> { 1, 7 },
            new List<int> { 2, 6 }
        };

        Assert.Equal(expected.Count, result.Count);
        foreach (var comb in expected)
            Assert.Contains(result, r => r.SequenceEqual(comb));
    }

    [Fact]
    public void No_Combinations()
    {
        var sut = new CombinationSumII();
        var result = sut.CombinationSum2(new[] { 2, 4, 6 }, 5);
        Assert.Empty(result);
    }

    [Fact]
    public void Single_Candidate_Equals_Target()
    {
        var sut = new CombinationSumII();
        var result = sut.CombinationSum2(new[] { 3 }, 3);
        Assert.Single(result);
        Assert.True(result[0].SequenceEqual(new[] { 3 }));
    }

    [Fact]
    public void Candidates_With_Duplicates()
    {
        var sut = new CombinationSumII();
        var result = sut.CombinationSum2(new[] { 1, 1, 1, 1 }, 2);

        var expected = new List<IList<int>> { new List<int> { 1, 1 } };
        Assert.Single(result);
        Assert.Contains(result, r => r.SequenceEqual(expected[0]));
    }
}