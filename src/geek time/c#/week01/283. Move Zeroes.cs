using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public void MoveZeroes(int[] nums) {
            // 解法：交换，创建指针永远指向第一个需要交换的位置，即刚开始就是0
            var j = 0;
            for (var i = 0; i < nums.Length; i++) {
                if (nums[i] != 0) {
                    nums[j++] = nums[i];
                }
            }
            while (j < nums.Length) {
                nums[j++] = 0;
            }
        }
    }
}
