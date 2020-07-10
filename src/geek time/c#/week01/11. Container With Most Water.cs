using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public int MaxArea(int[] height) {
            // 解法：两端夹逼，当且仅当minHeight被选中的那端进行移动操作
            var i = 0;
            var j = height.Length - 1;
            var max = 0;
            while (i < j) {
                var minHeight = height[i] < height[j] ? height[i++] : height[j--];
                max = Math.Max(max, (j - i + 1) * minHeight);
            }
            return max;
        }
    }
}
