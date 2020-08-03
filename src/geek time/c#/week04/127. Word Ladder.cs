using System;
using System.Collections.Generic;

namespace week04 {
    public partial class Solution {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
            if (beginWord.Equals(endWord)) return 0;
            if (wordList == null || wordList.Count == 0) return 0;
            var dict = new Dictionary<string, IList<string>>();
            foreach(var word in wordList)
                for (var i = 0; i < word.Length; i++) {
                    var commonWord = GenerateCommonWord(i, word);
                    if (!dict.ContainsKey(commonWord)) dict.Add(commonWord, new List<string>() { word });
                    else dict[commonWord].Add(word);
                }
            var visited = new HashSet<string>(); visited.Add(beginWord);
            var queue = new Queue<KeyValuePair<string, int>>();
            queue.Enqueue(new KeyValuePair<string, int>(beginWord, 1));
            while (queue.Count > 0) {
                var cur = queue.Dequeue();
                for (var i = 0; i < cur.Key.Length; i++) {
                    var commonWord = GenerateCommonWord(i, cur.Key);
                    if (!dict.ContainsKey(commonWord)) continue;
                    var matchList = dict[commonWord];
                    foreach(var match in matchList) {
                        if (match.Equals(endWord)) return cur.Value + 1;
                        if (!visited.Contains(match)) {
                            visited.Add(match);
                            queue.Enqueue(new KeyValuePair<string, int> (match, cur.Value + 1));
                        }
                    }
                }
            }
            return 0;
        }
        private string GenerateCommonWord(int index, string sourceStr) {
            var end = sourceStr.Length - index - 1;
            return $"{sourceStr.Substring(0, index)}*{sourceStr.Substring(index + 1, end)}";
        }
    }
}