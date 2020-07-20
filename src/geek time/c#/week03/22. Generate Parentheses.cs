using System;
using System.Collections.Generic;
using System.Text;

namespace week03 {
    public partial class Solution {
        private IList<string> _list = new List<string>();
        public IList<string> GenerateParenthesis(int n) {
            // 递归解答，存在一个技巧：
            // 合法的括号有如下两个特征：
            // 1. 左括号满足n个的条件，并且随时都可以添加
            // 2. 右括号在添加时必须有相同的数量的左括号相匹配
            GenerateRecursion("", n, 0, 0);
            return _list;
        }

        private void GenerateRecursion(string cur, int n, int left, int right) {
            if (left == n && right == n) {
                _list.Add(cur);
                return;
            }
            // 左括号小于等于n时即可随意添加
            if (left < n) {
                GenerateRecursion(cur + "(", n, left + 1, right);
            }
            // 右括号前有多于右括号的左括号时即可添加
            if (right < left) {
                GenerateRecursion(cur + ")", n, left, right + 1);
            }
        }
    }
}
