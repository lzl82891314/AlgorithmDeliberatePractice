class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
    
class Solution:
    def swapPairs(self, head: ListNode) -> ListNode:
        if head is None or head.next is None:
            return head
        dummy = ListNode()
        pre = ListNode()
        dummy.next = pre
        cur = head
        while cur and cur.next:
            next = cur.next.next
            pre.next = cur.next
            cur.next.next = cur
            cur.next = next
            pre = cur
            cur = next
        return dummy.next.next


