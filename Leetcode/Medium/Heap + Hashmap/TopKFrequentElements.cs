namespace Leetcode.Medium.Heap___Hashmap;

public class TopKFrequentElements
{
    public int[] TopKFrequentBucketSort(int[] nums, int k)
    {
        var freqMap = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            freqMap.TryGetValue(num, out int count);
            freqMap[num] = count + 1;
        }

        return BucketSort(freqMap, nums.Length).Take(k).ToArray();
    }

    private IList<int> BucketSort(Dictionary<int, int> freqMap, int size)
    {
        List<int>[] buckets = new List<int>[size + 1];
        foreach (var (num, freq) in freqMap)
        {
            if (buckets[freq] == null)
                buckets[freq] = new List<int>();
            buckets[freq].Add(num);
        }

        var result = new List<int>();
        for (int i = buckets.Length - 1; i >= 0 && result.Count < size; i--)
        {
            if (buckets[i] != null)
                result.AddRange(buckets[i]);
        }

        return result;
    }

    public int[] TopKFrequentHeap(int[] nums, int k)
    {
        var freqMap = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (!freqMap.ContainsKey(num))
                freqMap[num] = 0;

            freqMap[num]++;
        }

        var minHeap = new PriorityQueue<int, int>();
        foreach (var (num, freq) in freqMap)
        {
            minHeap.Enqueue(num, freq);

            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        int[] result = new int[k];
        for (int i = k - 1; i >= 0; i--)
        {
            result[i] = minHeap.Dequeue();
        }

        return result;
    }
}