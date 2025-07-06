namespace Leetcode.Roadmap_Workthrough.Array_Strings;

/// <summary>
/// Classification:
/// Algorithm: Greedy + Reach Tracking
/// Explanation:
/// You might use DP in here which was my initial thought but, it would take O(n)^2 which is NOT Acceptable
/// Time Complexity:   O(n)
/// Space Complexity: O(1)
/// </summary>
public class JumpGameII
{
    public int Jump(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1) return 0;

        int farthest = 0;
        int currEnd = 0;
        int jumps = 0;

        for (int i = 0; i < n - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);
            if (i == currEnd)
            {
                jumps++;
                currEnd = farthest;
                
                if (currEnd >= n - 1)
                    break;
            }
        }

        return jumps;
    }
}