using System;

namespace week09 {
    public partial class Solution {
        public int MinCostClimbingStairs(int[] cost) {
            var dp = new int[cost.Length];
            dp[0] = cost[0]; dp[1] = cost[1];
            for (var i = 2; i < cost.Length; i++) {
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cost[i];
            }
            return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);
        }
    }
}