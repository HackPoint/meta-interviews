namespace Leetcode.Easy.Arrays.TwoPointers;

public class SortColorss
{
    public void SortColors(int[] nums)
    {
        int low = 0, high = nums.Length - 1;
        int mid = low;

        while (mid <= high)
        {
            if (nums[mid] == 0)
            {
                (nums[low], nums[mid]) = (nums[mid], nums[low]);
                low++;
                mid++;
            }

            else if (nums[mid] == 1)
                mid++;

            else if (nums[mid] == 2)
            {
                (nums[mid], nums[high]) = (nums[high], nums[mid]);
                high--;
            }
        }
    }
}