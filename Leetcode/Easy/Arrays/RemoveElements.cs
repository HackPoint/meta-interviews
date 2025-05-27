namespace Leetcode.Easy.Arrays.TwoPointers;

/*
 *  Input: nums = [3,2,2,3], val = 3
   Output: 2, nums = [2,2,_,_]
   Explanation: Your function should return k = 2, with the first two elements of nums being 2.
   It does not matter what you leave beyond the returned k (hence they are underscores).
 */
public class RemoveElements {
    public int RemoveElement(int[] nums, int val) {
        int writer = 0;

        for (int reader = 0; reader < nums.Length; reader++) {
            if (nums[reader] != val) {
                nums[writer] = nums[reader];
                writer++;
            }
        }

        return writer;
    }
}