namespace Leetcode.Medium.Arrays.BinarySearch;

/// <summary>
/// Classification: Binary Search
/// Algorithm: Dual Binary Search (leftmost & rightmost)
///
/// Explanation (RU):
/// • Мы выполняем **два** независимых бинарных поиска.
///   1. <b>LeftBinarySearch</b> — находим крайний левый индекс target:<br/>
///      при совпадении `nums[mid] == target` сдвигаем <c>right = mid - 1</c>,
///      сохраняя текущий mid как потенциальный ответ.<br/>
///   2. <b>RightBinarySearch</b> — находим крайний правый индекс target:<br/>
///      при совпадении сдвигаем <c>left = mid + 1</c>.
/// • Оба поиска занимают O(log n), итог — O(log n) времени и O(1) памяти.
///
/// Time Complexity:  O(log n)  
/// Space Complexity: O(1)
/// </summary>
public class LeftRightBoundSearch
{
    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 0) return [-1, -1];

        int left = 0, right = nums.Length - 1;
        int leftBound = LeftBinarySearch(left, right, target, nums);
        int rightBound = RightBinarySearch(left, right, target, nums);
        return [leftBound, rightBound];
    }

    /// <summary>
    /// Returns the index of the last (rightmost) occurrence of target, or -1 if not found.
    /// </summary>
    private int RightBinarySearch(int left, int right, int target, int[] nums)
    {
        int answer = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else
            {
                answer = mid;
                left = mid + 1;
            } 
        }

        return answer;
    }

    /// <summary>
    /// Returns the index of the first (leftmost) occurrence of target, or -1 if not found.
    /// </summary>
    private int LeftBinarySearch(int left, int right, int target, int[] nums)
    {
        int answer = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else
            {
                answer = mid;
                right = mid - 1;
            } 
        }

        return answer;
    }
}