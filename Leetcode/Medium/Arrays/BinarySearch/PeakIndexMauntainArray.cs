using Xunit;

namespace Leetcode.Medium.Arrays.BinarySearch;

/// <summary>
/// Finds the index of the peak element in a "mountain" array.
/// 
/// Problem:
/// A mountain array is defined as an array where:
///   - Length >= 3
///   - Elements strictly increase to a single peak, then strictly decrease.
/// Given such an array arr, return the index of the peak element (the largest value).
/// 
/// Approach (Binary Search):
/// - Use two pointers: left = 0, right = arr.Length - 1.
/// - While left < right:
///     - mid = (left + right) / 2
///     - If arr[mid] < arr[mid + 1], the peak lies to the right → left = mid + 1.
///     - Else, the peak lies at mid or to the left → right = mid.
/// - Loop ends when left == right, which is the peak index.
/// 
/// Time Complexity:
/// - O(log n) — halves the search space each iteration.
/// 
/// Space Complexity:
/// - O(1) — constant extra variables.
/// 
/// Correctness & Edge Cases:
/// - Given constraints guarantee exactly one peak, so no ambiguity.
/// - Handles smallest valid mountain (length = 3).
/// - Strictly increasing before peak and strictly decreasing after peak ensures 
///   binary search will always converge to the correct index.
/// 
/// Example:
/// Input: arr = [0, 2, 1, 0]
/// Output: 1
/// Explanation: arr[1] = 2 is greater than neighbors arr[0] = 0 and arr[2] = 1.
/// 
/// Alternate Approaches:
/// - Linear scan: O(n) time, O(1) space — check each element until peak found.
/// - Binary search is preferred for large arrays due to O(log n) time.
/// </summary>
public class PeakIndexMountainArray {
    public int PeakIndexInMountainArray(int[] arr) {
        int left = 0, right = arr.Length - 1;
        while (left < right) {
            int mid = left + (right - left) / 2;

            if (arr[mid] < arr[mid + 1]) {
                left = mid + 1;
            }
            else {
                right = mid;
            }
        }

        return right;
    }
}

public class PeakIndexMountainArrayTests {
    private readonly PeakIndexMountainArray _sut = new();

    [Theory]
    [InlineData(new[] { 0, 1, 0 }, 1)]
    [InlineData(new[] { 0, 2, 1, 0 }, 1)]
    [InlineData(new[] { 0, 10, 5, 2 }, 1)]
    [InlineData(new[] { 3, 4, 5, 1 }, 2)]
    [InlineData(new[] { 24, 69, 100, 99, 79, 78, 67, 36, 26, 19 }, 2)]
    public void PeakIndexInMountainArray_ShouldReturnCorrectPeakIndex(int[] arr, int expected) {
        // Act
        var result = _sut.PeakIndexInMountainArray(arr);

        // Assert
        Assert.Equal(expected, result);
    }
}