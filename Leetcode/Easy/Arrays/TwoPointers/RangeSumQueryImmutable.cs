namespace Leetcode.Easy.Arrays.TwoPointers;

public class NumArray {
    private readonly int[] prefix;

    public NumArray(int[] nums) {
        prefix = new int[nums.Length + 1];

        for(int i = 0; i < nums.Length; i++) {
            prefix[i + 1] = prefix[i] + nums[i];
        }
    }
    
    public int SumRange(int left, int right) {
        return prefix[right + 1] - prefix[left];
    }
}