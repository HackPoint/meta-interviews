namespace Leetcode.Hard.Arrays.BSArrays;

public class KthSmallestNumberInMultiplicationArray
{
    public int FindKthNumber(int m, int n, int k) {
        int low = 1;
        int high = m * n;

        while(low < high) {
            int mid = low + (high - low) / 2;
            int count = countLE(mid, m, n);

            if(count < k) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }

        return low;
    }

    private int countLE(int x, int m, int n) {
        int count = 0;
        for(int i = 1; i <= m; i++) {
            count += Math.Min(n, x / i);
        }
        return count;
    }
}