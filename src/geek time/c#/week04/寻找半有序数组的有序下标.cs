using System;

namespace week04 {
    public partial class Solution {
        public int FindIndex(int[] nums) {
            if (nums == null || nums.Length == 0) return 0;
            // nums = [3, 4, 5, 1, 2]
            var left = 0; var right = nums.Length - 1;
            var leftValue = nums[left]; var rightValue = nums[right];
            while (left <= right) {
                var mid = left + (right - left) / 2;
                var cur = nums[mid];
                if (cur < nums[mid-1] && cur < nums[mid+1]) return mid;
                if (cur > leftValue) {
                    // 说明当前值在左侧部分，需要移动left为mid
                    left = mid + 1;
                } else {
                    // 说明当前值在右侧部分，需要移动right为mid
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}