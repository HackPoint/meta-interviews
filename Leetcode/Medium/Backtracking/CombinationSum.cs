namespace Leetcode.Medium.Backtracking;
/// <summary>
/// Finds all unique combinations of candidates that sum up to target.
/// Each candidate can be used unlimited times.
/// 
/// Backtracking approach: try each candidate starting from current index,
/// subtracting from the target and exploring deeper.
/// 
/// Time Complexity:  Exponential (O(2^T) in worst case)
/// Space Complexity: O(target) recursion depth + result storage
/// </summary>
public class CombinationSums
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);// Optional: early pruning optimization
        List<IList<int>> result = new List<IList<int>>();
        
        // Backtracking
        Backtrack(0, target, new List<int>(), result, candidates);
        
        // Simple Dfs
        int[] path = new int[40]; // Assumption: max depth if path won't exceed 40
        Dfs(candidates, target, 0, 0, path, result);
        return result;
    }

    private void Dfs(int[] candidates, int target, int index, int depth, int[] path, List<IList<int>> result)
    {
        if (target == 0)
        {
            var comb = new List<int>(depth);
            for (int i = 0; i < depth; i++)
                comb.Add(path[i]);
            result.Add(comb);
        }

        for (int i = index; i < candidates.Length; i++)
        {
            int c = candidates[i];
            if(c > target) break;

            path[depth] = c;
            Dfs(candidates, target - c, i, depth + 1, path, result);
        }
    }
    private void Backtrack(int start, int target, List<int> path, List<IList<int>> result, int[] candidates)
    {
        if (target == 0)
        {
            result.Add([..path]); // Found valid combination
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            int candidate = candidates[i];
            if(candidate > target) break;
            
            path.Add(candidate);
            
            Backtrack(i, target - candidate, path, result, candidates);
            path.RemoveAt(path.Count - 1); // undo choice (Backtrack)
        }
    }
}