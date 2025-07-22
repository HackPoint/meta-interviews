namespace Leetcode.Medium.Arrays.Greedy;

/// <summary>
/// Classification: HashSet + Greedy
/// Algorithm: Expand from sequence start
///
/// Explanation (RU):
/// • Добавляем все числа в HashSet для O(1) поиска.
/// • Для каждого числа проверяем, является ли оно началом последовательности:
///   если нет элемента (num - 1), значит, это возможно начало.
/// • Расширяем последовательность вперёд: (num + 1), (num + 2), ...
/// • Считаем длину, обновляем максимум.
/// 
/// Time Complexity:
/// • O(n) — каждое число проверяется максимум один раз.
/// 
/// Space Complexity:
/// • O(n) — на хранение HashSet.
///
/// Edge Cases:
/// • Пустой массив → 0
/// • Все числа одинаковые → 1
/// • Несортированный массив с большим размахом → покрывается
/// </summary>
public class LongestConsecutiveSequence
{
    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0)
            return 0;

        var set = new HashSet<int>(nums);
        int maxLength = 0;

        foreach (int num in set) {
            if (!set.Contains(num - 1)) {
                int length = 1;
                int current = num;

                while (set.Contains(++current)) {
                    length++;
                }

                if (length > maxLength)
                    maxLength = length;
            }
        }

        return maxLength;
    }
}