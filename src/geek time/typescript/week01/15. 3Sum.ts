export function threeSum(nums: number[]): number[][] {
    // 要点： 1. 排序; 2. 双指针 3. 自排重
    // *** ts默认排序中会把[-4, -2, 6] 排序成 [-2, -4, 6]，因此此处需要加入comparator
    nums = nums.sort((a, b) => a - b);
    const result = [];
    for (let k = 0; k < nums.length - 2; k++) {
        if (nums[k] > 0) {
            break;
        }
        // 对k自排重
        if (k !== 0 && nums[k] === nums[k - 1]) {
            continue;
        }
        let i = k + 1;
        let j = nums.length - 1;
        while (i < j) {
            let sum = nums[i] + nums[j] + nums[k];
            if (sum < 0) {
                while (i < j && nums[i] === nums[++i]);
            } else if (sum > 0) {
                while (i < j && nums[j] === nums[--j]);
            } else {
                result.push([nums[k], nums[i], nums[j]]);
                while (i < j && nums[i] === nums[++i]);
                while (i < j && nums[j] === nums[--j]);
            }
        }
    }
    return result;
}

const result = threeSum([-1, 0, 1, 2, -1, -4]);
console.log(result);
