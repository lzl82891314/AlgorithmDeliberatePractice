export function permuteUnique(nums: number[]): number[][] {
    if (!nums || nums.length === 0) return [];
    const ans = [];
    nums = nums.sort();
    const hashMap = new Map<number, number>();
    recursivePermute(nums, ans, [], hashMap);
    return ans;
}

function recursivePermute(nums: number[], ans: any[], list: any[], hashMap: Map<number, number>) {
    if (list.length === nums.length) {
        ans.push(list.slice(0));
        return;
    }
    for (let i = 0; i < nums.length; i++) {
        if (hashMap.has(i)) continue;
        if (i > 0 && nums[i] === nums[i - 1] && hashMap.has(i - 1)) break;
        list.push(nums[i]);
        hashMap.set(i, nums[i]);
        recursivePermute(nums, ans, list, hashMap);
        list.pop();
        hashMap.delete(i);
    }
}
