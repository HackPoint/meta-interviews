namespace Leetcode.Medium.Arrays.Digits;

public class SequentialDigitss {
    public IList<int> SequentialDigits(int low, int high) {
        IList<int> results = new List<int>();

        for (int length = 2; length <= 9; length++) {
            for (int start = 1; start <= 10 - length; start++) {
                int num = BuildNumber(start, length);

                if (num >= low && num <= high) {
                    results.Add(num);
                }
            }
        }

        int BuildNumber(int from, int to) {
            int num = 0;

            for(int i = 0; i < to; i++) {
                if(from + i > 9) return -1;
                num = (num * 10) + (from + i);
            }

            return num;
        }
        return results;
    }
}