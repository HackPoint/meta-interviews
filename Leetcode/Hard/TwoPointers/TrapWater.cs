namespace Leetcode.Hard.TwoPointers;

public class TrapWater
{
    public int Trap(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        int water = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax)
                {
                    leftMax = height[left];
                }
                else
                {
                    water += leftMax - height[left];
                }

                left++;
            }
            else
            {
                if (height[right] >= rightMax)
                {
                    rightMax = height[right];
                }
                else
                {
                    water += rightMax - height[right];
                }

                right--;
            }
        }

        return water;
    }

    public int TrapWithStack(int[] height)
    {
        var stack = new Stack<int>();
        int water = 0;

        for (var i = 0; i < height.Length; i++)
        {
            while (stack.Any() && height[i] > height[stack.Peek()])
            {
                int bottom = stack.Pop();

                if (!stack.Any())
                    break;

                int left = stack.Peek();
                int width = i - left - 1;
                int boundedHeight = Math.Min(height[left], height[i]) - height[bottom];
                water += width * boundedHeight;
            }

            stack.Push(i);
        }

        return water;
    }
}