using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public ListNode SwapPairs(ListNode head) {
            // 边界判断
            if (head == null || head.next == null) {
                return head;
            }

            var root = new ListNode();
            var pre = new ListNode();
            root.next = pre;
            var cur = head;

            while (cur != null && cur.next != null) {
                var next = cur.next.next;
                pre.next = cur.next;
                cur.next.next = cur;
                cur.next = next;

                pre = cur;
                cur = next;
            }
            return root.next.next;
        }
    }
}
