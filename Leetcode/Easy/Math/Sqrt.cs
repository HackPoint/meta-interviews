using Xunit;

namespace Leetcode.Easy.Math;

/// <summary>
/// Problem:
///     Given a non-negative integer x, compute and return the integer part of its square root.
///     Only the integer part should be returned (floor of sqrt(x)).
///     Must not use built-in exponentiation or square root functions.
/// 
/// Approach:
///     Uses binary search to find the largest integer r such that r*r <= x.
///     1. Handle small inputs (x < 2) directly.
///     2. Search in the range [1, x/2] since sqrt(x) <= x/2 for x >= 2.
///     3. In each iteration:
///         - Calculate mid = left + (right - left) / 2.
///         - Compute mid² using long to avoid int overflow.
///         - If mid² == x → return mid (perfect square found).
///         - If mid² < x → store mid as a candidate, move left bound up.
///         - Else → move right bound down.
///     4. Return the last valid candidate.
/// 
/// Time Complexity:
///     O(log x) — binary search over the range [1, x/2].
/// 
/// Space Complexity:
///     O(1) — constant extra variables.
/// 
/// Correctness:
///     - Avoids overflow by using long for squaring.
///     - Works for all 32-bit integer inputs.
/// 
/// Example:
///     Input: x = 8
///     Steps: mid=2 → 4 < 8 → candidate=2 → move left
///            mid=3 → 9 > 8 → move right
///     Output: 2
/// </summary>
public class Sqrt {
    public int MySqrt(int x) {
        if(x < 2) return x;

        int left = 1, right = x / 2, ans = 0;
        while(left <= right) {
            int mid = left + (right - left) / 2;
            long sq = (long)mid * mid;

            if(sq == x) return mid;
            if(sq < x) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return ans;
    }
}

public class MySqrtTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(4, 2)]
    [InlineData(8, 2)]
    [InlineData(9, 3)]
    [InlineData(15, 3)]
    [InlineData(16, 4)]
    [InlineData(2147395599, 46339)] // just below int.Max sqrt
    public void MySqrt_ShouldReturnExpected(int input, int expected)
    {
        var solver = new Sqrt();
        Assert.Equal(expected, solver.MySqrt(input));
    }

    [Fact]
    public void PerfectSquares_ShouldMatchExactRoot()
    {
        var solver = new Sqrt();
        for (int i = 0; i <= 1000; i++)
        {
            int square = i * i;
            Assert.Equal(i, solver.MySqrt(square));
        }
    }

    [Fact]
    public void NonPerfectSquares_ShouldReturnFloor()
    {
        var solver = new Sqrt();
        Assert.Equal(4, solver.MySqrt(24)); // sqrt(24) ≈ 4.89
        Assert.Equal(5, solver.MySqrt(28)); // sqrt(28) ≈ 5.29
    }
}
