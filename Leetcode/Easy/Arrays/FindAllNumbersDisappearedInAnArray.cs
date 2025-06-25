namespace Leetcode.Easy.Arrays;

public class FindAllNumbersDisappearedInAnArray
{
    public IList<int> FindDisappearedNumbers(int[] nums) {
        int n = nums.Length;
        var list = new List<int>();

        for(int i = 0; i < n; i++) {
            int value = System.Math.Abs(nums[i]);
            nums[value - 1] = -System.Math.Abs(nums[value - 1]);
        }

        for(int i = 0; i < n; i++) {
            if(nums[i] > 0)
                list.Add(i + 1);
        }
        return list;
    }
}