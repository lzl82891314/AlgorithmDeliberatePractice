class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
class Solution:
    def reverseKGroup(self, head: ListNode, k: int) -> ListNode:
        # 需要三个指针记录不同的位置： pre、cur、tail
        dummy = ListNode()
        dummy.next = head
        pre = dummy
        cur = tail = head
        while cur:
            #  先循环判定是否足够k个分组
            count = k
            while count > 0 and tail:
                tail = tail.next
                count -= 1
            if count > 0:
                # 说明不足够分组排序，则直接返回结果
                pre.next = cur
                break
            pre.next = self.reverse(cur, k)
            pre = cur
            cur = tail
        return dummy.next

    def reverse(self, cur: ListNode, k: int) -> ListNode:
        pre: ListNode = None
        while k > 0:
            next = cur.next
            cur.next = pre
            pre = cur
            cur = next
            k -= 1
        return pre