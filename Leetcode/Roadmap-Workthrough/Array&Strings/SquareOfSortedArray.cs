namespace Leetcode.Roadmap_Workthrough.Array_Strings;

public class SquareOfSortedArray
{
    public int[] SortedSquares(int[] nums) {
        int n = nums.Length;
        Span<int> result = stackalloc int[n];

        int left = 0, right = n - 1;
        int i = n - 1;
        while(left <= right) {
            int a = nums[left], b = nums[right];
            int squareA = a * a, squareB = b * b;

            if (squareA > squareB) {
                result[i--] = squareA;
                left++;
            } else {
                result[i--] = squareB;
                right--;
            }
            
        }
        return result.ToArray();
    }
}