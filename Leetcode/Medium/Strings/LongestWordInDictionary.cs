namespace Leetcode.Medium.Strings;

public class LongestWordInDictionary
{
    public string LongestWord(string[] words)
    {
        // Sorting Ascending
        Array.Sort(words, (a, b) =>
        {
            if (a.Length != b.Length)
                return a.Length - b.Length;
            return string.Compare(a, b, StringComparison.Ordinal);
        });
        var wordSet = new HashSet<string> { string.Empty };
        string longestPrefix = string.Empty;

        foreach (var word in words)
        {
            string prefix = word.Substring(0, word.Length - 1);
            if (wordSet.Contains(prefix))
            {
                wordSet.Add(word);

                if (word.Length > longestPrefix.Length || (word.Length == longestPrefix.Length &&
                                                           String.CompareOrdinal(word, longestPrefix) < 0))
                    longestPrefix = word;
            }
        }

        return longestPrefix;
    }
}