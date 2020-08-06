using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week05 {
    public partial class Solution {
        public int MaxSubArray(int[] nums) {
            if (nums == null || nums.Length == 0) return 0;
            var preSum = nums[0]; var max = nums[0];
            for (var i = 1; i < nums.Length; i++) {
                if (preSum < 0) preSum = nums[i];
                else preSum += nums[i];
                if (preSum > max) max = preSum;
            }
            return max;
        }
    }
}
