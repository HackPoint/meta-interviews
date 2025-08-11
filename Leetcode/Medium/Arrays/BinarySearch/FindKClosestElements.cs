using Xunit;

namespace Leetcode.Medium.Arrays.BinarySearch;

/// <summary>
/// ✅ Returns exactly k elements from a sorted array that are closest to x.
/// Ties are broken by choosing the smaller elements (i.e., prefer the left window).
///
/// 🧠 Core idea (Binary Search on Window Start):
/// We know the answer is a continuous window of length k. The valid start index
/// lies in [0..n-k]. We binary-search this start index using a monotone predicate:
/// compare distances between x and the "edges" around a candidate window:
///   left_gap  = x - arr[mid]          // distance from x to window's left edge
///   right_gap = arr[mid + k] - x      // distance from x to the element right after window
/// If left_gap > right_gap, the window should move right (low = mid + 1),
/// else move left (high = mid). Using "≤" on the 'else' branch ensures tie-breaking
/// to the left as required by the problem.
///
/// 🧪 Edge cases:
/// - x <= arr[0]   => start == 0
/// - x >= arr[n-1] => start == n-k
/// - Duplicates around x are handled naturally by the tie-breaking rule.
///
/// ⏱️ Time Complexity:
/// - Binary search on [0..n-k]: O(log(n-k))
/// - Building the result window: O(k)
/// Overall: O(log n + k)
///
/// 💾 Space Complexity:
/// - O(k) for the result list, O(1) extra.
/// </summary>
public class FindKClosestElements
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        // Basic assumptions of the LeetCode problem: arr is sorted ascending, 1 <= k <= arr.Length
        int n = arr?.Length ?? 0;
        if (arr == null || n == 0 || k <= 0) return new List<int>();

        int low = 0;
        int high = n - k; // last possible start so that [start..start+k-1] fits

        // Binary search the start index
        while (low < high)
        {
            int mid = low + (high - low) / 2;

            // Distances to edges around the candidate window starting at mid:
            int leftGap = x - arr[mid];        // distance from x to the left edge (can be negative)
            int rightGap = arr[mid + k] - x;   // distance from the element after window to x (can be negative)

            // If left edge is "further" than right edge → shift right, else shift left
            if (leftGap > rightGap)
            {
                low = mid + 1;
            }
            else
            {
                high = mid; // keep left side (also handles ties by preferring left)
            }
        }

        // Build result: exactly k elements starting at 'low'
        var res = new List<int>(k);
        for (int i = low; i < low + k; i++)
        {
            res.Add(arr[i]);
        }
        return res;
    }
}

public class ClosestElementsSolverTests
    {
        [Fact]
        public void Basic_MiddleTarget_ReturnsCenteredWindow()
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int k = 4, x = 5;

            // Act
            var res = new FindKClosestElements().FindClosestElements(arr, k, x);

            // Assert
            Assert.Equal(new List<int> { 3, 4, 5, 6 }, res);
        }

        [Fact]
        public void Target_LeftOfAll_ReturnsFirstK()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int k = 4, x = 0;

            var res = new FindKClosestElements().FindClosestElements(arr, k, x);

            Assert.Equal(new List<int> { 1, 2, 3, 4 }, res);
        }

        [Fact]
        public void Target_RightOfAll_ReturnsLastK()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int k = 4, x = 100;

            var res = new FindKClosestElements().FindClosestElements(arr, k, x);

            Assert.Equal(new List<int> { 2, 3, 4, 5 }, res);
        }

        [Fact]
        public void WithDuplicates_AroundX_TakesLeftOnTie()
        {
            int[] arr = { 1, 2, 2, 2, 3 };
            int k = 3, x = 2;

            var res = new FindKClosestElements().FindClosestElements(arr, k, x);

            Assert.Equal(new List<int> { 2, 2, 2 }, res);
        }

        [Fact]
        public void ExactHitInside_DistanceTieBreaksLeft()
        {
            int[] arr = { 1, 3, 4, 5, 7, 9 };
            int k = 2, x = 6;
            // Candidates windows of length 2 near 6:
            // [4,5] vs [5,7] -> both have distances {2,1} aggregated similarly,
            // rule prefers the left window [4,5]
            var res = new FindKClosestElements().FindClosestElements(arr, k, x);

            Assert.Equal(new List<int> { 5, 7 }, res);
        }

        [Fact]
        public void SingleElementK_ReturnsClosestSingle()
        {
            int[] arr = { 1, 3, 8, 10 };
            int k = 1, x = 6;

            var res = new FindKClosestElements().FindClosestElements(arr, k, x);

            Assert.Equal(new List<int> { 8 }, res);
        }

        [Fact]
        public void FullWindowK_EqualsArray_ReturnsArray()
        {
            int[] arr = { 2, 4, 6, 8 };
            int k = 4, x = 5;

            var res = new FindKClosestElements().FindClosestElements(arr, k, x);

            Assert.Equal(new List<int> { 2, 4, 6, 8 }, res);
        }

        [Fact]
        public void NegativeValues_WorkAsExpected()
        {
            int[] arr = { -10, -5, -2, 0, 3, 9 };
            int k = 3, x = -3;

            var res = new FindKClosestElements().FindClosestElements(arr, k, x);

            Assert.Equal(new List<int> { -5, -2, 0 }, res);
        }
    }