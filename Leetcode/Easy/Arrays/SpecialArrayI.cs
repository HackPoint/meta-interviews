namespace Leetcode.Easy.Arrays;

public class SpecialArrayI
{
    public bool IsArraySpecial(int[] nums) {
        if(nums.Length == 1) return true;
       
        for(int i = 0; i < nums.Length - 1; i++) {
            if(nums[i] % 2 == nums[i + 1] % 2) {
                return false;
            }
        }
        return true;
    }
}