namespace Leetcode.Roadmap_Workthrough.Array_Strings;

public class MinSwapsToMakeSequenceIncreasing
{
    /// <summary>
    /// 🔎 Classification:
    ///     - Category: Dynamic Programming (optimized to Greedy-style)
    ///     - Pattern: Greedy + Reach Tracking (или DP с оптимизацией до O(1) памяти)
    ///
    /// 🧠 Explanation:
    ///     - У нас есть два массива одинаковой длины: nums1 и nums2.
    ///     - На каждом индексе можно либо оставить элементы как есть, либо поменять их местами (swap).
    ///     - Цель — сделать обе последовательности строго возрастающими при минимальном числе swap-ов.
    ///
    /// 🧩 Идея:
    ///     - Используем две переменные:
    ///         - `keep` — минимальное число swap-ов, если текущий элемент не меняли
    ///         - `swap` — минимальное число swap-ов, если текущий элемент поменяли
    ///     - На каждом шаге определяем:
    ///         - можно ли оставить (canKeep)
    ///         - можно ли поменять (canSwap)
    ///     - Обновляем `keep` и `swap`, минимизируя значения
    ///
    /// ⏱ Time Complexity: O(n)
    /// 📦 Space Complexity: O(1)
    /// </summary>
    public int MinSwap(int[] nums1, int[] nums2) {
        int keep = 0, swap = 1;
        int n = nums1.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool canKeep = nums1[i + 1] > nums1[i] && nums2[i + 1] > nums2[i];
            bool canSwap = nums1[i + 1] > nums2[i] && nums2[i + 1] > nums1[i];
           
            int nextKeep = int.MaxValue;
            int nextSwap = int.MaxValue;
            
            if (canKeep)
            {
                nextKeep = Math.Min(nextKeep, keep);
                nextSwap = Math.Min(nextSwap, swap + 1);
            }
            
            if (canSwap)
            {
                nextKeep = Math.Min(nextKeep, swap);
                nextSwap = Math.Min(nextSwap, keep + 1);
            }

            keep = nextKeep;
            swap = nextSwap;
        }

        return Math.Min(keep, swap);
    }
}