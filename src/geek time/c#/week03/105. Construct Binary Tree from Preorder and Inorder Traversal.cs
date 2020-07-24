using System;
using System.Linq;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        private IDictionary<int, int> dict_105 = new Dictionary<int, int>();
        public TreeNode BuildTree(int[] preorder, int[] inorder) {
            // 解法：
            // 先序遍历的结果可以看做是： [ [root] [...left children tree...] [...right children tree...] ] 三部分
            // 中序遍历的结果可以看做是： [ [...left children tree...] [root] [...right children tree...] ] 三部分
            
            // 从上面的数组中可以得到如下结论：
            // preorder[p_preorder_start] == root
            // p_preorder_start + 1 == preorder_left_children_tree_start
            // preorder_left_children_tree.Length == p_inorder_root - p_inorder_start  <---  p_inorder_root 需要遍历求出
            // p_preorder_start + preorder_left_children_tree.Length = preorder_left_children_tree_end
            // preorder_left_children_tree_end + 1 == p_preorder_right_children_tree_start
            // p_inorder_root + 1 == inorder_right_children_tree_start

            // 有了上述的各个坐标，就可以通过递归来分别构建不同子树了

            // 首选需要加载中序遍历到Map中加速
            for (var i = 0; i < inorder.Length; i++) {
                dict_105.Add(inorder[i], i);
            }
            return RecursiveBuildingTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        private TreeNode RecursiveBuildingTree(int[] preorder, int p_preorder_start, int p_preorder_end, int[] inorder, int p_inorder_start, int p_inorder_end) {
            // 终止条件
            if (p_preorder_start > p_preorder_end) {
                return null;
            }
            // 构建根节点
            var rootValue = preorder[p_preorder_start];
            var tree = new TreeNode(rootValue);
            var leftChildrenTreeLength = dict_105[rootValue] - p_inorder_start;
            tree.left = RecursiveBuildingTree(preorder, p_preorder_start + 1, p_preorder_start + leftChildrenTreeLength, inorder, p_inorder_start, dict_105[rootValue] - 1);
            tree.right = RecursiveBuildingTree(preorder, p_preorder_start + leftChildrenTreeLength + 1, p_preorder_end, inorder, dict_105[rootValue] + 1, p_inorder_end);
            return tree;
        }
    }
}