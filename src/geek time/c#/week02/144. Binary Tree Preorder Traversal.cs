using System;
using System.Collections.Generic;

namespace week02 {
    public partial class Solution {
        private IList<int> list = new List<int>();
        public IList<int> PreorderTraversal(TreeNode root) {
            if (root == null) {
                return list;
            }
            list.Add(root.val);
            list = PreorderTraversal(root.left);
            list = PreorderTraversal(root.right);
            return list;
        }

        public IList<int> PreorderTraversal_Iterate(TreeNode root) {
            var list = new List<int>();
            if (root == null) {
                return list;
            }
            var deque = new LinkedList<TreeNode>();
            var cur = root;
            deque.AddLast(cur);
            while (deque.Count != 0) {
                var node = deque.Last;
                deque.RemoveLast();
                list.Add(node.Value.val);
                if (node.Value.right != null) {
                    deque.AddLast(node.Value.right);
                }
                if (node.Value.left != null) {
                    deque.AddLast(node.Value.left);
                }
            }
            return list;
        }
    }
}