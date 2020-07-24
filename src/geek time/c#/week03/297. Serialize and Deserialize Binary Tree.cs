using System;
using System.Linq;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        private IDictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
        public string Serialize(TreeNode root) {
            if (root == null) return "[]";
            RecursiveSerialize(root, 1);
            var list = new List<string>();
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
            RecursiveSerialize(root.left, level + 1);
            RecursiveSerialize(root.right, level + 1);
        }

        private void DictAdd(int level, int? value) {
            var showValue = value == null ? "null" : value.Value.ToString();
            if (dict.ContainsKey(level)) {
                dict[level].Add(showValue);
            } else {
                dict.Add(level, new List<string>(){ showValue });
            }
        }
    }
}