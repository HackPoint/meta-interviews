namespace Leetcode.Medium.Arrays.Math;

/// <summary>
/// Problem:
/// Given an integer array `nums` of length `n` where each number is in the range [1, n],
/// find all elements that appear exactly twice.
///
/// Approach:
/// - Use the fact that all values are within [1, n] to treat `nums` as its own hash structure.
/// - For each value `val` in `nums`, mark the element at index `abs(val) - 1` as visited by flipping its sign.
/// - If an index is visited a second time (i.e. already negative), the corresponding number is a duplicate.
///
/// Key Insight:
/// - This approach encodes "seen" status into the sign of the values in `nums`.
/// - It avoids extra memory usage, satisfying the O(1) space constraint.
///
/// Time Complexity: O(n)
/// - Each number is visited at most twice (once to mark, once to detect).
///
/// Space Complexity: O(1) extra (excluding output list)
/// - No additional structures used; modification is in-place.
///
/// Example:
/// Input:  [4,3,2,7,8,2,3,1]
/// Output: [2,3]
///
/// Notes:
/// - This solution mutates the input array `nums`.
/// - If mutation is disallowed, a copy of the array would be needed.
/// - Handles edge cases like multiple repeated numbers or unordered input.
/// </summary>

public class FindAllDuplicatesInArray
{
    public IList<int> FindDuplicates(int[] nums) {
        var res = new List<int>();

        foreach(int i in nums) {
            int x = System.Math.Abs(i) - 1;

            if(nums[x] < 0) {
                res.Add(x + 1);
            } else {
                nums[x] = -nums[x];
            }
        }

        return res;
    }
}