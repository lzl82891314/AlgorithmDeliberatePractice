using System;

namespace week09 {
    public partial class Solution {
        public int MinDistance(string word1, string word2) {
            // 思路：这个问题代码十分简单，但是能想到对应思路很难
            // 解法使用dp，其中dp定义为dp[i, j]表示，word1从0..i的子串与word2从0..j的子串的最短编辑距离
            // 即，解法也是升维并且计算子串
            // 状态转移方程为：
            // 1. 如果word1[i] == word2[j]，说明两个子串的最后一位相等不需要转换，因此直接赋值为dp[i - 1, j - 1]即可（注意，不用+1因为不用转换）
            // 2. 如果不等，则需要从word1编辑一次, word2编辑一次, word1和word2同时编辑一次的结果中取最小值，即Min(dp[i - 1, j], dp[i, j - 1], dp[i - 1, j - 1]) + 1
            // 此外注意dp定义有一个技巧，长度需要加1，因为需要考虑到空字符串的情况，因此字符串的第一个子串为空串
            // 即如果 word1 == 'abc'，那么dp[i]的范围就是[#, a, b, c]
            var dp = new int[word1.Length + 1, word2.Length + 1];
            for (var i = 1; i <= word1.Length; i++)
                // 从Word1的子串到空串的编辑距离即为子串的长度
                dp[i, 0] = i;
            for (var j = 1; j <= word2.Length; j++)
                // 同理可得
                dp[0, j] = j;
            for (var i = 1; i <= word1.Length; i++) {
                for (var j = 1; j <= word2.Length; j++) {
                    // 由于最开始添加了空串，因此此处计算子串的时候需要减1
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1])) + 1;
                }
            }
            return dp[word1.Length, word2.Length];
        }
    }
}