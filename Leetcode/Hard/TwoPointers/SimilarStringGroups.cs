namespace Leetcode.Hard.TwoPointers;

public class SimilarStringGroups {
    public int NumSimilarGroups(string[] strs) {
        int n = strs.Length;
        bool[] visited = new bool[n];
        int count = 0;

        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                Dfs(i);
                count++;
            }
        }

        return count;

        void Dfs(int i) {
            visited[i] = true;
            for (int j = 0; j < n; j++) {
                if (!visited[j] && AreSimilar(strs[i], strs[j])) {
                    Dfs(j);
                }
            }
        }

        bool AreSimilar(string a, string b) {
            if (a == b) return true;

            int first = -1, second = -1;

            for (int i = 0; i < a.Length; i++) {
                if (a[i] != b[i]) {
                    if (first == -1)
                        first = i;
                    else if (second == -1)
                        second = i;
                    else
                        return false;
                }
            }

            return second != -1 &&
                   a[first] == b[second] &&
                   a[second] == b[first];
        }
    }
}