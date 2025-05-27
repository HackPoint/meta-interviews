namespace Leetcode.Easy.Bits;

public class PowerOfTwo {
    public bool IsPowerOfTwo(int n) {
        if(n <= 0) return false;
        return (n & (n - 1)) == 0;
    }
}