using System;
using System.Collections.Generic;

namespace week09 {
    public partial class Solution {
        private int[] directionX = new int[] { 1, -1, 0, 0 };
        private int[] directionY = new int[] { 0, 0, 1, -1 };
        public bool Exist(char[][] board, string word) {
            for (var i = 0; i < board.Length; i++) {
                for (var j = 0; j < board[0].Length; j++) {
                    var visited = new HashSet<string>();
                    visited.Add($"{i}_{j}");
                    var result = DFS(i, j, 0, board, word, visited);
                    if (result) return true;
                }
            }
            return false;
        }
        private bool DFS(int x, int y, int cur, char[][] board, string word, HashSet<string> visited) {
            if (word[cur] != board[x][y]) return false;
            if (cur == word.Length - 1) return true;
            for (var i = 0; i < 4; i++) {
                var newX = directionX[i] + x;
                var newY = directionY[i] + y;
                if (newX < 0 || newX >= board.Length || newY < 0 || newY >= board[0].Length) continue;
                var key = $"{newX}_{newY}";
                if (visited.Contains(key)) continue;
                visited.Add(key);
                var result = DFS(newX, newY, cur + 1, board, word, visited);
                visited.Remove(key);
                if (result) return true;
            }
            return false;
        }
    }
}