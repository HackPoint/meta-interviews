namespace Leetcode.Easy.TwoPointers;

public class MoveZeros
{
    public void MoveZeroes(int[] nums) {
        int insertPosition = 0;

        for(int i = 0; i < nums.Length ; i++) {
            if(nums[i] != 0) {
                nums[insertPosition] = nums[i];
                insertPosition++;
            }
        }

        for(int i = insertPosition; i < nums.Length; i++) {
            nums[i] = 0;
        }
    }
}