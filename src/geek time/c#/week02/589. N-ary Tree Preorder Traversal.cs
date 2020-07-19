using System;
using System.Collections.Generic;

namespace week02 {
    public partial class Solution {
        public class Node {
            public int val;
            public IList<Node> children;

            public Node() {}

            public Node(int _val) {
                val = _val;
            }

            public Node(int _val,IList<Node> _children) {
                val = _val;
                children = _children;
            }
        }    
        public IList<int> Preorder(Node root) {
            var list = new List<int>();
            if (root == null) {
                return list;
            }
            return Recursive(root, list);
        }

        private IList<int> Recursive(Node root, IList<int> list) {
            if (root == null) {
                return list;
            }
            list.Add(root.val);
            if (root.children == null || root.children.Count == 0) {
                return list;
            }
            foreach(var item in root.children) {
                list = Recursive(item, list);
            }
            return list;
        }
    }
}