using System;
using System.Collections.Generic;
using System.Text;

namespace week07 {
    public partial class Solution {
        public bool IsValidSudoku(char[][] board) {
            var rows = new int[9, 9];
            var columns = new int[9, 9];
            var boxes = new int[9, 9];
            for (var i = 0; i < 9; i++) {
                for (var j = 0; j < 9; j++) {
                    if (board[i][j] == '.') continue;
                    var boxIndex = (i / 3) * 3 + j / 3;
                    var num = board[i][j] - '1';
                    if (boxes[boxIndex, num]++ > 0) return false;
                    if (rows[i, num]++ > 0) return false;
                    if (columns[j, num]++ > 0) return false;
                }
            }
            return true;
        }
    }
}
