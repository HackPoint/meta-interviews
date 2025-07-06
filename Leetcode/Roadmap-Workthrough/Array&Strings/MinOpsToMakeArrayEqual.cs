namespace Leetcode.Roadmap_Workthrough.Array_Strings;


/// <summary>
/// Classification:
/// Algorithm: Math
/// Explanation:
/// Should've been Greedy , now it's converted to a Math formula
/// Time Complexity:   O(1)
/// Space Complexity: O(1)
/// </summary>
public class MinOpsToMakeArrayEqual
{
    public int MinOperations(int n) {
        int mid = n / 2;
        return mid * (n - mid);
    }   
}