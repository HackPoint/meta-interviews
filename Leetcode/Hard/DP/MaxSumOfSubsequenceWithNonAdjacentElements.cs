using Leetcode.DSA;

namespace Leetcode.Hard.DP;

public class MaxSumOfSubsequenceWithNonAdjacentElements
{
    const int Mod = 1_000_000_007;
    public int MaximumSumSubsequence(int[] nums, int[][] queries)
    {
        var tree = new SegmentTree(nums);
        long total = 0;

        foreach (var query in queries)
        {
            int index = query[0];
            int value = query[1];

            tree.Update(index, value);
            long q = tree.Query();
            total = ((total + q) % Mod + Mod) % Mod; // wrap around negatives
        }
        return (int)total;
    }
}