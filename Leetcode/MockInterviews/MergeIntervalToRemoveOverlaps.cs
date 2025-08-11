using Xunit;

namespace Leetcode.MockInterviews;

/// <summary>
/// Problem: 435. Non-overlapping Intervals
///
/// Given an array of intervals, return the minimum number of intervals
/// you need to remove to make the rest of the intervals non-overlapping.
///
/// Approach:
///   - This uses a Greedy strategy:
///     1. Sort intervals by end time.
///     2. Iterate through each interval:
///         • If current start < previous end → overlapping → count++
///         • Else, update the prevEnd
///
/// Time Complexity:
///   • O(n log n) due to sorting
///   • O(n) to iterate and count overlaps
///
/// Space Complexity:
///   • O(1) — no extra space beyond input
///
/// Example:
///   Input:  [[1,2],[2,3],[3,4],[1,3]]
///   Sorted: [[1,2],[1,3],[2,3],[3,4]]
///   Output: 1 (remove [1,3])
/// </summary>
public class MergeIntervalToRemoveOverlaps
{
    public int RemoveOverlaps(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
        int prevEnd = intervals[0][1];
        int count = 0;
        for (int i = 1; i < intervals.Length; i++)
        {
            if (prevEnd > intervals[i][0])
            {
                count++; // found overlap: remove this interval
            }
            else
            {
                prevEnd = intervals[i][1];
            }
        }

        return count;
    }
}

public class MergeIntervalsToRemoveOverlapsTests
{
    private readonly MergeIntervalToRemoveOverlaps _solution = new();

    [Fact]
    public void Should_RunBaseCase()
    {
        int[][] intervals =
        [
            [1, 2],
            [2, 3],
            [3, 4],
            [1, 3]
        ];
        int k = _solution.RemoveOverlaps(intervals);
        Assert.Equal(1, k);
    }
    [Theory]
    [InlineData(1, new[] { 1, 2 }, new[] { 1, 3 }, new[] { 2, 3 }, new[] { 3, 4 })]
    [InlineData(2, new[] { 1, 2 }, new[] { 1, 2 }, new[] { 1, 2 })]
    [InlineData(0, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 })]
    [InlineData(3, new[] { 1, 100 }, new[] { 11, 22 }, new[] { 1, 11 }, new[] { 2, 12 }, new[] { 3, 13 })]
    [InlineData(0, new[] { 1, 5 })]
    public void TestRemoveOverlaps(int expected, params int[][] intervals)
    {
        var remover = new MergeIntervalToRemoveOverlaps();
        int result = remover.RemoveOverlaps(intervals);
        Assert.Equal(expected, result);
    }
}