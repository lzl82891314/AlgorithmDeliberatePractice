using System;
using System.Collections.Generic;
using System.Text;

namespace week06 {
    public partial class Solution {
        public int Rob_II(int[] nums) {
            if (nums.Length <= 1) return nums.Length == 1 ? nums[0] : 0;
            var skip1 = 0; var rob1 = nums[0];
            var skip2 = 0; var rob2 = nums[1];
            var count = nums.Length - 2; var i = 1; var j = 2;
            while (count-- > 0) {
                var temp1 = rob1;
                rob1 = nums[i++] + skip1;
                skip1 = Math.Max(temp1, skip1);

                var temp2 = rob2;
                rob2 = nums[j++] + skip2;
                skip2 = Math.Max(temp2, skip2);
            }
            return Math.Max(Math.Max(rob1, skip1), Math.Max(rob2, skip2));
        }
    }
}
