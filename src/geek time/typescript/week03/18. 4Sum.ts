function fourSum(nums: number[], target: number): number[][] {
    if (!nums || nums.length < 4) return [];
    const result = [];
    nums = nums.sort((a, b) => a - b);
    for (let i = 0; i < nums.length - 3; i++) {
        if (i > 0 && nums[i] === nums[i - 1]) continue;
        for (let j = i + 1; j < nums.length - 2; j++) {
            if (j > i + 1 && nums[j] === nums[j - 1]) continue;
            let a = j + 1;
            let b = nums.length - 1;
            while (a < b) {
                const sum = nums[i] + nums[j] + nums[a] + nums[b];
                if (sum < target) {
                    while (a < b && nums[a++] === nums[a]);
                } else if (sum > target) {
                    while (a < b && nums[b--] === nums[b]);
                } else {
                    result.push([nums[i], nums[j], nums[a], nums[b]]);
                    while (a < b && nums[a++] === nums[a]);
                    while (a < b && nums[b--] === nums[b]);
                }
            }
        }
    }
    return result;
}
