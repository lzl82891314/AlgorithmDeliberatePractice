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

        public int CoinChange_BFS(int[] coins, int amount) {
            if (coins.Length == 0 || amount <= 0) return 0;
            var queue = new Queue<KeyValuePair<int, int>>();
            queue.Enqueue(new KeyValuePair<int, int>(amount, 0));
            var visited = new HashSet<int>();
            visited.Add(amount);
            while (queue.Count > 0) {
                var cur = queue.Dequeue();
                foreach (var coin in coins) {
                    var subtracted = cur.Key - coin;
                    if (subtracted == 0) return cur.Value + 1;
                    if (subtracted > 0 && !visited.Contains(subtracted)) {
                        queue.Enqueue(new KeyValuePair<int, int>(subtracted, cur.Value + 1));
                        visited.Add(subtracted);
                    }
                }
            }
            return -1;
        }
    }
}
