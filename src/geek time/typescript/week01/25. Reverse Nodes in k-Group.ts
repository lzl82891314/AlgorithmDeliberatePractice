export class ListNode {
    val: number;
    next: ListNode | null;
    constructor(val?: number, next?: ListNode | null) {
        this.next = next === undefined ? null : next;
    }
}

function reverseKGroup(head: ListNode | null, k: number): ListNode | null {
    if (!head || !head.next) {
        return head;
    }

    let dummy: any = new ListNode();
    dummy.next = head;
    let pre: any = dummy;
    let cur: any = head;
    let tail: any = head;
    while (cur) {
        let count: number = k;
        while (count-- && tail) {
            tail = tail.next;
        }
        if (!tail && count !== -1) {
            pre.next = cur;
            break;
        }
        pre.next = reverse(cur, k);
        pre = cur;
        cur = tail;
    }
    return dummy.next;
}

function reverse(cur: ListNode, k: number): ListNode {
    let pre: any = null;
    while (k--) {
        let next: any = cur.next;
        cur.next = pre;
        pre = cur;
        cur = next;
    }
    return pre;
}
