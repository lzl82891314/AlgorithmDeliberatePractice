namespace week04 {
    public partial class Solution {
        public int Search(int[] nums, int target) {
            // 此题其实就是一直在计算边界问题，通过对cur 和 target的位置关系分别计算left 和 right
            if (nums == null || nums.Length == 0) return -1;
            var left = 0; var right = nums.Length - 1;
            var leftValue = nums[left]; var rightValue = nums[right];
            while (left <= right) {
                var mid = left + (right - left) / 2;
                var cur = nums[mid];
                if (cur == target) return mid;
                if (cur < leftValue) {
                    if (cur < target && target <= rightValue) {
                        left = mid + 1;
                    } else {
                        right = mid - 1;
                    }
                } else {
                    if (cur > target && target >= leftValue) {
                        right = mid - 1;
                    } else {
                        left = mid + 1;
                    }
                }
            }
            return -1;
        }
    }
}