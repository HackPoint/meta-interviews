namespace Leetcode.Medium.PrefixPostifx;

public class ProductOfArrayExcepSelf {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] output = new int[n];
        output[0] = 1;

        // left
        for(int i = 1; i < n; i++) {
            output[i] = output[i-1] * nums[i - 1];
        }

        // right
        int right = 1;
        for(int i = n - 1; i >= 0; i--) {
            output[i] = output[i] * right;
            right = right * nums[i];
        }

        return output;
    }
}