using System;

namespace week06 {
    public partial class Solution {
        public int CountSubstrings(string s) {
            // 说是动态规划，其实是暴力求解
            var dp = new int[s.Length];
            dp[0] = 1;
            for (var i = 1; i < s.Length; i++) {
                dp[i] = dp[i - 1];
                var level = 0;
                while (i - level >= 0 && i + level < s.Length) {
                    if (s[i - level] == s[i + level++]) dp[i]++;
                    else break;
                }
                level = 0;
                while (i - level - 1 >= 0 && i + level < s.Length) {
                    if (s[i - level - 1] == s[i + level++]) dp[i]++;
                    else break;
                }
            }
            return dp[s.Length - 1];
        }
    }
}