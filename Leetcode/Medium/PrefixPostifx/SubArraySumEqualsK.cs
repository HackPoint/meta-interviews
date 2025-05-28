namespace Leetcode.Medium.PrefixPostifx;

public class SubArraySumEqualsK
{
    // Approach: Prefix sum + HashMap
    public int SubarraySum(int[] nums, int k) {
        int count = 0;
        int prefixSum = 0;
        var sumFreqMap = new Dictionary<int, int> {
            { 0, 1}
        };

        foreach (var n in nums)
        {
            prefixSum += n;

            if(sumFreqMap.ContainsKey(prefixSum - k)) {
                count += sumFreqMap[prefixSum - k];                
            }
            sumFreqMap.TryGetValue(prefixSum, out int value);
            sumFreqMap[prefixSum] = value + 1;
        }

        return count;
    }
}