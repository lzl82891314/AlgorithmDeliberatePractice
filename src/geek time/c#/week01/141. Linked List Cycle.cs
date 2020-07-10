using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public bool HasCycle(ListNode head) {
            // 经典老题，快慢指针
            if (head == null) {
                return false;
            }
            var slow = head;
            var fast = slow.next;
            while (fast != null && fast.next != null) {
                if (fast.val == slow.val) {
                    return true;
                }
                fast = fast.next.next;
                slow = slow.next;
            }
            return false;
        }
    }
}
