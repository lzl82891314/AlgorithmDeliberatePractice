using System;

namespace week04 {
    public partial class Solution {
        public bool IsPerfectSquare(int num) {
            if (num == 1) return true;
            long left = 1;
            long right = num / 2;
            while (left <= right) {
                long mid = left + (right - left) / 2;
                if (mid * mid < num) 
                    left = mid + 1;
                else if (mid * mid > num) 
                    right = mid - 1;
                else 
                    return true;
            }
            return false;
        }
    }
}