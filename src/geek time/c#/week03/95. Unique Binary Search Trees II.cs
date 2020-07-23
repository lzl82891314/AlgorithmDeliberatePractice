using System;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        private IList<TreeNode> list = new List<TreeNode>();
        public IList<TreeNode> GenerateTrees(int n) {
            if (n == 0) {
                return new List<TreeNode>();
            }

            for (var i = 1; i <= n; i++) {
                list.Add(GenerateTree(i, n));
            }

            return list;
        }

        private TreeNode GenerateTree(int root, int end) {
            return null;
        }
    }
}