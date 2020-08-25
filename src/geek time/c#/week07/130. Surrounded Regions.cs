using System;
using System.Collections.Generic;
using System.Text;

namespace week07 {
    public partial class Solution {
        public void Solve(char[][] board) {
            for (var i = 0; i < board.Length; i++) {
                for (var j = 0; j < board[0].Length; j++) {
                    if (board[i][j] == 'X') continue;
                    var ans = new List<int[]>();
                    if (DFS(i, j, board, new HashSet<string>(), ans) && ans.Count > 0) {
                        foreach (var item in ans) {
                            board[item[0]][item[1]] = 'X';
                        }
                    }
                }
            }
        }

        private bool DFS(int x, int y, char[][] board, HashSet<string> visited, List<int[]> ans) {
            if (visited.Contains(x + "_" + y) || board[x][y] == 'X') return true;
            if (board[x][y] == 'O' && (x == 0 || x == board.Length - 1 || y == 0 || y == board[0].Length - 1)) return false;
            visited.Add(x + "_" + y);
            for (var i = 0; i < directionX.Length; i++) {
                var newX = x + directionX[i]; var newY = y + directionY[i];
                if (newX < 0 || newX >= board.Length || newY < 0 || newY >= board[0].Length) continue;
                if (!DFS(newX, newY, board, visited, ans)) return false;
            }
            ans.Add(new int[] { x, y });
            return true;
        }

        public void Solve_UnionFind(char[][] board) {
            if (board.Length == 0 || board[0].Length == 0) return;
            var union = new UnionFind(board.Length * board[0].Length + 1);
            // 设置最后一个位置为边界O点的parent
            var dummy = board.Length * board[0].Length;
            for (var i = 0; i < board.Length; i++) {
                for (var j = 0; j < board[0].Length; j++) {
                    if (board[i][j] != 'O') continue;
                    var node = i * board[0].Length + j;
                    if (i == 0 || i == board.Length - 1 || j == 0 || j == board[0].Length - 1) {
                        union.Union(node, dummy);
                        continue;
                    }
                    for (var d = 0; d < directionX.Length; d++) {
                        var newX = i + directionX[d]; var newY = j + directionY[d];
                        if (newX < 0 || newX >= board.Length || newY < 0 || newY >= board[0].Length) continue;
                        if (board[newX][newY] == 'O') {
                            var newNode = newX * board[0].Length + newY;
                            union.Union(node, newNode);
                        }
                    }
                }
            }
            for (var i = 0; i < board.Length; i++) {
                for (var j = 0; j < board[0].Length; j++) {
                    if (board[i][j] != 'O') continue;
                    var node = i * board[0].Length + j;
                    if (union.Find(node) == union.Find(dummy)) board[i][j] = 'O';
                    else board[i][j] = 'X';
                }
            }
        }
    }
}
