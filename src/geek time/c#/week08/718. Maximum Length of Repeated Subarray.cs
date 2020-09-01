using System;
using System.Collections.Generic;
using System.Text;

namespace week08 {
    public partial class Solution {
        public int FindLength(int[] A, int[] B) {
            var dp = new int[A.Length, B.Length];
            for (var i = 0; i < A.Length; i++) {
                dp[i, 0] = A[i] == B[0] ? 1 : 0;
            }
            for (var j = 1; j < B.Length; j++) {
                dp[0, j] = A[0] == B[j] ? 1 : 0;
            }
            var ans = 0;
            for (var i = 1; i < A.Length; i++) {
                for (var j = 1; j < B.Length; j++) {
                    dp[i, j] = A[i] == B[j] ? dp[i - 1, j - 1] + 1 : 0;
                    ans = Math.Max(ans, dp[i, j]);
                }
            }
            return ans;
        }
    }
}
