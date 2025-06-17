namespace Leetcode.Medium.Arrays.Math;

public class MinimumSizeSubArraySum
{
    public int MinSubArrayLen(int target, int[] nums) {
        int left = 0, sum = 0, minLength = int.MaxValue;

        for(int right = 0; right < nums.Length; right++) {
            sum += nums[right];

            while(sum >= target) {
                minLength = System.Math.Min(minLength, right - left + 1);;
                sum -= nums[left];
                left++;
            }
        }
        return minLength == int.MaxValue ? 0 : minLength;
    }
}