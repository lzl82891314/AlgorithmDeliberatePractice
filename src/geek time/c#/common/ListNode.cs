using System;
using System.Collections.Generic;
using System.Text;

namespace common {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }

        public ListNode(string nodes) {
            if (!nodes.StartsWith('[') || !nodes.EndsWith(']')) {
                throw new ArgumentException("传入的链表信息有误");
            }
            var nodeItems = nodes.TrimStart('[').TrimEnd(']').Split(',');
            if (nodeItems == null || nodeItems.Length == 0) {
                throw new ArgumentException("传入的链表数据不能为空");
            }

            ListNode pre = null;
            for (var index = nodeItems.Length - 1; index >= 0; index--) {
                if (!int.TryParse(nodeItems[index], out var value)) {
                    throw new ArgumentException("传入的链表数据类型有误");
                }
                var node = new ListNode(value, pre);
                pre = node;
            }
            this.val = pre.val;
            this.next = pre.next;
        }
    }
}
