namespace Leetcode.Roadmap_Workthrough.Array_Strings;

public class ShortestUnsortedContinuousSubArray
{
    public int FindUnsortedSubarray(int[] nums) {
        int n = nums.Length;
        int maxSeen = int.MinValue;
        int minSeen = int.MaxValue;
        int left = -1, right = -1;

        // Left to right: find right boundary
        for (int i = 0; i < n; i++) {
            if (nums[i] < maxSeen)
                right = i;
            else
                maxSeen = nums[i];
        }

        // Right to left: find left boundary
        for (int i = n - 1; i >= 0; i--) {
            if (nums[i] > minSeen)
                left = i;
            else
                minSeen = nums[i];
        }

        return right == -1 ? 0 : right - left + 1;
    }
}