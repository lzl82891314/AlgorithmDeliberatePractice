using System;
using System.Collections.Generic;
using System.Text;

namespace week06 {
    public partial class Solution {
        public bool IsMatch(string s, string p) {
            var list = new List<string>();
            for (var i = 0; i < p.Length; i++) {
                var cur = p[i].ToString();
                if (i != p.Length - 1 && p[i + 1] == '*') cur += p[i++ + 1].ToString();
                list.Add(cur);
            }
            var dp = new bool[list.Count, s.Length];
            dp[0, 0] = p[0] == s[0] || p[0] == '.';
            int starCount = list[0].Length > 1 ? 1 : 0;
            for (var i = 1; i < list.Count; i++) {
                char cur;
                if (list[i].Length > 1) cur = list[i][0];
                else cur = char.Parse(list[i]);
                if (list[i].Length == 1) dp[i, 0] = dp[i - 1, 0] && i <= starCount && (cur == s[0] || cur == '.');
                else {
                    dp[i, 0] = dp[i - 1, 0] || (cur == s[0] && starCount == i);
                    starCount++;
                }
            }
            for (var j = 1; j < s.Length; j++) {
                if (list[0].Length > 1) dp[0, j] = dp[0, j - 1] && (list[0][0] == s[j] || list[0][0] == '.');
            }
            starCount = 0;
            for (var i = 1; i < list.Count; i++) {
                char cur;
                if (list[i].Length > 1) cur = list[i][0];
                else cur = char.Parse(list[i]);
                for (var j = 1; j < s.Length; j++) {
                    if (list[i].Length > 1) dp[i, j] = dp[i - 1, j] || (cur == s[j] && i <= starCount);
                    else dp[i, j] = dp[i - 1, j - 1] && (cur == s[j] || cur == '.');
                }
                if (list[i].Length > 1) starCount++;
            }
            return dp[list.Count - 1, s.Length - 1];
        }
    }
}
