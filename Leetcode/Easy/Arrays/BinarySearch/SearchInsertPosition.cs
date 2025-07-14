namespace Leetcode.Easy.Arrays.BinarySearch;

/// <summary>
/// Classification: Binary Search  
/// Algorithm: Lower Bound Binary Search
///
/// Explanation (RU):
/// • Ищем позицию для вставки `target` в отсортированный массив `nums`.
/// • Если `target` уже существует — возвращаем индекс.
/// • Если нет — находим первую позицию `i`, где `nums[i] >= target`.
/// • Бинарный поиск работает на подотрезке, сдвигая границы:
///     - если `nums[mid] < target` → ищем справа: left = mid + 1
///     - если `nums[mid] >= target` → ищем слева: right = mid - 1
/// • После выхода из цикла, `left` указывает на позицию вставки.
///
/// Time Complexity:  O(log n)  
/// Space Complexity: O(1)
/// </summary>
public class SearchInsertPosition
{
    public int SearchInsert(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;

        while(left <= right) {
            int mid = (left + right) / 2;
            if(nums[mid] == target) {
                return mid;
            } else if (nums[mid] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return left;
    }
}