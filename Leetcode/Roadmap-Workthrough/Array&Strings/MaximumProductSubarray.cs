namespace Leetcode.Roadmap_Workthrough.Array_Strings;

public class MaximumProductSubarray
{
    public int MaxProduct(int[] nums) {
        int minSoFar = nums[0];
        int maxSoFar = nums[0];
        int result = nums[0];

        for(int i = 1; i < nums.Length; i++) {
            if(nums[i] == 0) {
                minSoFar = 0;
                maxSoFar = 0;
                result = Math.Max(result, 0);
            }

            if(nums[i] < 0) {
                (minSoFar, maxSoFar) = (maxSoFar, minSoFar);
            }
            maxSoFar = Math.Max(nums[i], maxSoFar * nums[i]);
            minSoFar = Math.Min(nums[i], minSoFar * nums[i]);

            result = Math.Max(result, maxSoFar);
        }

        return result;
    }
}