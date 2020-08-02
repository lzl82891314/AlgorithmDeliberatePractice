using System;

namespace week04 {
    public partial class Solution {
        public int FindContentChildren(int[] g, int[] s) {
            // 排序 + 贪心 时间复杂度 O(N*logN)
            if (s == null || s.Length == 0 || g == null || g.Length == 0) return 0;
            Array.Sort(s);
            Array.Sort(g);
            var num = 0;
            for (var i = 0; i < s.Length; i++) {
                if (num == g.Length) return num;
                if (s[i] >= g[num]) num++;
            }
            return num;
        }
    }
}