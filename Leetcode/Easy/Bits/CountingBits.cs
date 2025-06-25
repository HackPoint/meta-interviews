namespace Leetcode.Easy.Bits;

public class CountingBits
{
    public int[] CountBits(int n) {
        int[] bits = new int[n + 1];
        for(int i = 0; i < n + 1; i++) {
            bits[i] = bits[i >> 1] + (i & 1);
        }
        return bits;
    }
}