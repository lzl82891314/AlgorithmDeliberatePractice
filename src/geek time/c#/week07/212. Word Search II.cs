using System;
using System.Collections.Generic;
using System.Text;

namespace week07 {
    public partial class Solution {
        private readonly int[] directionX = new int[] { -1, 1, 0, 0};
        private readonly int[] directionY = new int[] { 0, 0, -1, 1};
        private readonly Trie trie_212 = new Trie();
        private readonly IList<string> ans_212 = new List<string>();
        private readonly HashSet<string> hashMap_212 = new HashSet<string>();

        public IList<string> FindWords(char[][] board, string[] words) {
            if (board.Length == 0 || words.Length == 0) return ans_212;
            foreach (var word in words)
                trie_212.Insert(word);
            for (var i = 0; i < board.Length; i++)
                for (var j = 0; j < board[0].Length; j++)
                    DFS_212(i, j, board, "", new HashSet<string>());
            return ans_212;
        }

        private void DFS_212(int x, int y, char[][] board, string current, HashSet<string> visited) {
            visited.Add(x + "_" + y);
            current += board[x][y];
            if (trie_212.Search(current) && !hashMap_212.Contains(current)) {
                ans_212.Add(current);
                hashMap_212.Add(current);
            }
            if (trie_212.StartsWith(current)) {
                for (var i = 0; i < directionX.Length; i++) {
                    var newX = x + directionX[i]; var newY = y + directionY[i];
                    var key = newX + "_" + newY;
                    if (!visited.Contains(key) && newX >= 0 && newX < board.Length && newY >= 0 && newY < board[0].Length) {
                        visited.Add(key);
                        DFS_212(newX, newY, board, current, visited);
                        visited.Remove(key);
                    }
                }
            }
        }
    }
}
