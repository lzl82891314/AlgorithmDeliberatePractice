using System;
using System.Collections.Generic;
using System.Text;

namespace week08 {
    public partial class Solution {
        public bool IsPowerOfTwo(int n) {
            return n > 0 && (n & (n - 1)) == 0;
        }
    }
}
