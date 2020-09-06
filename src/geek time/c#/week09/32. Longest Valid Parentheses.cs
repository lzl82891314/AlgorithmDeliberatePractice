using System;

namespace week09 {
    public partial class Solution {
        public int LongestValidParentheses(string s) {
            int ans = 0;
            if (string.IsNullOrEmpty(s) || s.Length < 2) return ans;
            var dp = new int[s.Length];
            dp[0] = 0; dp[1] = s[0] == '(' && s[1] == ')' ? 2 : 0;
            if (dp[1] == 2) ans = 2;
            for (var i = 2; i < s.Length; i++) {
                if (s[i] == '(') continue;
                if (s[i - 1] == '(')
                    dp[i] = dp[i - 2] + 2;
                else if (i - dp[i - 1] - 1 >= 0 && s[i - dp[i - 1] - 1] == '(')
                    dp[i] = dp[i - 1] + 2 + (i - dp[i - 1] - 2 >= 0 ? dp[i - dp[i - 1] - 2] : 0);
                ans = Math.Max(ans, dp[i]);
            }
            return ans;
        }
    }
}