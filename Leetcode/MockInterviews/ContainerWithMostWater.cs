using Leetcode.Easy.DFS;
using Xunit;

namespace Leetcode.MockInterviews;

/// <summary>
/// Finds the maximum area of water a container can store given height lines.
/// Greedy two-pointer approach:
/// - Start from both ends and move inward
/// - Always move the pointer pointing to the shorter line
/// 
/// Time Complexity: O(n)
/// Space Complexity: O(1)
/// </summary>
public class ContainerWithMostWater
{
    public int MaxArea(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int maxArea = 0;
        
        while (left < right)
        {
            int h = Math.Min(height[left], height[right]);
            int w = right - left; // width of between columns
            int area = w * h;
            maxArea = Math.Max(maxArea, area);

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}

public class MaxAreaTests
{
    [Theory]
    [InlineData(new[] { 1,8,6,2,5,4,8,3,7 }, 49)]
    [InlineData(new[] { 1,1 }, 1)]
    [InlineData(new[] { 4,3,2,1,4 }, 16)]
    [InlineData(new[] { 1,2,1 }, 2)]
    public void TestMaxArea(int[] height, int expected)
    {
        var solution = new ContainerWithMostWater();
        var result = solution.MaxArea(height);
        Assert.Equal(expected, result);
    }
}