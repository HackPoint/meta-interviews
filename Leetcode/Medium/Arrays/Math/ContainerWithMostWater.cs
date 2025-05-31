namespace Leetcode.Medium.Arrays.Math;

public class ContainerWithMostWater {
    int MaxArea(int[] height) {
        int maxArea = 0;
        int left = 0, right = height.Length - 1;

        while (left < right) {
            int h = System.Math.Min(height[left], height[right]);
            int w = right - left;
            int area = h * w;
            maxArea = System.Math.Max(maxArea, area);

            if (height[left] < height[right]) {
                left++;
            }
            else {
                right--;
            }
        }

        return maxArea;
    }
}