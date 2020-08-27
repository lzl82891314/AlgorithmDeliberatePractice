using System;
using System.Collections.Generic;
using System.Text;

namespace week08 {
    public partial class Solution {
        public int HammingWeight(uint n) {
            var count = 0;
            while (n > 0) {
                n &= n - 1;
                count++;
            }
            return count;
        }
    }
}
