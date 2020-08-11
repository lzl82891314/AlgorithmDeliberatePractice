using System;
using System.Collections.Generic;
using System.Text;

namespace week05 {
    public partial class Solution {
        public int LongestCommonSubsequence(string text1, string text2) {
            var ans = 0; var p = 0;
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2)) return ans;
            for (var i = 0; i < text1.Length; i++) {
                if (p > text2.Length) return ans;
                var cur = text1[i];
                for (var j = p; j < text2.Length; j++) {
                    var comparativeCur = text2[j];
                    if (cur.Equals(comparativeCur)) {
                        p = j + 1;
                        ans++;
                        break;
                    }
                }
            }
            return ans;
        }
    }
}
