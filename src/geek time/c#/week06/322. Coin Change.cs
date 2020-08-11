using System;
using System.Collections.Generic;
using System.Text;

namespace week06 {
    public partial class Solution {
        public int CoinChange(int[] coins, int amount) {
            var dp = new int[amount + 1];
            Array.Fill(dp, amount + 1, 1, dp.Length - 1);
            for (var i = 1; i <= amount; i++)
                for (var j = 0; j < coins.Length; j++)
                    if (coins[j] <= i)
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}
