using System;

namespace week07 {
    public partial class Solution {
        public int FindCircleNum(int[][] M) {
            var union = new UnionFind(M.Length);
            for (var i = 0; i < M.Length; i++)
                for (var j = 0; j < M[0].Length; j++)
                    if (M[i][j] == 1 && i != j) 
                        union.Union(i, j);
            return union.count;
        }
    }
}