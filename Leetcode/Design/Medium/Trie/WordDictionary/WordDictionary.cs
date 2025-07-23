namespace Leetcode.Design.Medium.Trie.WordDictionary;

public class WordDictionary
{
    private readonly TrieNode root = new();

    public void AddWord(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            int index = c - 'a';
            node.Children[index] ??= new TrieNode();
            node = node.Children[index];
        }

        node.IsWord = true;
    }

    public bool Search(string word)
    {
        return SearchFrom(root, word, 0);
    }

    private bool SearchFrom(TrieNode node, string word, int i)
    {
        if (i == word.Length) return node.IsWord;

        char c = word[i];
        if (c == '.')
        {
            foreach (var child in node.Children)
            {
                if (child != null && SearchFrom(child, word, i + 1))
                    return true;
            }

            return false;
        }

        int index = c - 'a';
        var next = node.Children[index];
        return next != null && SearchFrom(next, word, i + 1);
    }
}

public class TrieNode
{
    public TrieNode[] Children = new TrieNode[26];
    public bool IsWord;
}