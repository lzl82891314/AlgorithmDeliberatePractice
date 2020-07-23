using System;

namespace week03 {
    public partial class Solution {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            // 自己做的时候一直想不到怎么同时拥有孩子和父亲节点的判定场景
            // 解法代码中给出了答案，当左右都存在时，说明第一个祖先就是自己
            if (root == null || root == p || root == q) {
                return root;
            }
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p ,q);
            return left != null && right != null ? root : left == null ? right : left;
        }
    }
}