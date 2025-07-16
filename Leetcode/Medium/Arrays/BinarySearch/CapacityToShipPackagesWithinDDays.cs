namespace Leetcode.Medium.Arrays.BinarySearch;


/// <summary>
/// Determines the minimum ship capacity required to deliver all packages within a given number of days.
///
/// The packages must be delivered in order, and no package can be split.
/// For a given capacity, the method simulates loading packages day by day.
/// If the current package doesn't fit in the day's remaining capacity, a new day is used.
/// 
/// This implementation performs a binary search on the answer space:
/// • Lower bound (left) is the maximum weight of a single package.
/// • Upper bound (right) is the total weight of all packages (i.e., ship everything in one day).
///
/// The binary search tries to find the smallest possible capacity such that
/// the total number of required days is less than or equal to the given limit.
///
/// Time Complexity:  O(n * log(sum - max))
/// Space Complexity: O(1)
///
/// Key optimizations:
/// • Early exit from validation if days exceed limit
/// • Inlined validity check (no extra method calls)
/// • Bit-shift used for fast midpoint calculation (mid = left + ((right - left) >> 1))
/// </summary>
public class CapacityToShipPackagesWithinDDays
{
    public int ShipWithinDays(int[] weights, int days) {
        int left = 0, right =0;

        for (int i = 0; i < weights.Length; i++)
        {
            left = System.Math.Max(left, weights[i]); // max(weights)
            right += weights[i];                            // sum(weights)
        }

        while (left < right)
        {
            int mid = left + ((right - left) >> 1);
            int currentLoad = 0, requiredDays = 1;

            for (int i = 0; i < weights.Length; i++)
            {
                if (currentLoad + weights[i] > mid)
                {
                    requiredDays++;
                    currentLoad = 0;
                }
                currentLoad += weights[i];
                if (requiredDays > days)
                    break; // early exit
            }

            if (requiredDays <= days)
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
}