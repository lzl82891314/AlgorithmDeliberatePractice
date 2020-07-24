using common;
using System;
using System.Collections;
using static week03.Solution;

namespace startup {
    class Program {
        static void Main(string[] args) {
            // Week01();
            // Week02();
            Week03();
        }

        static void Week01() {
            var foo = new week01.Solution();

            // 15. 3Sum
            foo.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 }).Show();

            // 70. Climbing Stairs
            foo.ClimbingStairs(10).Show();

            // 24. Swap Nodes in Pairs
            var node = new ListNode("[1,2,3,4]");
            node.Show();
            foo.SwapPairs(node).Show();

            // 66. Plus One
            var pre = new int[] { 9, 9, 9, 9 };
            pre.Show<int>();
            foo.PlusOne(pre).Show<int>();

            // 283. Move Zeroes
            var movePre = new int[] { 0, 1, 0, 3, 12 };
            movePre.Show<int>();
            foo.MoveZeroes(movePre);
            movePre.Show<int>();

            // 11. Container With Most Water
            foo.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }).Show();

            // 21. Merge Two Sorted Lists
            var l1 = new ListNode("[1,2,4]");
            var l2 = new ListNode("[1,3,4]");
            l1.Show();
            l2.Show();
            foo.MergeTwoLists(l1, l2).Show();

            // 206. Reverse Linked List
            var p = new ListNode("[1,2,3,4,5]");
            p.Show();
            foo.ReverseList(p).Show();

            // 141. Linked List Cycle
            var pp = new ListNode();
            pp.next = pp;
            foo.HasCycle(pp).Show();

            // 142. Linked List Cycle II
            foo.DetectCycle(pp);

            // 25. Reverse Nodes in k-Group
            var ppp = new ListNode("[1,2]");
            foo.ReverseKGroup(ppp, 2).Show();

            // 315. Count of Smaller Numbers After Self
            var arr = new int[] { 5, 2, 6, 1 };
            foo.CountSmaller(arr).Show();

            // 941. Valid Mountain Array
            foo.ValidMountainArray(new int[] { 0, 3, 2, 1 }).Show();

            // 299. Bulls and Cows
            foo.GetHint("1123", "0111").Show();
        }

        static void Week02() {
            var foo = new week02.Solution();
            // 239. Sliding Window Maximum
            // foo.MaxSlidingWindow(new int[] { 1, -1 }, 1).Show<int>();

            // 49. Group Anagrams
            foo.GroupAnagrams(new string[]{ "eat","tea","tan","ate","nat","bat" });
        }

        static void Week03() {
            var foo = new week03.Solution();

            // 98. Validate Binary Search Tree
            var tree = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            foo.IsValidBST(tree).Show();

            // 111. Minimum Depth of Binary Tree
            var tree_111 = new TreeNode(1, new TreeNode(2));
            foo.MinDepth(tree_111).Show();

            // 18. 4Sum
            foo.FourSum(new int[]{1, 0, -1, 0, -2, 2}, 0);
        }
    }
}