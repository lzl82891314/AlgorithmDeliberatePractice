using System;

namespace week04 {
    public partial class Solution {
        public bool LemonadeChange(int[] bills) {
            if (bills == null || bills.Length == 0) return false;
            var five = 0;
            var ten = 0;
            foreach(var bill in bills) {
                if (bill == 5) {
                    five++;
                    continue;
                } else if (bill == 10 && five > 0) {
                    five--;
                    ten++;
                    continue;
                } else if (bill == 20) {
                    if (ten > 0 && five > 0) {
                        ten--;
                        five--;
                        continue;
                    } else if (five >= 3) {
                        five -= 3;
                        continue;
                    }
                }
                return false;
            }
            return true;
        }
    }
}