using System;

namespace week03 {
    public partial class Solution {
        public double MyPow(double x, int n) {
        if (n < 0) {
            // 这一步也很好的解决了int.MinValue的问题， -2147483648 取反 得 0
            n = -n;
            x = 1 / x;
        }
        return Pow(x, n);
    }
        private double Pow(double x, int n) {
            if (n == 0) return 1d;
            var half = Pow(x, n /2);
            return n % 2 == 0 ? half * half : half * half * x;
        }
    }
}