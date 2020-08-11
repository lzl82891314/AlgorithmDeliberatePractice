using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week04 {
    public partial class Solution {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
            return null;
        }
    }

    public partial class CodeBySlef {
        // occurred time limit exceeded error
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
            var dict = new Dictionary<string, IList<string>>();
            var visited = new HashSet<string>();
            foreach (var item in wordList)
                for (var i = 0; i < item.Length; i++) {
                    var commonStr = item.Substring(0, i) + '*' + item.Substring(i + 1, item.Length - i - 1);
                    if (!dict.ContainsKey(commonStr)) dict.Add(commonStr, new List<string>() { item });
                    else dict[commonStr].Add(item);
                }
            var nodeList = new List<Node<string>>();
            var queue = new Queue<Node<string>>();
            queue.Enqueue(new Node<string>(beginWord));
            while (queue.Count > 0) {
                var cur = queue.Dequeue();
                if (cur.Value.Equals(endWord)) {
                    nodeList.Add(cur);
                    continue;
                }
                visited.Add(cur.Value);
                var curValue = cur.Value;
                for (var i = 0; i < curValue.Length; i++) {
                    var commonCur = curValue.Substring(0, i) + '*' + curValue.Substring(i + 1, curValue.Length - i - 1);
                    if (!dict.ContainsKey(commonCur)) continue;
                    var comparativeList = dict[commonCur];
                    foreach (var comparativeWord in comparativeList) {
                        if (visited.Contains(comparativeWord)) continue;
                        var nextNode = new Node<string>(comparativeWord) {
                            Previous = cur
                        };
                        queue.Enqueue(nextNode);
                    }
                }
            }
            var ans = new List<IList<string>>();
            if (nodeList.Count == 0) return ans;
            foreach (var node in nodeList) {
                var list = new List<string>();
                var head = node;
                while (head != null) {
                    list.Add(head.Value);
                    head = head.Previous;
                }
                list.Reverse();
                ans.Add(list);
            }
            var minLength = ans.Min(item => item.Count);
            return ans.FindAll(item => item.Count == minLength);
        }

        private class Node<T> where T : class {
            public T Value { get; set; }
            public Node<T> Previous { get; set; }
            public Node<T> Next { get; set; }
            public Node(T value) {
                Value = value;
            }
        }
    }
}
