namespace Leetcode.Hard.Trie;

/// <summary>
/// Problem:
/// Given a list of unique words, find all distinct pairs of indices (i, j)
/// such that concatenation words[i] + words[j] results in a palindrome.
///
/// Approach:
/// 1. Build a dictionary mapping word -> index for fast lookup.
/// 2. For each word, iterate through all possible prefix/suffix splits.
/// 3. For each split:
///     - If prefix is a palindrome and reversed suffix exists in the map (and is not self), add (j, i).
///     - If suffix is a palindrome and reversed prefix exists (and is not self), add (i, j).
///    [Note: We skip cut == len in suffix-checking to avoid duplicates.]
/// 4. Check each palindrome condition with a two-pointer method.
/// 5. Reverse lookup is done in O(1) using Dictionary<string, int>.
///
/// Time Complexity:
/// - Let n = number of words, k = average word length.
/// - For each word: O(k) splits, O(k) palindrome check, O(1) map lookup.
/// - Total: O(n * k^2) time, O(n * k) space.
///
/// Edge Cases Handled:
/// - Empty string: can pair with any palindrome word.
/// - Self-pairs (i == j): explicitly excluded via `j != i`.
/// - Words that are exact reverses of each other (e.g., "bat", "tab").
/// - Partial reverses combined with palindromic prefixes/suffixes.
///
/// Example:
/// words = ["abcd", "dcba", "lls", "s", "sssll"]
/// Output: [[0,1], [1,0], [3,2], [2,4]]
///
/// Notes:
/// - Efficient and readable; avoids brute-force O(n^2 * k).
/// - Can be further optimized using Trie (see alternate implementation).
/// </summary>

public class PalindromePair
{
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        var res = new List<IList<int>>();
        var wordIndex = new Dictionary<string, int>();
        
        // Step 1: Build a map from word => index
        for (int i = 0; i < words.Length; i++)
            wordIndex[words[i]] = i;
        
        // Step 2: For each word, try all possible splits
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            int length = word.Length;

            for (int cut = 0; cut <= length; cut++)
            {
                string prefix = word.Substring(0, cut);
                string suffix = word.Substring(cut);
                
                // Case 1: If prefix is Palindrome, find reversed suffix
                if (IsPalindrome(prefix))
                {
                    string reversedSuffix = Reverse(suffix);
                    if (wordIndex.TryGetValue(reversedSuffix, out int j) && j != i)
                        res.Add(new List<int> { j, i });
                }
                
                // Case 2: If suffix is palindrome, find reversed prefix
                // Avoid duplicates when cut == len (whole word already tested in prefix case)
                if (cut != length && IsPalindrome(suffix)) {
                    string reversedPrefix = Reverse(prefix);
                    if (wordIndex.TryGetValue(reversedPrefix, out int j) && j != i) {
                        res.Add(new List<int> { i, j });
                    }
                }
            }
        }

        return res;
    }

    private bool IsPalindrome(string word)
    {
        int left = 0, right = word.Length - 1;

        while (left < right)
            if (word[left++] != word[right--]) return false;
        return true;
    }

    private string Reverse(string word)
    {
        char[] chars = word.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}