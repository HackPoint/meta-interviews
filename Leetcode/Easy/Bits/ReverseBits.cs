namespace Leetcode.Easy.Bits;

/// <summary>
/// Reverses the bits of a 32-bit unsigned integer.
/// Each bit at position i in the input will be moved to position (31 - i) in the result.
/// 
/// Example:
/// Input : 00000010100101000001111010011100 (binary)
/// Output: 00111001011110000010100101000000 (binary)
/// 
/// Time Complexity:  O(1) — 32 fixed iterations
/// Space Complexity: O(1)
/// </summary>
public class ReverseBit
{
    public int ReverseBits(int n) {
        uint un = (uint)n;
        uint res = 0;
        for (int i = 0; i < 32; i++)  {
            res <<= 1;
            res |= (un & 1);
            un >>= 1;
        }

        return (int)res;
    }
}