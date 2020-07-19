using System;
using System.Collections.Generic;
using System.Text;

namespace week02 {
    public partial class Solution {
        public bool IsAnagram(string s, string t) {
            // 可以排序、hashMap以及数组存储，可见数组的速度最快
            if (s.Length != t.Length)
                return false;

            var counter = new int[26];
            foreach (var c in s) counter[c - 'a']++;
            foreach (var c in t) {
                counter[c - 'a']--;
                if (counter[c - 'a'] < 0) return false;
            }
            return true;
        }

        public bool IsAnagram_BySelf(string s, string t) {
            if (s.Length != t.Length) {
                return false;
            }
            var dict = new Dictionary<char, int>();
            for (var i = 0; i < s.Length; i++) {
                if (dict.ContainsKey(s[i])) {
                    dict[s[i]]++;
                } else {
                    dict.Add(s[i], 1);
                }
            }
            for (var i = 0; i < t.Length; i++) {
                if (!dict.ContainsKey(t[i]) || dict[t[i]] <= 0) {
                    return false;
                }
                dict[t[i]]--;
            }
            return true;
        }
    }
}
