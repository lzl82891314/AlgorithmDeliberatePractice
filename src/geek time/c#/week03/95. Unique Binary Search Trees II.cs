using System;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        public IList<TreeNode> GenerateTrees(int n) {
            // 这个题自己实现的时候就存在一个问题，不知道递归应该生成的内容是什么
            // 需要注意：这种生成树的题，递归for循环应该写在递归体内，因为这样才能不断的递归生成树
            if (n == 0) {
                return new List<TreeNode>();
            }
            return RecursiveGenerate(1, n);
        }

        private List<TreeNode> RecursiveGenerate(int start, int end) {
            var list = new List<TreeNode>();
            if (start > end) {
                list.Add(null);
                return list;
            }
            for (var i = start; i <= end; i++) {
                var leftTrees = RecursiveGenerate(start, i - 1);
                var rightTrees = RecursiveGenerate(i + 1, end);
                foreach(var left in leftTrees) {
                    foreach(var right in rightTrees) {
                        var tree = new TreeNode(i);
                        tree.left = left;
                        tree.right = right;
                        list.Add(tree);
                    }
                }
            }
            return list;
        }
    }
}