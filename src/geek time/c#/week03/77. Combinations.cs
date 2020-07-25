using System;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        private IList<IList<int>> list_77 = new List<IList<int>>();
        public IList<IList<int>> Combine(int n, int k) {
            if (n == 0 || n < k) return list_77;
            BackTrackingCombine(n, k, 1, new Stack<int>());
            return list_77;
        }
        private void BackTrackingCombine(int n, int k, int start, Stack<int> stack) {
            if (stack.Count == k) {
                // 注意这个地方一定要new一个新的，因为如果直接传stack是把引用传过去了，最终引用的结果会变成全空
                list_77.Add(new List<int>(stack));
                return;
            }
            for (var i = start; i <= n; i++) {
                stack.Push(i);
                BackTrackingCombine(n, k, i + 1, stack);
                stack.Pop();
            }
        }
    }
}