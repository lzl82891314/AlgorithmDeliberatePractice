using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
            // 学习到的解法：递归，简洁明了
            if (l1 == null) {
                return l2;
            }
            if (l2 == null) {
                return l1;
            }

            if (l1.val <= l2.val) {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            } else {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }

        public ListNode MergeTwoLists_Self2(ListNode l1, ListNode l2) {
            // 自实现第二版：以一个开始node为基准，双指针切换merge
            if (l1 == null) {
                return l2;
            }
            if (l2 == null) {
                return l1;
            }
            ListNode cur, p;
            if (l1.val <= l2.val) {
                cur = l1;
                p = l2;
            } else {
                cur = l2;
                p = l1;
            }
            var head = new ListNode {
                next = cur
            };
            while (cur.next != null && p != null) {
                if (cur.next.val <= p.val) {
                    cur = cur.next;
                    continue;
                }
                var next = cur.next;
                cur.next = p;
                p = next;
            }
            if (p != null) {
                cur.next = p;
            }
            return head.next;
        }

        public ListNode MergeTwoLists_Self1(ListNode l1, ListNode l2) {
            // 自实现第一版：创建新Node逐一添加p1 和 p2的 current
            var p1 = l1;
            var p2 = l2;
            var root = new ListNode();
            var cur = new ListNode();
            root.next = cur;
            while (p1 != null && p2 != null) {
                if (p1.val < p2.val) {
                    cur.next = p1;
                    p1 = p1.next;
                } else {
                    cur.next = p2;
                    p2 = p2.next;
                }
                cur = cur.next;
            }
            if (p1 != null) {
                cur.next = p1;
            }
            if (p2 != null) {
                cur.next = p2;
            }
            return root.next.next;
        }
    }
}
