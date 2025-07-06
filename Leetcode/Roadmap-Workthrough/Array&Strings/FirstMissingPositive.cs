namespace Leetcode.Roadmap_Workthrough.Array_Strings;


/// <summary>
/// Classification:
/// Algorithm: Greedy + Cyclic Sort
/// Explanation:
/// Smart In-Place Strategy + Cyclic Sort
/// Time Complexity:   O(n)
/// Space Complexity: O(1)
/// </summary>
public class FirstMissingPositives
{
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;
        // start: Cyclic sort
        int i = 0;
        while(i < n) {
            int correct = nums[i] - 1;

            if(nums[i] > 0 && nums[i] <= n && nums[i] != nums[correct]) {
                (nums[i], nums[correct]) = (nums[correct], nums[i]);
            } else i++;
        }
        // end: Cyclic sort

        for(int j = 0; j < n; j++) {
            if(nums[j] != j + 1)
                return j + 1;
        }

        return n + 1;
    }
}