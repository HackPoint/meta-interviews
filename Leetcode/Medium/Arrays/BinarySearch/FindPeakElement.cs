namespace Leetcode.Medium.Arrays.BinarySearch;

/// <summary>
/// Finds any peak element in the given array using binary search.
/// A peak element is defined as an element strictly greater than its neighbors.
/// 
/// Preconditions:
/// • The input array must contain at least one element.
/// • Neighboring elements are guaranteed to be non-equal (nums[i] != nums[i+1]).
/// • Elements beyond array boundaries are considered as negative infinity (-∞).
///
/// Algorithm:
/// • Performs binary search based on the slope of the array:
///   - If nums[mid] > nums[mid + 1], we are on a descending slope → peak is on the left side (including mid).
///   - Otherwise, we are on an ascending slope → peak is on the right side (excluding mid).
/// • Continues until the search space collapses to a single index, which is guaranteed to be a peak.
///
/// Time Complexity:     O(log n)
/// Space Complexity:    O(1)
///
/// Edge Cases:
/// • For length-1 arrays, the only element is trivially a peak.
/// • For strictly increasing arrays, the last element is a peak.
/// • For strictly decreasing arrays, the first element is a peak.
/// 
/// Returns:
/// • Index of any valid peak (not necessarily unique).
/// </summary>
public class FindPeakElements
{
    public int FindPeakElement(int[] nums) {
        int left = 0, right = nums.Length - 1;

        while(left < right) {
            int mid = (left + right) / 2;
            if(nums[mid] > nums[mid + 1]) {
                right = mid;
            } else if(nums[mid] < nums[mid + 1]) {
                left = mid + 1;
            }
        }

        return left;
    }
}