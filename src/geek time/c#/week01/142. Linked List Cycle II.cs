using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public ListNode DetectCycle(ListNode head) {
            // 学习解法：快慢指针
            // 有一个逻辑概念，当找到这个Node有环时，将slow赋值为head，因为速度2倍的关系，因此相遇的节点即为起始环节点
            if(head == null || head.next == null) {
                return null;
            }
            var fast = head;
            var slow = head;
            while (fast != null && fast.next != null) {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow) {
                    // 刚好过半
                    slow = head;
                    while (fast != slow) {
                        fast = fast.next;
                        slow = slow.next;
                    }
                    return fast;
                }
            }
            return null;
        }

        public ListNode DetectCycle_Self(ListNode head) {
            // 哈希表
            if (head == null) {
                return head;
            }
            HashSet<ListNode> hashSet = new HashSet<ListNode>();
            while (head != null && hashSet.Add(head)) {
                head = head.next;
            }
            return head;
        }
    }
}
