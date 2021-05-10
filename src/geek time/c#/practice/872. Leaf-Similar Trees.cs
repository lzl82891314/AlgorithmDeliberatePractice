using common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace practice
{
    public partial class Solution
    {
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var list1 = new List<int>();
            var list2 = new List<int>();
            Inorder(root1, list1);
            Inorder(root2, list2);
            return list1.SequenceEqual(list2);
        }
        private void Inorder(TreeNode root, List<int> list)
        {
            if (root == null) return;
            Inorder(root.left, list);
            if (root.left == null && root.right == null)
            {
                list.Add(root.val);
            }
            Inorder(root.right, list);
        }
    }
}
