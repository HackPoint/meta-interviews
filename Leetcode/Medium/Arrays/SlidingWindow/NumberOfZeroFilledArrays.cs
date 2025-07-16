namespace Leetcode.Medium.Arrays.SlidingWindow;

/// <summary>
/// Counts the total number of subarrays in which all elements are zero.
/// 
/// Logic:
/// - For every contiguous sequence of zeros of length k,
///   the number of zero-filled subarrays is: k * (k + 1) / 2.
/// - Instead of computing this with a separate formula at the end,
///   the method tracks the count of consecutive zeros on-the-fly:
///     • When a zero is found, increment count
///     • Add count to the result (each zero extends previous subarrays)
///     • If a non-zero is found, reset count to 0
///
/// Example:
///     nums = [0, 0, 0]
///     Steps:
///         count = 1 → total = 1
///         count = 2 → total = 3
///         count = 3 → total = 6
///
/// Time Complexity:     O(n)
/// Space Complexity:    O(1)
///
/// This is an optimal linear-time, constant-space solution
/// that processes the input in a single pass.
/// </summary>
public class NumberOfZeroFilledArrays
{
    public long ZeroFilledSubarray(int[] nums) {
        int n = nums.Length;
        int count = 0; 
        long total = 0;

        for(int i = 0; i < n; i++) {
            if(nums[i] == 0) {
                count++;
                total += count;
            } else {
                count = 0;
            }
        }
        return total;
    }
}