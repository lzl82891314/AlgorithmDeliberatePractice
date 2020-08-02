using System;

namespace week04 {
    public partial class Solution {
        public int MaxProfit(int[] prices) {
            if (prices == null || prices.Length == 0) return 0;
            var benfit = 0;
            for (var i = 1; i < prices.Length; i++) 
                if (prices[i] > prices[i-1]) 
                    benfit += prices[i] - prices[i-1];
            return benfit;
        }
    }
}