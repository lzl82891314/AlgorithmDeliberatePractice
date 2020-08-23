using System;
using System.Collections.Generic;

namespace week07 {
    public partial class Solution {
        private IList<string> ans_22 = new List<string>();
        public IList<string> GenerateParenthesis(int n) {
            DFS_22("", n, 0, 0);
            return ans_22;
        }

        private void DFS_22(string cur, int n, int left, int right) {
            if (left == n && right == n) {
                ans_22.Add(cur);
                return;
            }
            // 剪枝操作，当左括号数量不小于n则删除相应的结果
            if (left < n) {
                DFS_22(cur + "(", n, left + 1, right);
            }
            // 同剪枝操作
            if (right < left) {
                DFS_22(cur + ")", n, left, right + 1);
            }
        }
    }
}