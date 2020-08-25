using System;
using System.Collections.Generic;
using System.Text;

namespace week08 {
    public partial class Solution {
        public bool JudgeSquareSum(int c) {
            var left = 0; var right = (int)Math.Sqrt(c);
            while (left <= right) {
                var cur = left * left + right * right;
                if (cur == c) return true;
                else if (cur < c) left++;
                else right--;
            }
            return false;
        }
    }
}
