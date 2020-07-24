using System;
using System.Collections.Generic;
using System.Text;

namespace week03 {
    public partial class Solution {
        public int[] RunningSum(int[] nums) {
            var pre = 0;
            var result = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++) {
                pre += nums[i];
                result[i] = pre;
            }
            return result;
        }
    }
}
