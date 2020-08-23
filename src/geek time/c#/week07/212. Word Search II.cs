using System;
using System.Collections.Generic;
using System.Text;

namespace week07 {
    public partial class Solution {
        private int[] directionX = new int[] { -1, 1, 0, 0};
        private int[] directionY = new int[] { 0, 0, -1, 1};
        private TrieNode trie = new TrieNode();
        private IList<string> ans_212 = new List<string>();
        private HashSet<string> hashMap = new HashSet<string>();
        public IList<string> FindWords(char[][] board, string[] words) {
            if (board.Length == 0 || words.Length == 0) return ans_212;
            foreach (var word in words) 
                trie.Add(word);
            for (var i = 0; i < board.Length; i++)
                for (var j = 0; j < board[0].Length; j++) {
                    var visited = new HashSet<string>();
                    visited.Add(i + "_" + j);
                    DFS_212(i, j, board, "", visited);
                }
            return ans_212;
        }

        private void DFS_212(int x, int y, char[][] board, string current, HashSet<string> visited) {
            if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length) return;
            current += board[x][y];
            if (hashMap.Contains(current)) return;
            if (trie.Search(current)) {
                ans_212.Add(current);
                hashMap.Add(current);
            }
            if (trie.StartsWith(current)) {
                visited.Add(x + "_" + y);
                for (var i = 0; i < directionX.Length; i++) {
                    var newX = x + directionX[i]; var newY = y + directionY[i];
                    if (!visited.Contains(newX + "_" + newY)) {
                        DFS_212(newX, newY, board, current, visited);
                    }
                }
            }
        }

        private class TrieNode {
            internal IDictionary<char, TrieNode> root;
            internal bool isEnd;

            public TrieNode() {
                root = new Dictionary<char, TrieNode>();
                isEnd = false;
            }

            public void Add(string word) {
                if (string.IsNullOrEmpty(word)) return;
                var node = this;
                foreach (var ch in word) {
                    if (!node.root.ContainsKey(ch)) {
                        node.root.Add(ch, new TrieNode());
                    }
                    node = node.root[ch];
                }
                node.isEnd = true;
            }

            public bool Search(string word) {
                var node = SearchNode(word);
                return node != null && node.isEnd;
            }

            public bool StartsWith(string prefix) {
                return SearchNode(prefix) != null;
            }

            private TrieNode SearchNode(string word) {
                if (string.IsNullOrEmpty(word)) return null;
                var node = this;
                foreach (var ch in word) {
                    if (!node.root.ContainsKey(ch)) return null;
                    node = node.root[ch];
                }
                return node;
            }
        }
    }
}
