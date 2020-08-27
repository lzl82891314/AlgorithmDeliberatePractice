using System;
using System.Collections.Generic;
using System.Text;

namespace week08 {
    public partial class Solution {
        public uint ReverseBits(uint n) {
            uint ans = 0;
            for (var i = 0; i < 32; i++) {
                ans = (ans << 1) + (n & 1);
                n >>= 1;
            }
            return ans;
        }
    }
}
