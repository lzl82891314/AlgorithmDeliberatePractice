using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public int ClimbingStairs(int n) {
            if (n < 3) {
                return n;
            }
            var f1 = 1;
            var f2 = 2;
            for (var i = 3; i <= n; i++) {
                f2 += f1;
                f1 = f2 - f1;
            }
            return f2;
        }
    }
}
