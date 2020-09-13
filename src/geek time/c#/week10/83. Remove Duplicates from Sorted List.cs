using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace week10 {
    public partial class Solution {
        public ListNode DeleteDuplicates(ListNode head) {
            if (head == null || head.next == null) return head;
            var dummy = new ListNode();
            dummy.next = head; var cur = head;
            while (cur != null) {
                var next = cur.next;
                while (next != null && cur.val == next.val) {
                    next = next.next;
                }
                cur.next = next;
                cur = next;
            }
            return dummy.next;
        }
    }
}
