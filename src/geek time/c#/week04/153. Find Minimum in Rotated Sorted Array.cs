using System;
using System.Collections.Generic;
using System.Text;

namespace week04 {
    public partial class Solution {
        public int FindMin(int[] nums) {
            if (nums.Length == 1) return nums[0];
            var left = 0; var right = nums.Length - 1;
            var leftValue = nums[left]; var rightValue = nums[right];
            if (leftValue < rightValue) return leftValue;
            while (left <= right) {
                var mid = left + (right - left) / 2;
                var cur = nums[mid];
                if (cur > nums[mid + 1]) return nums[mid + 1];
                if (cur < nums[mid - 1]) return cur;
                if (cur > leftValue) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}
