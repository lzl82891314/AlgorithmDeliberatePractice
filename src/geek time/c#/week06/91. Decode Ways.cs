using System;
using System.Collections.Generic;

namespace week06 {
    public partial class Solution {
        public int NumDecodings(string s) {
            // 此题的递推逻辑是：
            // dp[i] 表示第i位一共有多少种解法
            // 因此， dp[i] = dp[i - 1] + cur
            // 其中cur的计算还会分为几种情况：
            // 当s[i] == '0'时，说明当前的数不能单独组成一个解码结果，需要和前一个合并计算并且加上之前的结果
            // 并且此时有一个隐藏条件：当i-1和i合并计算时，i-1就不能单独计算解码结果了
            // 当s[i] != '0'时，说明其可以单独解码，其结果就是之前的结果+两者合并计算的结果

            if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;
            var dp = new int[s.Length]; dp[0] = 1;
            for (var i = 1; i < s.Length; i++) {
                dp[i] = s[i] == '0' ? 0 : dp[i - 1];
                var num = (s[i - 1] - '0') * 10 + (s[i] - '0');
                if (num >= 10 && num <= 26) dp[i] += i == 1 ? 1 : dp[i - 2];
            }
            return dp[s.Length - 1];
        }
    }
}