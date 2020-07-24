using System;
using System.Linq;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        private IDictionary<int, List<int?>> dict = new Dictionary<int, List<int?>>();
        public string Serialize(TreeNode root) {
            if (root == null) return "[]";
            RecursiveSerialize(root, 1);
            var list = new List<int?>();
            foreach(var item in dict) {
                list.AddRange(item.Value);
            }
            return $"[{string.Join(',', list)}]";
        }

        public TreeNode Deserialize(string data) {
            return null;
        }

        private void RecursiveSerialize(TreeNode root, int level) {
            if (root == null) {
                DictAdd(level, null);
                return;
            }
            DictAdd(level, root.val);
            if (root.left == null && root.right == null) {
                return;
            }
            RecursiveSerialize(root.left, level + 1);
            RecursiveSerialize(root.right, level + 1);
        }

        private void DictAdd(int level, int? value) {
            if (dict.ContainsKey(level)) {
                dict[level].Add(value);
            } else {
                dict.Add(level, new List<int?>(){ value });
            }
        }
    }
}