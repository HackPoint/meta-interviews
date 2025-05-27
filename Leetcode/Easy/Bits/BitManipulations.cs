namespace Leetcode.Easy.Bits;

public class BitManipulations {
    int SingleNumber(int[] nums) {
        int ones = 0, twos = 0;

        foreach (int i in nums) {
            twos = twos | (ones & i);
            ones = ones ^ i;
            int common = ones & twos;

            ones &= ~common;
            twos &= ~common;
        }

        return ones;
    }
}