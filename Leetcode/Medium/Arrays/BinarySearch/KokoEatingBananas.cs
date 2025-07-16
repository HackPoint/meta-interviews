namespace Leetcode.Medium.Arrays.BinarySearch;

/// <summary>
/// Determines the minimum eating speed (bananas per hour) required for Koko to eat all banana piles within h hours.
///
/// This method uses Binary Search on the answer space (1 to maxK) to efficiently locate the minimum viable speed.
/// It optimizes the search range by narrowing down the upper bound using the formula:
///     maxK ≈ ceil(maxPile / (h / piles.Length))
///
/// For each speed candidate k, the total time is calculated as:
///     ⌈pile / k⌉ = (pile + k - 1) / k
///
/// The search continues until the lowest valid k is found that satisfies the constraint:
///     total hours ≤ h
///
/// Time Complexity:     O(n * log m)
///     where n = piles.Length, m = max pile value
/// Space Complexity:    O(1)
///
/// Key techniques:
/// - Binary Search on Answer
/// - Ceil division without using floating point
/// - Optimized upper bound based on average time per pile
/// </summary>
public class KokoEatingBananas
{
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1, right = piles.Max();

        while (left < right) {
            int mid = (left + right) / 2;
            if (IsEnough(piles, mid, h)) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return left;
    }

    private bool IsEnough(int[] piles, int k, int h)
    {
        int hours = 0;
        for (int i = 0; i < piles.Length; i++) {
            hours += (piles[i] + k - 1) / k;
            if(hours > h) 
                return false;
        }
        return hours <= h;
    }
}