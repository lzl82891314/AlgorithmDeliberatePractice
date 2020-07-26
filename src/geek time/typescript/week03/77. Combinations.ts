export function combine(n: number, k: number): number[][] {
    if (!n || !k || n < k) return [];
    var ans: number[][] = [];
    recursiveCombine(n, k, ans, [], 1);
    return ans;
}

function recursiveCombine(n: number, k: number, ans: number[][], list: number[], start: number) {
    if (list.length === k) {
        ans.push(list.slice(0));
        return;
    }
    for (let i = start; i <= n; i++) {
        list.push(i);
        recursiveCombine(n, k, ans, list, i + 1);
        list.pop();
    }
}
