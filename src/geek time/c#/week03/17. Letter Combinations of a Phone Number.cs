using System;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        private IList<string> list_17 = new List<string>();
        public IList<string> LetterCombinations(string digits) {
            if (string.IsNullOrEmpty(digits)) return list_17;
            var hashMap = new Dictionary<char, string>() {
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                {'9', "wxyz"}
            };
            BackTrackingLetter(digits, "", 0, hashMap);
            return list_17;
        }

        private void BackTrackingLetter(string digits, string str, int index, Dictionary<char, string> hashMap) {
            if (index == digits.Length) {
                list_17.Add(str);
                return;
            }
            var letter = hashMap[digits[index]];
            for (var i = 0; i < letter.Length; i++) {
                BackTrackingLetter(digits, str + letter[i], index + 1, hashMap);
            }
        }
    }
}