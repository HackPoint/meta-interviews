using System.Text;

namespace Leetcode.Medium.Hashmap___Sorting;

public class GroupOfAnagrams
{
    /*
   Input: strs = ["eat","tea","tan","ate","nat","bat"]
   Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
 */
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var map = new Dictionary<string, List<string>>();
        Span<int> freq = stackalloc int[26];

        foreach (var word in strs)
        {
            freq.Clear();

            foreach (char c in word)
                freq[c - 'a']++;

            // Convert the freq span to a unique key string
            var keyBuilder = new StringBuilder(52);
            for (int i = 0; i < 26; i++)
            {
                keyBuilder.Append(freq[i]);
                keyBuilder.Append(',');
            }

            string key = keyBuilder.ToString();

            if (!map.TryGetValue(key, out var list))
            {
                list = new List<string>();
                map[key] = list;
            }

            list.Add(word);
        }

        return map.Values.ToList<IList<string>>();
    }
}