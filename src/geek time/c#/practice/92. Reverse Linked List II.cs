using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head.next == null) return head;
            var dummy = new ListNode
            {
                next = head
            };
            var pre = dummy;
            var npre = pre;
            var start = head;
            var index = 1;
            while (true)
            {
                if (index++ < left)
                {
                    pre = head;
                    npre = pre;
                    head = head.next;
                    start = head;
                    continue;
                }
                var next = head.next;
                head.next = npre;
                npre = head;
                head = next;
                if (head == null || index > right)
                {
                    pre.next = npre;
                    start.next = head;
                    break;
                }
            }
            return dummy.next;
        }
    }
}
