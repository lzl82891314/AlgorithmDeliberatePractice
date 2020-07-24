using System;
using System.Collections.Generic;
using System.Linq;

namespace week03 {
    public partial class Solution {
        public int MinDepth(TreeNode root) {
            if (root == null) return 0;
            return MinRecursive(root, 1) + 1;
        }

        private int MinRecursive(TreeNode root, int cur) {
            if (root == null) return cur - 1;
            if (root.left == null && root.right == null) return cur - 1;
            var left = int.MaxValue;
            var right = int.MaxValue;
            if (root.left != null)
                left = MinRecursive(root.left, cur + 1);
            if (root.right != null)
                right = MinRecursive(root.right, cur + 1);
            return Math.Min(left, right);
        }
    }
}