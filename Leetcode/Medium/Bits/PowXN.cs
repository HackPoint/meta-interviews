namespace Leetcode.Medium.Bits;


/// <summary>
/// Problem:
/// Implement function Pow(x, n) to calculate x raised to the power n (x^n).
/// Constraints include handling negative exponents, large values of n,
/// and the edge case where n == int.MinValue (which overflows on negation).
///
/// Approach:
/// - Use binary exponentiation (exponentiation by squaring) for O(log n) time.
/// - For negative exponents:
///     - Invert the base (x = 1 / x)
///     - Apply the exponent as positive
///     - Special case: if n == int.MinValue, it cannot be negated safely.
///         → Pre-consume one multiplication (result *= x) and increment n by 1
/// - While n > 0:
///     - If current bit of n is set (n % 2 == 1), multiply result by current base
///     - Square the base and shift n right by 1 (n >>= 1)
///
/// Edge Cases:
/// - x = 0, n = 0 → defined as 1.0
/// - x = 2.0, n = int.MinValue → must avoid negating n
/// - Negative powers handled by inversion
///
/// Time Complexity: O(log n)
/// - Each bit of n processed once via squaring
///
/// Space Complexity: O(1)
/// - Only a few variables used; no recursion or additional structures
/// </summary>
public class PowXN {
    public double MyPow(double x, int n) {
        long N = n;

        // Edge case:
        if(N < 0) {
            x = 1 / x;
            N = -N;
        }

        double result = 1.0;

        while(N > 0) {
            if((N & 1) == 1) {
                result *= x;
            }

            x *= x;
            N >>= 1;
        }

        return result;
    }
}