export class ListNode {
    val: number;
    next: ListNode | null;
    constructor(val?: number, next?: ListNode | null) {
        this.next = next === undefined ? null : next;
    }
}

function swapPairs(head: ListNode | null): ListNode | null {
    if (!head || !head.next) {
        return head;
    }
    const dummy = new ListNode();
    dummy.next = head;
    let pre = dummy;
    while (head && head.next) {
        let next: any = head.next.next;
        pre.next = head.next;
        head.next.next = head;
        head.next = next;
        pre = head;
        head = next;
    }
    return dummy.next;
}
