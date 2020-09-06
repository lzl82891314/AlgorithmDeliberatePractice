using System;

namespace week09 {
    public partial class Solution {
        public bool IsPalindrome(string s) {
            if (string.IsNullOrWhiteSpace(s)) return true;
            var left = 0; var right = s.Length - 1;
            while (left <= right) {
                while (left <= right && !char.IsLetterOrDigit(s[left])) left++;
                while (left <= right && !char.IsLetterOrDigit(s[right])) right--;
                if (left <= right && char.ToLower(s[left]) != char.ToLower(s[right])) return false;
                left++; right--;
            }
            return true;
        }
    }
}