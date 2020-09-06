namespace week09 {
    public partial class Solution {
        public int ClimbStairs(int n) {
            // 爬梯子，标准dp解法
            if (n <= 2) return n;
            var dp = new int[n];
            dp[0] = 1; dp[1] = 2;
            for (var i = 2; i < n; i++)
                dp[i] = dp[i - 1] + dp[i - 2];
            return dp[n - 1];
        }
    }
}