using System;

namespace week03 {
    public partial class Solution {
        public TreeNode InvertTree(TreeNode root) {
            if (root == null) return root;
            var tree = new TreeNode();
            tree.val = root.val;
            tree.left = InvertTree(root.right);
            tree.right = InvertTree(root.left);
            return tree;
        }
    }
}