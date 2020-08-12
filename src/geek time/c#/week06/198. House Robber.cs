using System;
using System.Collections.Generic;
using System.Text;

namespace week06 {
    public partial class Solution {
        public int Rob(int[] nums) {
            if (nums.Length <= 1) return nums.Length == 1 ? nums[0] : 0;
            var f1 = Math.Max(nums[0], nums[1]); var f2 = nums[0];
            for (var i = 2; i < nums.Length; i++) {
                var temp = f1;
                f1 = nums[i] + f2;
                f2 = Math.Max(temp, f2);
            }
            return Math.Max(f1, f2);
        }
    }
}
