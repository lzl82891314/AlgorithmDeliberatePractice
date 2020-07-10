﻿using common;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace startup {
    class Program {
        static void Main(string[] args) {
            Week01();
            Console.ReadKey();
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
            var ppp = new ListNode("[1,2,3,4,5]");
            foo.ReverseKGroup(ppp, 2).Show();
        }
    }
}
