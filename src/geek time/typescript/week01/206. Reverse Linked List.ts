export class ListNode {
    val: number;
    next: ListNode | null;
    constructor(val?: number, next?: ListNode | null) {
        this.next = next === undefined ? null : next;
    }
}

function reverseList(head: ListNode | null): ListNode | null {
    if (!head || !head.next) {
        return head;
    }

    let pre: ListNode = null;
    while (head) {
        const next = head.next;
        head.next = pre;
        pre = head;
        head = head.next;
    }
    return pre;
}
