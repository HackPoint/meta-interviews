namespace Leetcode.Medium.Arrays.Sorting;

public class MergeIntervals {
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length <= 1) return intervals;
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var merged = new List<int[]>();
        foreach(var interval in intervals) {
            if(merged.Count == 0 || merged[^1][1] < interval[0]) {
                merged.Add(interval);
            } else {
                merged[^1][1] = System.Math.Max(merged[^1][1], interval[1]);
            }
        }

        return merged.ToArray();
    }
}