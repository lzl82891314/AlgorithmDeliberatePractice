using System;
using System.Collections.Generic;
using System.Text;

namespace week08 {
    public partial class Solution {
        public int FindLength(int[] A, int[] B) {
            var dp = new int[A.Length, B.Length];
            dp[0, 0] = A[0] == B[0] ? 1 : 0;
            for (var i = 1; i < A.Length; i++) {
                dp[i, 0] = A[i] == B[0] ? 1 : dp[i - 1, 0];
            }
            for (var j = 1; j < B.Length; j++) {
                dp[0, j] = A[0] == B[j] ? 1 : dp[0, j - 1];
            }
            for (var i = 1; i < A.Length; i++) {
                for (var j = 1; j < B.Length; j++) {
                    if (A[i] == B[j] && A[i - 1] == B[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            return dp[A.Length - 1, B.Length - 1];
        }
    }
}
