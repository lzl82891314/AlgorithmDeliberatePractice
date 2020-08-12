using System;
using System.Collections.Generic;
using System.Text;

namespace week06 {
    public partial class Solution {
        public int LongestCommonSubsequence(string text1, string text2) {
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2)) return 0;
            var dp = new int[text1.Length, text2.Length];
            dp[0, 0] = text1[0] == text2[0] ? 1 : 0;
            for (var i = 1; i < text1.Length; i++)
                dp[i, 0] = Math.Max(dp[i - 1, 0], text1[i] == text2[0] ? 1 : 0);
            for (var j = 1; j < text2.Length; j++)
                dp[0, j] = Math.Max(dp[0, j - 1], text2[j] == text1[0] ? 1 : 0);
            for (var i = 1; i < text1.Length; i++)
                for (var j = 1; j < text2.Length; j++)
                    dp[i, j] = text1[i] == text2[j] ? dp[i - 1, j - 1] + 1 : Math.Max(dp[i - 1, j], dp[i, j - 1]);
            return dp[text1.Length -1, text2.Length - 1];
        }
    }
}
