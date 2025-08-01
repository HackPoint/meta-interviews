namespace Leetcode.Medium.BinarySearch;

public class FindMinInRotatedSortedArray
{
    public int FindMin(int[] nums) {
        int left = 0, right = nums.Length - 1;

        while(left < right) {
            int mid = left + (right - left) / 2;

          
            if(nums[mid] > nums[right]) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }

        return nums[left];
    }
}