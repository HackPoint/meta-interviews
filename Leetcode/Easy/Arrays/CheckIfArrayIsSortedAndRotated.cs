namespace Leetcode.Easy.Arrays;

public class CheckIfArrayIsSortedAndRotated
{
    public bool Check(int[] nums)
    {
        int n = nums.Length;
        int fallDownCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > nums[(i + 1) % n])
                fallDownCount++;
        }

        if (fallDownCount > 1)
            return false;

        return true;
    }
}