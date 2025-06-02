namespace Leetcode.Medium.Trie.Strings;

public class WordBreaks {
    public bool WordBreak(string s, IList<string> wordDict) {
        var trie = BuildWords(wordDict);
        bool?[] memo = new bool?[s.Length];
        return Dfs(0, s, memo, trie);
    }

    private static TrieNode BuildWords(IList<string> words) {
        var root = new TrieNode();
        foreach (string word in words) {
            var node = root;
            foreach (char c in word) {
                if (!node.Children.ContainsKey(c))
                    node.Children[c] = new TrieNode();
                node = node.Children[c];
            }

            node.IsWord = true;
        }

        return root;
    }

    private static bool Dfs(int start, string s, bool?[] memo, TrieNode root) {
        if (start == s.Length) return true;
        if (memo[start].HasValue) return memo[start].Value;

        TrieNode node = root;
        for (int end = start; end < s.Length; end++) {
            char c = s[end];
            if (!node.Children.TryGetValue(c, out node)) {
                memo[start] = false;
                return false;
            }

            if (node.IsWord && Dfs(end + 1, s, memo, root)) {
                memo[start] = true;
                return true;
            }
        }

        memo[start] = false;
        return false;
    }
}

public class TrieNode {
    public readonly Dictionary<char, TrieNode> Children = new();
    public bool IsWord = false;

    public void Insert(string word) {
        TrieNode node = this;
        foreach (char c in word) {
            if (!node.Children.ContainsKey(c))
                node.Children[c] = new TrieNode();

            node = node.Children[c];
        }

        node.IsWord = true;
    }

    public bool Search(string word) {
        TrieNode node = this;
        foreach (char c in word) {
            if (!node.Children.TryGetValue(c, out node))
                return false;
        }

        return node.IsWord;
    }
}