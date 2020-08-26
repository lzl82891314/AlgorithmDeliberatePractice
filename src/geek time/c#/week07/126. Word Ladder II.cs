using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace week07 {
    public partial class Solution {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
            // BFS——中文站惊险通过，英文站超时
            var ans = new List<IList<string>>();
            if (beginWord.Length == 0 || endWord.Length == 0 || wordList.Count == 0) return ans;
            var dict = new Dictionary<string, List<string>>();
            var flag = false;
            foreach (var word in wordList) {
                if (endWord.Equals(word)) flag = true;
                for (var i = 0; i < word.Length; i++) {
                    var commonWord = word.Substring(0, i) + "*" + word.Substring(i + 1, word.Length - i - 1);
                    if (!dict.ContainsKey(commonWord)) dict[commonWord] = new List<string>();
                    dict[commonWord].Add(word);
                }
            }
            if (!flag) return ans;
            var queue = new Queue<Node>();
            queue.Enqueue(new Node(beginWord));
            var visited = new HashSet<string>();
            var nodeList = new List<Node>();
            var minCount = int.MaxValue;
            while (queue.Count > 0) {
                var node = queue.Dequeue();
                visited.Add(node.val);
                for (var i = 0; i < node.val.Length; i++) {
                    var commonWord = node.val.Substring(0, i) + "*" + node.val.Substring(i + 1, node.val.Length - i - 1);
                    if (!dict.ContainsKey(commonWord)) continue;
                    var matchedList = dict[commonWord];
                    foreach (var matchedWord in matchedList) {
                        var preNode = new Node(node);
                        if (matchedWord.Equals(endWord)) {
                            var curNode = new Node(matchedWord, preNode);
                            preNode.next = curNode;
                            minCount = Math.Min(minCount, curNode.count);
                            nodeList.Add(curNode);
                            continue;
                        }
                        if (visited.Contains(matchedWord)) continue;
                        var nextNode = new Node(matchedWord, preNode);
                        preNode.next = nextNode;
                        queue.Enqueue(nextNode);
                    }
                }
            }
            if (nodeList.Count > 0) {
                foreach (var node in nodeList) {
                    if (node.count == minCount) {
                        var list = new List<string>();
                        var tail = node;
                        while(tail.pre != null) {
                            list.Add(tail.val);
                            tail = tail.pre;
                        }
                        list.Add(tail.val);
                        list.Reverse();
                        ans.Add(list);
                    }
                }
            }
            return ans;
        }

        public IList<IList<string>> FindLadders_DoubleEndedBFS(string beginWord, string endWord, IList<string> wordList) {
            var ans = new List<IList<string>>();
            if (beginWord.Length == 0 || endWord.Length == 0 || wordList.Count == 0) return ans;
            var dict = new Dictionary<string, IList<string>>();
            var flag = false;
            foreach (var word in wordList) {
                if (word.Equals(endWord)) flag = true;
                for (var i = 0; i < word.Length; i++) {
                    var commonWord = word.Substring(0, i) + "*" + word.Substring(i + 1, word.Length - i - 1);
                    if (!dict.ContainsKey(commonWord)) dict[commonWord] = new List<string>();
                    dict[commonWord].Add(word);
                }
            }
            if (!flag) return ans;
            var beginSet = new Dictionary<string, List<List<string>>>() { { beginWord, new List<List<string>>() } };
            var endSet = new Dictionary<string, List<List<string>>>() { { endWord, new List<List<string>>() } };
            var visited = new HashSet<string>(); var direction = true; 
            var minCount = int.MaxValue; var step = 1;
            while (beginSet.Count > 0 && endSet.Count > 0 && step < minCount) {
                if (beginSet.Count > endSet.Count) {
                    var tempSet = beginSet;
                    beginSet = endSet;
                    endSet = tempSet;
                    direction = !direction;
                }
                var nextSet = new Dictionary<string, List<List<string>>>();
                foreach (var current in beginSet) {
                    var word = current.Key;
                    visited.Add(word);
                    for (var i = 0; i < word.Length; i++) {
                        var commonWord = word.Substring(0, i) + "*" + word.Substring(i + 1, word.Length - i - 1);
                        if (!dict.ContainsKey(commonWord)) continue;
                        foreach (var matched in dict[commonWord]) {
                            if (endSet.ContainsKey(matched)) {
                                var preLen = 0;
                                do {
                                    var list = current.Value.Count == 0 ? new List<string>() : new List<string>(current.Value[preLen++]);
                                    list.Add(word); list.Add(matched);
                                    var nextLen = 0;
                                    do {
                                        var nextList = endSet[matched].Count == 0 ? new List<string>() : new List<string>(endSet[matched][nextLen++]);
                                        nextList.Reverse();
                                        var insertList = new List<string>(list);
                                        insertList.AddRange(nextList);
                                        if (!direction) insertList.Reverse();
                                        minCount = Math.Min(minCount, insertList.Count);
                                        ans.Add(insertList);
                                    } while (nextLen < endSet[matched].Count);
                                } while (preLen < current.Value.Count);
                            } else {
                                if (visited.Contains(matched)) continue;
                                if (!nextSet.ContainsKey(matched)) nextSet[matched] = new List<List<string>>();
                                var len = 0;
                                do {
                                    var preList = current.Value.Count == 0 ? new List<string>() : new List<string>(current.Value[len++]);
                                    preList.Add(word);
                                    nextSet[matched].Add(preList);
                                } while (len < current.Value.Count);
                            }
                        }
                    }
                }
                step++;
                beginSet = nextSet;
            }
            return ans;
        }

        private class Node {
            public string val;
            public Node pre;
            public Node next;
            public int count = 1;
            public Node(string val = null, Node pre = null) {
                this.val = val;
                this.pre = pre;
                if (pre != null) {
                    this.count += pre.count;
                }
            }
            public Node(Node node) {
                this.val = node.val;
                this.count = node.count;
                this.pre = node.pre;
                this.next = node.next;
            }
        }
    }
}
