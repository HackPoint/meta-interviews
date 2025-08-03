namespace Leetcode.Medium.Arrays.QuickSort;

public class FindKthLargestInArray {
    private static readonly Random Rand = new();

    public int FindKthLargest(int[] nums, int k) {
        int target = nums.Length - k; // kth largest → index in ascending order
        return QuickSelect(nums, 0, nums.Length - 1, target);
    }

    private int QuickSelect(int[] nums, int left, int right, int k) {
        while (left <= right) {
            int pivotIdx = Rand.Next(left, right + 1);
            int pivot = nums[pivotIdx];

            // 3-way partition: < pivot | == pivot | > pivot
            (int low, int high) = DutchPartition(nums, left, right, pivot);

            if (k >= low && k <= high) {
                return nums[k]; // in the == pivot zone
            } else if (k < low) {
                right = low - 1;
            } else {
                left = high + 1;
            }
        }

        return -1; // unreachable
    }

    private (int, int) DutchPartition(int[] nums, int left, int right, int pivot) {
        int i = left, lt = left, gt = right;

        while (i <= gt) {
            if (nums[i] < pivot) {
                (nums[i], nums[lt]) = (nums[lt], nums[i]);
                i++; lt++;
            } else if (nums[i] > pivot) {
                (nums[i], nums[gt]) = (nums[gt], nums[i]);
                gt--;
            } else {
                i++;
            }
        }

        return (lt, gt); // range of elements equal to pivot
    }
}