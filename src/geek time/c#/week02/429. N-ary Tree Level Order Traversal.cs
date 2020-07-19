using System;
using System.Collections.Generic;

namespace week02 {
    public class Node {
        public int val;
        public IList<Node> children;
        public Node() {}
        public Node(int _val) {
            val = _val;
        }
        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }

    public partial class Solution {
        private Dictionary<int, IList<int>> dict = new Dictionary<int, IList<int>>();
        public IList<IList<int>> LevelOrder(Node root) {
            var list = new List<IList<int>>();
            if (root == null) {
                return list;
            }
            RecursiveByDepth(root, 0);
            foreach(var item in dict) {
                list.Add(item.Value);
            }
            return list;
        }

        private void RecursiveByDepth(Node root, int depth) {
            if (root == null) {
                return;
            }
            if (dict.ContainsKey(depth)) {
                dict[depth].Add(root.val);
            } else {
                dict[depth] = new List<int>(){root.val};
            }
            foreach(var item in root.children) {
                RecursiveByDepth(item, depth+1);
            }
        }
    }
}