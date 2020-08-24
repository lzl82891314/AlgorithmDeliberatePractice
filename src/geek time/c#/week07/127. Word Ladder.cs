using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week07 {
    public partial class Solution {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
            if (beginWord.Equals(endWord)) return 0;
            if (beginWord.Length == 0 || endWord.Length == 0) return 0;
            var dict = new Dictionary<string, List<string>>();
            var flag = false;
            foreach (var word in wordList) {
                if (word.Equals(endWord)) flag = true;
                for (var i = 0; i < word.Length; i++) {
                    var commonWord = word.Substring(0, i) + "*" + word.Substring(i + 1, word.Length - i - 1);
                    if (!dict.ContainsKey(commonWord)) dict[commonWord] = new List<string>();
                    dict[commonWord].Add(word);
                }
            }
            if (!flag) return 0;
            var beginSet = new HashSet<string>() { beginWord };
            var endSet = new HashSet<string>() { endWord };
            var visited = new HashSet<string> {
                beginWord,
                endWord
            };
            var step = 1;
            while (beginSet.Count > 0 && endSet.Count > 0) {
                if(beginSet.Count > endSet.Count) {
                    var tempSet = beginSet;
                    beginSet = endSet;
                    endSet = tempSet;
                }
                var nextSet = new HashSet<string>();
                foreach (var current in beginSet) {
                    for (var i = 0; i < current.Length; i++) {
                        var commonWord = current.Substring(0, i) + "*" + current.Substring(i + 1, current.Length - i - 1);
                        if (!dict.ContainsKey(commonWord)) continue;
                        var matchedList = dict[commonWord];
                        foreach (var matchedWord in matchedList) {
                            if (endSet.Contains(matchedWord)) return step + 1;
                            if (visited.Contains(matchedWord)) continue;
                            nextSet.Add(matchedWord);
                            visited.Add(matchedWord);
                        }
                    }
                }
                beginSet = nextSet;
                step++;
            }
            return 0;
        }
    }
}
