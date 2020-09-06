using System;
using System.Text;

namespace week09 {
    public partial class Solution {
        public string GetPermutation(int n, int k) {
            // leetcode每日一题，剪枝经典题
            var fa = new int[n];
            fa[0] = 1;
            for (var i = 1; i < n; i++)
                fa[i] = fa[i - 1] * i;
            var ans = new StringBuilder(string.Empty);
            DFS_60(0, ans, n, k, new int[n], fa);
            return ans.ToString();
        }
        private void DFS_60(int p, StringBuilder ans, int n, int k, int[] visited, int[] fa) {
            if (p == n) return;
            var count = fa[n - p - 1];
            for (var i = 1; i <= n; i++) {
                if (visited[i - 1] != 0) continue;
                if (count < k) {
                    k -= count;
                    continue;
                }
                visited[i - 1]++;
                ans.Append(i.ToString());
                DFS_60(p + 1, ans, n, k, visited, fa);
                return;
            }
        }
    }
}