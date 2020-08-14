using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week06 {
    public partial class Solution {
        public int MaxSubArray(int[] nums) {
            if (nums.Length == 0) return 0;
            for (var i = 1; i < nums.Length; i++)
                // 此处nums[i]的最终结果有可能因为整个数组都是负数而导致是负数
                // 所以不应该在此处比较0和nums[i]的大小，而是直接将其赋值为负数
                nums[i] += Math.Max(nums[i - 1], 0);
            return nums.Max();
        }
    }
}
