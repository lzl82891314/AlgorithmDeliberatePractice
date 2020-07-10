using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public ListNode ReverseList(ListNode head) {
            if (head == null || head.next == null) {
                return head;
            }
            var cur = head;
            ListNode pre = null;
            while (cur != null) {
                var next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }
    }
}
