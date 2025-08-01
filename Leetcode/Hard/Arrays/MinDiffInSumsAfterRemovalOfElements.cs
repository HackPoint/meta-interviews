namespace Leetcode.Hard.Arrays;

public class MinDiffInSumsAfterRemovalOfElements {
    public long MinimumDifference(int[] nums) {
        int n = nums.Length / 3;
        int totalLength = nums.Length;

        long[] leftMinSum = new long[totalLength];
        long[] rightMaxSum = new long[totalLength];

        //1. Left (Heap)
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        long leftSum = 0;

        for(int i = 0; i < totalLength; i++) {
            maxHeap.Enqueue(nums[i], nums[i]);
            leftSum += nums[i];

            if(maxHeap.Count > n) {
                leftSum -= maxHeap.Dequeue();
            }

            if(i >= n - 1) {
                leftMinSum[i] = leftSum;
            }
        }

        // 2. RIGHT MinHeap
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        long rightSum = 0;

        for(int i = totalLength - 1; i >= 0; i--) {
            minHeap.Enqueue(nums[i], nums[i]);
            rightSum += nums[i];

            if(minHeap.Count > n) {
                rightSum -= minHeap.Dequeue();
            }

            if(i <= totalLength - n) {
                rightMaxSum[i] = rightSum;
            }
        }

        long minDiff = long.MaxValue;
        for(int i = n - 1; i < 2 * n; i++) {
            long diff = leftMinSum[i] - rightMaxSum[i + 1];
            minDiff = Math.Min(minDiff, diff);
        }

        return minDiff;
    }
}