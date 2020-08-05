using System;
using System.Collections.Generic;
using System.Text;

namespace week04 {
    public partial class Solution {
        public char[][] UpdateBoard(char[][] board, int[] click) {
            if (board == null || board.Length == 0) return board;
            var cur = board[click[0]][click[1]];
            if (cur == 'M') {
                board[click[0]][click[1]] = 'X';
                return board;
            }
            DFS_529(board, click[0], click[1]);
            return board;
        }

        private int DFS_529(char[][] board, int x, int y) {
            if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length) return 0;
            var cur = board[x][y];
            if (cur == 'B' || char.IsDigit(cur)) return 0;
            if (cur == 'M' || cur == 'X') {
                board[x][y] = 'X';
                return 1;
            }
            board[x][y] = 'B';
            var sum = 0;
            sum += DFS_529(board, x + 1, y);
            sum += DFS_529(board, x - 1, y);
            sum += DFS_529(board, x, y + 1);
            sum += DFS_529(board, x, y - 1);
            //sum += DFS_529(board, x + 1, y + 1);
            //sum += DFS_529(board, x - 1, y - 1);
            //sum += DFS_529(board, x + 1, y - 1);
            //sum += DFS_529(board, x - 1, y + 1);
            board[x][y] = sum == 0 ? 'B' : char.Parse(sum.ToString());
            return 0;
        }
    }
}
