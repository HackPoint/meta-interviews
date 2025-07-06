namespace Leetcode.Easy.Arrays;

public class FindLuckyNumber
{
    public int FindLucky(int[] arr) {
        Span<int> freq = stackalloc int[501];
        int lucky = -1;
        for (int i = 0; i < arr.Length; i++)
            freq[arr[i]]++;

        for (int i = 1; i < freq.Length; i++)
        {
            if (i == freq[i] && i > lucky)
                lucky = i;
        }
        return lucky;
    }
}