using Leetcode.Hard.Arrays.BSArrays;

namespace Leetcode.Hard.tests;

using Xunit;

public class KthSmallestProductTests {
    private readonly KthSmallestProductOfTwoSortedArrays _sol = new();

    [Theory]
    [InlineData(new int[] { -2, -1, 0, 1, 2 },
        new int[] { -3, -1, 2, 4, 5 },
        3,
        -6L)]
    // // Single‐element arrays
    // [InlineData(new int[] { 5 }, new int[] { 10 }, 1, 50L)]
    // [InlineData(new int[] { -3 }, new int[] { -7 }, 1, 21L)]
    // [InlineData(new int[] { 0 }, new int[] { 42 }, 1, 0L)]
    //
    // // Simple two‐by‐two
    // [InlineData(new int[] { 2, 5 }, new int[] { 3, 4 }, 1, 6L)] // 2×3
    // [InlineData(new int[] { 2, 5 }, new int[] { 3, 4 }, 2, 8L)] // 2×4
    // [InlineData(new int[] { 2, 5 }, new int[] { 3, 4 }, 3, 15L)] // 5×3
    // [InlineData(new int[] { 2, 5 }, new int[] { 3, 4 }, 4, 20L)] // 5×4
    //
    // // All‐zero combinations
    // [InlineData(new int[] { 0, 1 }, new int[] { -1, 0, 1 }, 1, -1L)]
    // [InlineData(new int[] { 0, 1 }, new int[] { -1, 0, 1 }, 2, 0L)]
    // [InlineData(new int[] { 0, 1 }, new int[] { -1, 0, 1 }, 6, 1L)]
    //
    // // Mixed negative/positive, zeros
    // [InlineData(new int[] { -4, -2, 0, 3 }, new int[] { 2, 4 }, 6, 0L)]
    // [InlineData(new int[] { -2, -1, 0, 1, 2 }, new int[] { -3, -1, 2, 4, 5 }, 3, -6L)]
    // [InlineData(new int[] { -2, -1, 0, 1, 2 }, new int[] { -3, -1, 2, 4, 5 }, 1, -10L)]
    // [InlineData(new int[] { -2, -1, 0, 1, 2 }, new int[] { -3, -1, 2, 4, 5 }, 15, 5L)]
    //
    // // Duplicates
    // [InlineData(new int[] { 2, 2 }, new int[] { 3, 3 }, 1, 6L)]
    // [InlineData(new int[] { 2, 2 }, new int[] { 3, 3 }, 4, 6L)]
    //
    // // k equals total number of pairs
    // [InlineData(new int[] { 1, 2 }, new int[] { 5, 6, 7 }, 6, 14L)] // pairs sorted: 5,6,7,10,12,14
    public void KthSmallestProduct_VariousScenarios_ReturnsExpected(
        int[] nums1, int[] nums2, long k, long expected)
    {
        long actual = _sol.KthSmallestProduct(nums1, nums2, k);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void KthSmallestProduct_AllNegativeArrays()
    {
        int[] a = { -5, -4, -2 };
        int[] b = { -6, -1 };
        // products: {30,5,24,4,12,2} sorted = {2,4,5,12,24,30}
        Assert.Equal(5L, _sol.KthSmallestProduct(a, b, 3));
    }

    [Fact]
    public void KthSmallestProduct_LargeSingleZeroRegion()
    {
        int[] a = new int[1000];
        for (int i = 0; i < a.Length; i++) a[i] = 0;
        int[] b = { -1, 1 };
        // All products = 0; any k <= 2000 returns 0
        Assert.Equal(0L, _sol.KthSmallestProduct(a, b, 1500));
    }
}