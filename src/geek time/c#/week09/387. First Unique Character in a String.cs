using System;
using System.Collections.Generic;
using System.Text;

namespace week09 {
    public partial class Solution {
        public int FirstUniqChar(string s) {
            var visited = new Dictionary<char, int>();
            foreach (var ch in s) {
                if (!visited.ContainsKey(ch)) visited[ch] = 0;
                visited[ch]++;
            }
            for (var i = 0; i < s.Length; i++) {
                if (visited[s[i]] == 1) return i;
            }
            return -1;
        }

        public int FirstUniqChar_V2(string s) {
            // 自实现法二：
            // LeetCode里的结果这种方法快，但是这种很明显是双重for循环，不知道为什么
            var visited = new HashSet<char>();
            for (var i = 0; i < s.Length; i++) {
                var isUnique = true;
                for (var j = s.Length - 1; j > i; j--) {
                    if (s[i] == s[j]) {
                        isUnique = false;
                        visited.Add(s[i]);
                        break;
                    }
                }
                if (isUnique && !visited.Contains(s[i])) return i;
            }
            return -1;
        }
    }
}
