namespace Leetcode.Medium.Arrays.Math;

public class ThreeSumClosests
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int closestSum = nums[0] + nums[1] + nums[2]; 
        for (int i = 0; i < nums.Length - 2; i++)
        {
            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (System.Math.Abs(sum - target) < System.Math.Abs(closestSum - target))
                    closestSum = sum;

                if (sum < target) left++;
                else if (sum > target) right--;
                else if (sum == target) return sum;
            }
        }

        return closestSum;
    }
}