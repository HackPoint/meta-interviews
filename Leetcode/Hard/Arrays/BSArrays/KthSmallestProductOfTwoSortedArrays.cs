namespace Leetcode.Hard.Arrays.BSArrays;

public class KthSmallestProductOfTwoSortedArrays
{
    public long KthSmallestProduct(int[] nums1, int[] nums2, long k)
    {
        int n = nums1.Length, m = nums2.Length;
    
        // Границы поиска: минимальное и максимальное произведение
        long a = (long)nums1[0]     * nums2[0];
        long b = (long)nums1[0]     * nums2[m - 1];
        long c = (long)nums1[n - 1] * nums2[0];
        long d = (long)nums1[n - 1] * nums2[m - 1];

        long low  = Math.Min(Math.Min(a, b), Math.Min(c, d));
        long high = Math.Max(Math.Max(a, b), Math.Max(c, d));

        // Бинарный поиск по значению произведения
        while (low < high)
        {
            long mid = low + (high - low) / 2;
            if (CountLE(mid, nums1, nums2) < k)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }

    private long CountLE(long x, int[] A, int[] B)
    {
        int n = A.Length, m = B.Length;
        long cnt = 0;

        // Отрицательные A[i]
        for (int i = 0; i < n && A[i] < 0; i++)
        {
            int l = 0, r = m;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if ((long)A[i] * B[mid] <= x) r = mid;
                else l = mid + 1;
            }
            cnt += (m - l); // количество j, начиная с позиции l
        }

        // Нули из A
        int zeroCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (A[i] == 0) zeroCount++;
            else if (A[i] > 0) break;
        }
        if (x >= 0) cnt += (long)zeroCount * m;

        // Положительные A[i]
        for (int i = n - 1; i >= 0 && A[i] > 0; i--)
        {
            int l = 0, r = m;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if ((long)A[i] * B[mid] <= x) l = mid + 1;
                else r = mid;
            }
            cnt += l; // j < l подходят
        }

        return cnt;
    }
}