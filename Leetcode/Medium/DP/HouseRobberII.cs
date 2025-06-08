namespace Leetcode.Medium.DP;

public class HouseRobberII
{
    public int Rob(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        return Math.Max(RobLinear(nums, 0, nums.Length - 2), RobLinear(nums, 1, nums.Length - 1)); 
        int RobLinear(int[] nums, int start, int end) {
            int prev2 = nums[start];
            int prev1 = Math.Max(nums[start], nums[start + 1]);

            for(int i = start + 2; i <= end; i++) {
                int current = Math.Max(prev1, prev2 + nums[i]);

                prev2 = prev1;
                prev1 = current;
            }
            return prev1;
        }
    }
}