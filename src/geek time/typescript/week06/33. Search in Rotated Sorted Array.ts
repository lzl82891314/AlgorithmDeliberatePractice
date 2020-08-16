function search(nums: number[], target: number): number {
    if (nums.length == 0) return -1;
    let left = 0;
    let right = nums.length - 1;
    const leftValue = nums[0];
    const rightValue = nums[nums.length - 1];
    while (left <= right) {
        let mid = Number.parseInt(`${left + (right - left) / 2}`);
        const cur = nums[mid];
        if (cur === target) return mid;
        if (cur < leftValue) {
            if (target > cur && target <= rightValue) left = mid + 1;
            else right = mid - 1;
        } else {
            if (target < cur && target > rightValue) right = mid - 1;
            else left = mid + 1;
        }
    }
    return -1;
}
