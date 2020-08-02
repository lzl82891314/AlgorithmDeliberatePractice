using System;

namespace week04 {
    public partial class Solution {
        public int Jump(int[] nums) {
            var maxPosition = 0; var end = 0; var ans = 0;
            // 注意这个边界问题，最后一步不用跳，因此for循环边界为length - 1
            // 解法精妙之处在于原本两个嵌套的循环，通过很好的处理优化成了一个循环
            for (var i = 0; i < nums.Length - 1; i++) {
                maxPosition = Math.Max(maxPosition, nums[i] + i);
                if (i == end) {
                    end = maxPosition;
                    ans++;
                }
            }
            return ans;
        }
    }
}