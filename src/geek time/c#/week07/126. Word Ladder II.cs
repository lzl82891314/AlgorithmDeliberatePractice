using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace week07 {
    public partial class Solution {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
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
            var beginSet = new Dictionary<string, Node>() { { beginWord, new Node(beginWord) } };
            var visited = new HashSet<string>() { beginWord };
            var nodeList = new List<Node>();
            var minCount = int.MaxValue;
            while (beginSet.Count > 0) {
                var nextSet = new Dictionary<string, Node>();
                foreach (var item in beginSet) {
                    var current = item.Key;
                    var node = item.Value;
                    if (node.count > minCount) break;
                    for (var i = 0; i < current.Length; i++) {
                        var commonWord = current.Substring(0, i) + "*" + current.Substring(i + 1, current.Length - i - 1);
                        if (!dict.ContainsKey(commonWord)) continue;
                        var matchedList = dict[commonWord];
                        foreach (var matchedWord in matchedList) {
                            var preNode = new Node(node);
                            if (matchedWord.Equals(endWord)) {
                                var curNode = new Node(matchedWord, preNode);
                                preNode.next = curNode;
                                minCount = Math.Min(minCount, curNode.count);
                                nodeList.Add(curNode);
                                visited.Add(matchedWord);
                                continue;
                            }
                            if (visited.Contains(matchedWord)) continue;
                            var nextNode = new Node(matchedWord, preNode);
                            preNode.next = nextNode;
                            nextSet[matchedWord] = nextNode;
                            visited.Add(matchedWord);
                        }
                    }
                }
                beginSet = nextSet;
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
                this.pre = node.pre;
                this.next = node.next;
                this.count = node.count;
            }
        }
    }
}
