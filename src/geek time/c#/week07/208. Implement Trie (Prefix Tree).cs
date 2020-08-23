using System.Collections.Generic;

public class Trie {
    internal IDictionary<char, Trie> root;
    internal bool isEnd;

    /** Initialize your data structure here. */
    public Trie() {
        root = new Dictionary<char, Trie>();
        isEnd = false;
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        if (string.IsNullOrEmpty(word)) return;
        var node = this;
        foreach (var ch in word) {
            if (!node.root.ContainsKey(ch)) {
                node.root.Add(ch, new Trie());
            }
            node = node.root[ch];
        }
        node.isEnd = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        var node = SearchNode(word);
        return node != null && node.isEnd;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        return SearchNode(prefix) != null;
    }

    private Trie SearchNode(string word) {
        if (string.IsNullOrEmpty(word)) return null;
        var node = this;
        foreach (var ch in word) {
            if (!node.root.ContainsKey(ch)) return null;
            node = node.root[ch];
        }
        return node;
    }
}