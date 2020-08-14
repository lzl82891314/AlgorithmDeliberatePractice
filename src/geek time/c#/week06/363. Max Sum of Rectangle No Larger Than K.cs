using System;
using System.Collections.Generic;
using System.Text;

namespace week06 {
    public partial class Solution {
        public int MaxSumSubmatrix(int[][] matrix, int k) {
            // 思路：暴力循环
            // 1. 根据前序和的逻辑，分别以列为单位计算前序和
            // 2. 为了遍历所有情况，需要加入bounder边界来保证左边界移动
            // 3. 最后计算逻辑也相同，分别对每次的和数组进行带边界的判定，最终获得结果
            var ans = int.MinValue;
            var dp = new int[matrix.Length, matrix[0].Length];
            for (var bounder = 0; bounder < matrix[0].Length - 1; bounder++) {
                for (var column = bounder; column < matrix[0].Length; column++) {
                    for (var row = 0; row < matrix.Length; row++) {
                        if (matrix[row][column] == k) return k;
                        if (matrix[row][column] > ans && matrix[row][column] < k) ans = matrix[row][column];
                        if (column == bounder) dp[row, column] = matrix[row][column];
                        else dp[row, column] = dp[row, column - 1] + matrix[row][column];
                    }
                    // 第一遍加速判定
                    var sum = dp[0, column]; var positiveSum = sum;
                    for (var i = 1; i < matrix.Length; i++) {
                        positiveSum = positiveSum <= 0 ? dp[i, column] : positiveSum + dp[i, column];
                        sum = Math.Max(sum, positiveSum);
                    }
                    // 如果所有正数的和最终的结果都小于k，那其余的多重循环就不用继续做了，直接可以返回这次结果
                    if (sum <= k && sum > ans) {
                        ans = sum;
                        continue;
                    }
                    // 否则再继续第二次判定
                    for (var i = 0; i < matrix.Length; i++) {
                        var pre = dp[i, column];
                        for (var j = i + 1; j < matrix.Length; j++) {
                            if (pre <= k && pre > ans) ans = pre;
                            if (dp[j, column] <= k && dp[j, column] > ans) ans = dp[j, column];
                            pre += dp[j, column];
                        }
                        if (pre <= k && pre > ans) ans = pre;
                    }
                }
            }
            return ans;
        }
    }
}
