using System;
using System.Collections.Generic;
using System.Text;

namespace week06 {
    public partial class Solution {
        public int MinPathSum(int[][] grid) {
            for (var i = 1; i < grid.Length; i++)
                grid[i][0] += grid[i - 1][0];
            for (var j = 1; j < grid[0].Length; j++)
                grid[0][j] += grid[0][j - 1];
            for (var i = 1; i < grid.Length; i++) {
                for (var j = 1; j < grid[0].Length; j++) {
                    grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
                }
            }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }
    }
}
