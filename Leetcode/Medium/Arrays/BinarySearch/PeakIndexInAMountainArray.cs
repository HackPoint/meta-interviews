namespace Leetcode.Medium.Arrays.BinarySearch;

/// <summary>
/// Classification: Binary Search
/// Algorithm: Modified Binary Search on Mountain Array
///
/// Explanation (RU):
/// • Массив — "горный", т.е. строго возрастает, потом строго убывает.
/// • Используем бинарный поиск:
///     → Если <c>arr[mid] < arr[mid + 1]</c>, значит мы на возрастающей части — сдвигаем <c>left = mid + 1</c>
///     → Иначе — мы на пике или убывающей части — сдвигаем <c>right = mid - 1</c>
/// • По завершении указатель <c>left</c> указывает на пик.
///
/// Time Complexity:  O(log n)  
/// Space Complexity: O(1)
/// </summary>
public class PeakIndexInAMountainArray
{
    public int PeakIndexInMountainArray(int[] arr)
    {
        int left = 0, right = arr.Length - 1;

        while (left < right)
        {
            int mid = (left + right) / 2;

            // Мы на возрастающей части массива — пик справа
            if (arr[mid] < arr[mid + 1])
                left = mid + 1;
            else
                right = mid; // Пик либо на mid, либо слева
        }

        return left;
    }
}