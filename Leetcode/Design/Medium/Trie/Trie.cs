using Leetcode.Design.Medium.Trie.WordDictionary;

namespace Leetcode.Design.Medium.Trie;

public class Trie
{
    private readonly TrieNode _root = new();

    public void Insert(string word)
    {
        var node = _root;

        foreach (char c in word)
        {
            int index = c - 'a';
            node.Children[index] ??= new();
            node = node.Children[index];
        }

        node.IsWord = true;
    }

    public bool Search(string word)
    {
        var node = _root;
        foreach (char c in word)
        {
            int index = c - 'a';
            if (node.Children[index] == null)
                return false;

            node = node.Children[index];
        }

        return node.IsWord;
    }

    public bool StartsWith(string word)
    {
        var node = _root;
        foreach (char c in word)
        {
            int index = c - 'a';
            if (node.Children[index] == null) return false;

            node = node.Children[index];
        }

        return true;
    }
}