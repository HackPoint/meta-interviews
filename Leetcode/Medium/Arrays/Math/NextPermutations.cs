namespace Leetcode.Medium.Arrays.Math;

public class NextPermutations {
    
    /*
     *
     *nums = [1, 2, 3]
         → pivot = 1 (nums[1] < nums[2])
         → swap 2 <-> 3
         → reverse [2] → результат: [1, 3, 2]
     * 
     */
    public void NextPermutation(int[] nums) {
        int n = nums.Length;
        int pivotIndex = -1;

        // 🔹 1. Найти pivot — первый элемент справа налево, который меньше следующего
        for (int i = n - 2; i >= 0; i--) {
            if (nums[i] < nums[i + 1]) {
                pivotIndex = i;
                break;
            }
        }

        // 🔹 2. Если не найден pivot — массив уже в максимальной перестановке
        if (pivotIndex == -1) {
            Array.Reverse(nums);
            return;
        }

        // 🔹 3. Найти наименьший элемент справа, который больше pivot
        for (int j = n - 1; j > pivotIndex; j--) {
            if (nums[j] > nums[pivotIndex]) {
                // 🔄 Поменять местами
                (nums[j], nums[pivotIndex]) = (nums[pivotIndex], nums[j]);
                break;
            }
        }

        // 🔹 4. Перевернуть всё после pivot, чтобы сделать минимальное продолжение
        Array.Reverse(nums, pivotIndex + 1, n - pivotIndex - 1);
    }
}