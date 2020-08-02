using System;

namespace week04 {
    public partial class Solution {
        public int NumIslands(char[][] grid) {
            if (grid == null || grid.Length == 0) return 0;
            var num = 0;
            for (var i = 0; i < grid.Length; i++) {
                for (var j = 0; j< grid[0].Length; j++) {
                    if (grid[i][j] == '1') {
                        num++;
                        DFS_200(grid, i, j);
                    }
                }
            }
            return num;
        }
        private void DFS_200(char[][] grid, int i, int j) {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0') return;
            grid[i][j] = '0';
            DFS_200(grid, i + 1, j);
            DFS_200(grid, i - 1, j);
            DFS_200(grid, i, j + 1);
            DFS_200(grid, i, j - 1);
        }
    }
}