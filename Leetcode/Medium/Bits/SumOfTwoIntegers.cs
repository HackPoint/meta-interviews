namespace Leetcode.Medium.Bits;

/// <summary>
/// Computes the sum of two integers without using the '+' or '-' operators.
/// This uses bitwise operations to simulate addition:
/// - XOR (^) is used to add bits without carrying.
/// - AND (&) followed by a left shift (<< 1) calculates the carry.
/// The loop continues until there is no carry left.
/// </summary>
/// <param name="a">First integer</param>
/// <param name="b">Second integer</param>
/// <returns>The sum of a and b</returns>
public class SumOfTwoIntegers {
    public int GetSum(int a, int b) {
        while(b != 0) {
            // carry holds the common set bits of a and b (i.e., bits that will generate a carry)
            int carry = (a & b) << 1;
            
            // XOR adds a and b without carrying
            a ^= b;
            
            // carry is added in the next iteration
            b = carry;
        }
        return a;
    }
}