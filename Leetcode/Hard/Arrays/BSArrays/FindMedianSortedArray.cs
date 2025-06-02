namespace Leetcode.Hard.Arrays.BSArrays;

public class FindMedianSortedArray {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums1.Length > nums2.Length) {
            // Ensure nums1 is the smaller array
            (nums1, nums2) = (nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;

        int low = 0, high = m;

        while (low <= high) {
            int partitionX = (low + high) / 2;
            int partitionY = (m + n + 1) / 2 - partitionX;

            int maxLeftX = partitionX == 0 ? int.MinValue : nums1[partitionX - 1];
            int minRightX = partitionX == m ? int.MaxValue : nums1[partitionX];

            int maxLeftY = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];
            int minRightY = partitionY == n ? int.MaxValue : nums2[partitionY];

            if (maxLeftX <= minRightY && maxLeftY <= minRightX) {
                if ((m + n) % 2 == 0) {
                    return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
                }

                return Math.Max(maxLeftX, maxLeftY);
            }

            if (maxLeftX > minRightY) {
                high = partitionX - 1;
            }
            else {
                low = partitionX + 1;
            }
        }

        throw new ArgumentException("Input arrays are not sorted or invalid.");
    }

    private void Swap(ref int[] nums1, ref int[] nums2) {
        for (var i = 0; i < nums1.Length; i++) {
            (nums1[i], nums2[i]) = (nums2[i], nums1[i]);
        }
    }
}