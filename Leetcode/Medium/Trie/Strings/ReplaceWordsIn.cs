using System.Text;

namespace Leetcode.Medium.Trie.Strings;
/*
 * 
 *Example 1:
   Input: dictionary = ["cat","bat","rat"], sentence = "the cattle was rattled by the battery"
   Output: "the cat was rat by the bat"
   Example 2:
   
   Input: dictionary = ["a","b","c"], sentence = "aadsfasf absbs bbab cadsfafs"
   Output: "a a b c"
 * 
 */
public class ReplaceWordsIn
{
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        var trie = BuildWords(dictionary);
        var result = new List<string>();

        foreach (string word in sentence.Split(' '))
        {
            result.Add(FindPrefix(word, trie));
        }

        string FindPrefix(string s, TrieNode root)
        {
            var prefix = new StringBuilder();
            var node = root;

            foreach (char c in s)
            {
                if (!node.Children.ContainsKey(c))
                    break;

                prefix.Append(c);
                node = node.Children[c];
                if (node.IsWord)
                {
                    return prefix.ToString();
                }
            }

            return s;
        }

        return string.Join(' ', result);
    }

    private TrieNode BuildWords(IList<string> dictionary)
    {
        var root = new TrieNode();
        foreach (var word in dictionary)
        {
            var node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                    node.Children[c] = new TrieNode();
                node = node.Children[c];
            }

            node.IsWord = true;
        }

        return root;
    }
}