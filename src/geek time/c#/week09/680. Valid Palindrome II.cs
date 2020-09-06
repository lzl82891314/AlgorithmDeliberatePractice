using System;

namespace week09 {
    public partial class Solution {
        private bool flag = true;
        public bool ValidPalindrome(string s) {
            if (string.IsNullOrWhiteSpace(s)) return true;
            var left = 0; var right = s.Length - 1;
            while (left <= right) {
                if (s[left] == s[right]) {
                    left++; right--;
                    continue;
                }
                if (flag) {
                    flag = false;
                    var sub1 = s.Substring(left, right - left);
                    var sub2 = s.Substring(left + 1, right - left);
                    return ValidPalindrome(sub1) 
                    || ValidPalindrome(sub2);
                }
                return false;
            }
            return true;
        }
    }
}