using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head.next == null) return head;
            var dummy = new ListNode
            {
                next = head
            };
            var cur = dummy;
            while (cur.next != null && cur.next.next != null)
            {
                if (cur.next.val == cur.next.next.val)
                {
                    var val = cur.next.val;
                    while (cur.next != null && cur.next.val == val)
                    {
                        cur.next = cur.next.next;
                    }
                }
                else
                {
                    cur = cur.next;
                }
            }
            return dummy.next;
        }
    }
}
