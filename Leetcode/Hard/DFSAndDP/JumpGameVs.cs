namespace Leetcode.Hard.DFSAndDP;

public class JumpGameVs {
    public int MaxJumps(int[] arr, int d) {
        int n = arr.Length;
        int[] memo = new int[n];

        int Dfs(int i) {
            if (memo[i] != 0) return memo[i];
            int maxSteps = 1;

            // Jump to the left
            for (int j = i - 1; j >= Math.Max(0, i - d); j--) {
                if (arr[j] >= arr[i]) break;
                maxSteps = Math.Max(maxSteps, 1 + Dfs(j));
            }

            // Jump to the right
            for (int j = i + 1; j <= Math.Min(n - 1, i + d); j++) {
                if (arr[j] >= arr[i]) break;
                maxSteps = Math.Max(maxSteps, 1 + Dfs(j));
            }

            memo[i] = maxSteps;
            return maxSteps;
        }

        int result = 1;
        for (int i = 0; i < n; i++) {
            result = Math.Max(result, Dfs(i));
        }

        return result;
    }
}