using Xunit;

namespace Leetcode.Medium.Arrays.SlidingWindow;

/// <summary>
    /// Problem: 904. Fruit Into Baskets
///
/// You are given an array `fruits`, where `fruits[i]` is the type of fruit on the i-th tree.
/// You can pick fruit from at most two different types of trees in a contiguous subarray.
/// Your goal is to return the maximum number of fruits you can collect under this constraint.
///
/// Approach:
/// - Sliding Window with Frequency Array Optimization
/// - Maintain a fixed-size frequency array `count[]` of all possible fruit types (based on constraints)
/// - Track `types` = number of distinct fruit types currently in the window [left, right]
/// - Expand the window by moving `right` pointer forward
/// - If the number of types exceeds 2, shrink the window from `left` until `types <= 2`
/// - Update `maxFruits` during each iteration
///
/// Time Complexity:     O(n) — each element visited at most twice (left and right)
/// Space Complexity:    O(K) — where K = max fruit type value (bounded by problem constraints)
///
/// Note:
/// - `maxType = 40001` is chosen based on LeetCode constraints: 0 <= fruits[i] < 40000
///   (Using slightly more for safety margin)
///
/// Edge Cases Covered:
/// - All elements the same
/// - Exactly two fruit types
/// - New third fruit appears and shrinks window
/// - Empty array
/// </summary>
public class FruitsIntoBasket
{
    // fruits = [(1),2,3,2,2]
    public int TotalFruit(int[] fruits)
    {
        const int maxType = 40001;
        int[] count = new int[maxType];
        int left = 0, maxFruits = 0, types = 0;

        for (int right = 0; right < fruits.Length; right++)
        {
            if (count[fruits[right]]++ == 0)
                types++;

            if (types > 2)
            {
                while (--count[fruits[left++]] != 0) { }
                types--;
            }

            maxFruits = System.Math.Max(maxFruits, right - left + 1);
        }

        return maxFruits;
    }
}

public class FruitIntoBasketsTests
{
    private readonly FruitsIntoBasket _solution = new();

    [Fact]
    public void Example1()
    {
        int[] fruits = { 1, 2, 1 };
        int expected = 3;
        Assert.Equal(expected, _solution.TotalFruit(fruits));
    }

    [Fact]
    public void Example2()
    {
        int[] fruits = { 0, 1, 2, 2 };
        int expected = 3;
        Assert.Equal(expected, _solution.TotalFruit(fruits));
    }

    [Fact]
    public void Example3()
    {
        int[] fruits = { 1, 2, 3, 2, 2 };
        int expected = 4;
        Assert.Equal(expected, _solution.TotalFruit(fruits));
    }

    [Fact]
    public void AllSameFruits()
    {
        int[] fruits = { 5, 5, 5, 5 };
        int expected = 4;
        Assert.Equal(expected, _solution.TotalFruit(fruits));
    }

    [Fact]
    public void AlternatingFruits()
    {
        int[] fruits = { 1, 2, 1, 2, 1, 2 };
        int expected = 6;
        Assert.Equal(expected, _solution.TotalFruit(fruits));
    }

    [Fact]
    public void ThreeTypesEarly()
    {
        int[] fruits = { 1, 2, 3, 2, 2, 3, 4 };
        int expected = 4; // from [2, 2, 3, 4] only 2 types allowed
        Assert.Equal(expected, _solution.TotalFruit(fruits));
    }

    [Fact]
    public void SingleElement()
    {
        int[] fruits = { 42 };
        int expected = 1;
        Assert.Equal(expected, _solution.TotalFruit(fruits));
    }
    
    [Fact]
    public void EmptyInput()
    {
        int[] fruits = { };
        int expected = 0;
        Assert.Equal(expected, _solution.TotalFruit(fruits));
    }
}