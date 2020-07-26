export function permute(nums: number[]): number[][] {
    if (!nums || nums.length === 0) return [];
    var ans: number[][] = [];
    var hashMap: Map<number, number> = new Map();
    recursivePermute(nums, ans, [], hashMap);
    return ans;
}

function recursivePermute(nums: number[], ans: number[][], list: number[], hashMap: Map<number, number>) {
    if (list.length === nums.length) {
        ans.push(list.slice(0));
        return;
    }
    for (let i = 0; i < nums.length; i++) {
        if (hashMap.has(i)) continue;
        hashMap.set(i, nums[i]);
        list.push(nums[i]);
        recursivePermute(nums, ans, list, hashMap);
        hashMap.delete(i);
        list.pop();
    }
}
