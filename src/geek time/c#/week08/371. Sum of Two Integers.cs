using System;
using System.Collections.Generic;
using System.Text;

namespace week08 {
    public partial class Solution {
        public int GetSum(int a, int b) {
            // 思路：
            // 1. a ^ b 表示a和b两个数位运算和的无进位结果，如 0101 + 0011 = 1000 而 0101 ^ 0011 = 0110 即少一次进位结果（倒数第二位）
            // 2. a & b 表示两个数的进位数，左移一位即为上述的倒数第二位的进位数： 0101 & 0011 = 0001， （0101 & 0011） << 1 = 0010
            // 3. 综上，a + b 即可表示为 1 ^ 2 的结果循环到进位的数为 0 即可
            var xor = a ^ b;
            var carry = (a & b) << 1;

            while (carry != 0) {
                var temp = (xor & carry) << 1;
                xor ^= carry;
                carry = temp;
            }
            return xor;
        }
    }
}
