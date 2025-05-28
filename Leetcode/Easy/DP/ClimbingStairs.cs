namespace Leetcode.Easy.DP;

public class ClimbingStairs
{
    public int ClimbStairsIterative(int n)
    {
        if (n <= 1) return 1;
        int first = 1;
        int second = 1;

        for (int i = 2; i <= n; i++)
        {
            int current = first + second;
            first = second;
            second = current;
        }

        return second;

    }
    
    // Fibonacci
    public int ClimbStairsRecursive(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        return ClimbStairsRecursive(n - 1) + ClimbStairsRecursive(n - 2);
    }
}