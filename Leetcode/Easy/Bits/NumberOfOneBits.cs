namespace Leetcode.Easy.Bits;

/// <summary>
/// Counts the number of 1-bits (Hamming weight) in a 32-bit unsigned integer.
/// Uses Brian Kernighan's algorithm to count only set bits.
/// 
/// Time Complexity:  O(k), where k is the number of 1-bits in n (best case faster than O(32))
/// Space Complexity: O(1)
/// 
/// Example:
/// Input : n = 0b00000000000000000000000000001011
/// Output: 3
/// </summary>
public class NumberOfOneBits
{
    public int HammingWeight(int n)
    {
        int counter = 0;

        while (n != 0)
        {
            n &= (n - 1);
            counter++;
        }

        return counter;
    }
}