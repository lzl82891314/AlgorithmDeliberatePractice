function detectCycle(head: ListNode): ListNode {
    if (!head || !head.next) {
        return null;
    }

    var slow = head;
    var fast = head;
    while (fast && fast.next) {
        slow = slow.next;
        fast = fast.next.next;
        if (!fast) {
            return null;
        }
        if (slow === fast) {
            slow = head;
            while (slow != fast) {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }
    }
    return null;
}

var n3 = new ListNode(3, null);
var n2 = new ListNode(2, n3);
var n1 = new ListNode(1, n2);

var s = detectCycle(n1);
console.log(s);
