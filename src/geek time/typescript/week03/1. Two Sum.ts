export function twoSum(nums: number[], target: number): number[] {
    if (!nums || nums.length === 0) return [];
    const ans: number[] = [];
    const hashMap: Map<number, number> = new Map();
    for (let i = 0; i < nums.length; i++) {
        const current = nums[i];
        if (hashMap.has(target - current)) {
            ans.push(hashMap.get(target - current));
            ans.push(i);
            break;
        }
        hashMap.set(current, i);
    }
    return ans;
}
