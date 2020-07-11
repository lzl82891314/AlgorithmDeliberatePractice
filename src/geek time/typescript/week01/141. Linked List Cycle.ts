var hasCycle = function (head) {
    if (!head || !head.next) {
        return false;
    }
    var slow = head;
    var fast = slow.next;
    while (fast && fast.next) {
        slow = slow.next;
        fast = fast.next.next;
        if (slow === fast) {
            return true;
        }
    }
    return false;
};
