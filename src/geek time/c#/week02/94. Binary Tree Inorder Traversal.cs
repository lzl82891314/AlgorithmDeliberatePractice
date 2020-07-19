using System;
using System.Collections.Generic;

namespace week02 {
    public partial class Solution {
        public IList<int> InorderTraversal(TreeNode root) {
            var list = new List<int>();
            if (root == null) {
                return list;
            }
            return InorderRecursive(root, list);
        }

        private IList<int> InorderRecursive(TreeNode root, IList<int> list) {
            if (root == null) {
                return list;
            }
            list = InorderRecursive(root.left, list);
            list.Add(root.val);
            list = InorderRecursive(root.right, list);
            return list;
        }

        public IList<int> InorderTraversal_Iterate(TreeNode root) {
            var list = new List<int>();
            if (root == null) {
                return list;
            }
            var stack = new Stack<TreeNode>();
            var cur = root;
            while (cur != null || stack.Count != 0) {
                while (cur != null) {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                list.Add(cur.val);
                cur = cur.right;
            }
            return list;
        }
    }
}