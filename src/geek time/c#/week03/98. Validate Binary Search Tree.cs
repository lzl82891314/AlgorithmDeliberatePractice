using common;
using System.Collections.Generic;
using System.Linq;

namespace week03
{
    public partial class Solution {
        private IList<int?> list_98 = new List<int?>();
        public bool IsValidBST(TreeNode root) {
            if (root == null) return true;
            Recursion(root);
            int? start = list_98[0];
            for (var i = 1; i < list_98.Count(); i++) {
                if (list_98[i] == null) {
                    start = list_98[i];
                    continue;
                }
                if (start == null) return false;
                if (list_98[i] <= start) return false;
                start = list_98[i];
            }
            return true;
        }

        private void Recursion(TreeNode root) {
            if (root == null) return;
            Recursion(root.left);
            list_98.Add(root.val);
            Recursion(root.right);
        }
    }
}