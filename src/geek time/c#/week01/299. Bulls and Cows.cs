using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public string GetHint(string secret, string guess) {
            int cows = 0;
            int bulls = 0;
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < secret.Length; i++) {
                if (secret[i] == guess[i]) {
                    cows++;
                }
                if (dict.ContainsKey(secret[i])) {
                    dict[secret[i]] += 1;
                } else {
                    dict[secret[i]] = 1;
                }
            }
            for (var i = 0; i < guess.Length; i++) {
                if (dict.ContainsKey(guess[i]) && dict[guess[i]] > 0) {
                    bulls++;
                    dict[guess[i]] -= 1;
                }
            }
            bulls -= cows;
            bulls = bulls < 0 ? 0 : bulls;
            return $"{cows}A{bulls}B";
        }
    }
}
