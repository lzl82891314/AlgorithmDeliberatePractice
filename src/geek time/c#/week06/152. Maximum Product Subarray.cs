using System;
using System.Collections.Generic;
using System.Text;

namespace week06 {
    public partial class Solution {
        public int MaxProduct(int[] nums) {
            if (nums.Length == 0) return 0;
            var ans = nums[0];
            var dp = new int[nums.Length, 2];
            dp[0, 0] = nums[0]; dp[0, 1] = nums[0];
            for (var i = 1; i < nums.Length; i++) {
                if (nums[i] >= 0) {
                    dp[i, 0] = Math.Max(dp[i - 1, 0] * nums[i], nums[i]);
                    dp[i, 1] = Math.Min(dp[i - 1, 1] * nums[i], 0);
                } else {
                    dp[i, 0] = Math.Max(dp[i - 1, 1] * nums[i], 0);
                    dp[i, 1] = Math.Min(dp[i - 1, 0] * nums[i], nums[i]);
                }
                ans = Math.Max(dp[i, 0], ans);
            }
            return ans;
        }
    }
}
