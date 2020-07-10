using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public ListNode ReverseKGroup(ListNode head, int k) {
            if (head == null || head.next == null) {
                return head;
            }
            ListNode root = new ListNode();
            ListNode pre = new ListNode();
            root.next = pre;
            while (IsEnough(head, k, out var tail)) {
                pre.next = Reverse(GetNode(head, k), tail);
                pre = tail;
                head = pre.next;
            }
            return root.next.next;
        }

        private bool IsEnough(ListNode p, int k, out ListNode pp) {
            while (k-- > 0 && p != null) {
                p = p.next;
            }
            pp = p;
            return k == -1 && p != null;
        }

        private ListNode GetNode(ListNode p, int k) {
            var start = new ListNode();
            start.next = p;
            while (--k > 0) {
                p = p.next;
            }
            p.next = null;
            return start.next;
        }

        private ListNode Reverse(ListNode p, ListNode end) {
            ListNode pre = end;
            while (p != null) {
                var n = p.next;
                p.next = pre;
                pre = p;
                p = n;
            }
            return pre;
        }
    }
}
