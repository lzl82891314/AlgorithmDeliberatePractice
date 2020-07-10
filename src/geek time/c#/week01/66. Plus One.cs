using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public int[] PlusOne(int[] digits) {
            // 加一只有两种不同的结果：
            // 1. 末尾不是9 即 （末尾 + 1）% 10 ！= 0，直接返回即可
            // 2. 末尾是9，则循环位数逐一判断，如果最终的结果中第一位也是0，则在数组中unshift（1）即可

            var i = digits.Length - 1;
            do {
                digits[i] = (digits[i] + 1) % 10;
            } while (digits[i] == 0 && --i >= 0);

            if (i < 0) {
                digits = new int[digits.Length + 1];
                digits[0] = 1;
            }
            return digits;

            // 比上面的解法更慢
            //for (var i = digits.Length - 1; i >= 0; i--) {
            //    if (digits[i] < 9) {
            //        digits[i]++;
            //        return digits;
            //    }
            //    digits[i] = 0;
            //}
            //digits = new int[digits.Length + 1];
            //digits[0] = 1;
            //return digits;
        }
    }
}
