using System;
using System.Collections.Generic;
using System.Text;

namespace week04 {
    public partial class Solution {
        private readonly int[] direction = new int[] { 0, 1, -1 };
        private bool isFirst = true;
        public char[][] UpdateBoard(char[][] board, int[] click) {
            var x = click[0]; var y = click[1];
            if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length) return board;
            if (board[x][y] == 'M') {
                if (isFirst) board[x][y] = 'X';
                isFirst = false;
                return board;
            } else if (board[x][y] == 'B' || char.IsDigit(board[x][y])) return board;
            var mines = 0;
            foreach (var i in direction)
                foreach (var j in direction) {
                    if (i == 0 && j == 0) continue;
                    var tempX = x + i; var tempY = y + j;
                    if (tempX < 0 || tempX >= board.Length || tempY < 0 || tempY >= board[0].Length) continue;
                    if (board[tempX][tempY] == 'M') mines += 1;
                }
            board[x][y] = mines == 0 ? 'B' : char.Parse(mines.ToString());
            if (char.IsDigit(board[x][y])) return board;
            foreach (var i in direction)
                foreach (var j in direction) {
                    if (i == 0 && j == 0) continue;
                    board = UpdateBoard(board, new int[] { x + i, y + j });
                }
            return board;
        }
    }

    internal class CodeBySelf {
        // wrong answer
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
