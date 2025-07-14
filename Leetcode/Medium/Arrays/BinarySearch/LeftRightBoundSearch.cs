namespace Leetcode.Medium.Arrays.BinarySearch;

public class LeftRightBoundSearch
{
    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 0) return [-1, -1];

        int left = 0, right = nums.Length - 1;
        int leftBound = LeftBinarySearch(left, right, target, nums);
        int rightBound = RightBinarySearch(left, right, target, nums);
        return [leftBound, rightBound];
    }

    /// <summary>
    /// Returns the index of the last (rightmost) occurrence of target, or -1 if not found.
    /// </summary>
    private int RightBinarySearch(int left, int right, int target, int[] nums)
    {
        int answer = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else
            {
                answer = mid;
                left = mid + 1;
            } 
        }

        return answer;
    }

    /// <summary>
    /// Returns the index of the first (leftmost) occurrence of target, or -1 if not found.
    /// </summary>
    private int LeftBinarySearch(int left, int right, int target, int[] nums)
    {
        int answer = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else
            {
                answer = mid;
                right = mid - 1;
            } 
        }

        return answer;
    }
}