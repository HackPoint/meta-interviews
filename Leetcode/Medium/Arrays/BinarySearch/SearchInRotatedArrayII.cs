using Leetcode.Easy.DFS;
using Xunit;

namespace Leetcode.Medium.Arrays.BinarySearch;

/// <summary>
/// Classification: Binary Search (Modified)
/// Algorithm: Search in Rotated Sorted Array with Duplicates
///
/// Explanation:
/// • The goal is to determine if `target` exists in a **rotated sorted array** which may contain **duplicates**.
/// • A modified binary search is applied with careful duplicate handling:
/// 
///   1. If `nums[mid] == target`, we return true immediately.
///   2. If `nums[left] == nums[mid] == nums[right]`, we cannot determine the sorted half due to duplicates,
///      so we shrink the search space by doing `left++` and `right--`.
///   3. If the **left half is sorted** (`nums[left] <= nums[mid]`):
///       - Check if `target` lies within `[nums[left], nums[mid])`
///         → If yes, move `right = mid - 1`
///         → Else, move `left = mid + 1`
///   4. Otherwise, the **right half must be sorted**:
///       - Check if `target` lies within `(nums[mid], nums[right]]`
///         → If yes, move `left = mid + 1`
///         → Else, move `right = mid - 1`
///
/// Correctness:
/// • All edge cases are handled, including duplicates and equal boundaries.
/// • The loop terminates with `left > right` or early return on match.
///
/// Time Complexity:
/// • Best/Average Case: O(log n)
/// • Worst Case: O(n) — when duplicates obscure the sorted half (e.g., [1,1,1,1,1])
///
/// Space Complexity:
/// • O(1) — constant extra space
///
/// Example:
///   Input: nums = [2,5,6,0,0,1,2], target = 0
///   Output: true
///
///   Input: nums = [1,0,1,1,1], target = 0
///   Output: true
/// </summary>
public class SearchInRotatedArrayII
{
    public bool Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target) return true;
            if (nums[left] == nums[mid] && nums[mid] == nums[right])
            {
                left++;
                right--;
            }
            else if (nums[left] <= nums[mid])
            {
                if (nums[left] <= target && target < nums[right])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            else
            {
                if (nums[mid] < target && target <= nums[right])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }

        return true;
    }
}

public class SearchInRotatedArrayIITests
{
    [Theory]
    [InlineData(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 0, true)]
    [InlineData(new int[] { 1, 0, 1, 1, 1 }, 0, true)]
    [InlineData(new int[] { 1 }, 1, true)]
    [InlineData(new int[] { 1, 3, 1, 1, 1 }, 3, true)]
    [InlineData(new int[] { 1, 1, 3, 1 }, 3, true)]
    [InlineData(new int[] { 3, 1, 1 }, 3, true)]
    [InlineData(new int[] { 1, 3 }, 3, true)]
    public void Should_Find_Target_Correctly(int[] nums, int target, bool expected)
    {
        var solution = new SearchInRotatedArrayII();
        var result = solution.Search(nums, target);
        Assert.Equal(expected, result);
    }
}