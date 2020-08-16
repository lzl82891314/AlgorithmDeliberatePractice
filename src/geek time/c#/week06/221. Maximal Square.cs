using System;

namespace week06 {
    public partial class Solution {
        public int MaximalSquare(char[][] matrix) {
            var ans = 0;
            if (matrix.Length == 0 || matrix[0].Length == 0) return ans;
            var dp = new int[matrix.Length, matrix[0].Length];
            for (var i = 0; i < matrix.Length; i++) {
                for (var j = 0; j < matrix[0].Length; j++) {
                    if (matrix[i][j] == '0') continue;
                    if (i == 0 || j == 0 || dp[i - 1, j] == 0 || dp[i, j - 1] == 0 || dp[i - 1, j - 1] == 0) {
                        dp[i, j] = matrix[i][j] - '0';
                    } else {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                    }
                    ans = Math.Max(dp[i, j], ans);
                }
            }
            return ans * ans;
        }
    }
}