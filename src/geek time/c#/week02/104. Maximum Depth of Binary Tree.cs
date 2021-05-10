using common;
using System;

namespace week02 {
    public partial class Solution {
        public int MaxDepth(TreeNode root) {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return 1;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
    }
}
