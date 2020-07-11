using common;
using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public ListNode ReverseKGroup(ListNode head, int k) {
            // 解法：
            // 在反转之前需要三个指针pre、cur、tail
            // 其中pre指向此次反转之前的node，cur为开始node，tail为此次反转的尾node
            // 对于第一次操作没有pre，因此需要创建一个dummy node

            // 算法简单，重点在操作
            if (head == null || head.next == null) {
                return head;
            }

            var dummy = new ListNode();
            dummy.next = head;
            var pre = dummy;
            var cur = head;
            ListNode tail = null;
            while (cur != null) {
                // 首先判断是否可反转
                var count = k;
                tail = cur;
                while (count-- > 0 && tail != null) {
                    tail = tail.next;
                }
                // 排除不够分组的情况
                if (tail == null && count > -1) {
                    // 将后续的不够分组反转的node拼接到已分好组的节点中
                    pre.next = cur;
                    break;
                }

                // 分组反转
                pre.next = Reverse(cur, k);
                // 这里还有一个技巧性的概念：当一组node反转后，其tail最终会变成head，head会变成tail
                // 因此移动pre到上次反转的尾结点即为 pre = cur
                pre = cur;
                // 而同样，在上述的递归找tail的过程中，tail已经赋值为了新一个分组的head，因此移动cur的操作即为 cur = tail
                cur = tail;
            }

            return dummy.next;
        }

        private ListNode Reverse(ListNode p, int k) {
            // 反转逻辑
            // 由于判断过了肯定没有越界问题，因此直接以k分组反转即可
            ListNode pre = null;
            while (k-- > 0) {
                var next = p.next;
                p.next = pre;
                pre = p;
                p = next;
            }
            return pre;
        }
    }
}
