namespace Leetcode.Easy.GreedyAlgorithms;

public class MaxProfits
{
    public int MaxProfit(int[] prices) {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        for (int i = 0; i < prices.Length; i++) {
            if (prices[i] < minPrice) {
                minPrice = prices[i];
            } else {
                maxProfit = System.Math.Max(maxProfit, prices[i] - minPrice);
            }
        }
        return maxProfit;
    }
}