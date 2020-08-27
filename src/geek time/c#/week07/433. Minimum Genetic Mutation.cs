using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week07 {
    public partial class Solution {
        public int MinMutation(string start, string end, string[] bank) {
            if (start.Length == 0 || end.Length == 0 || bank.Length == 0) return -1;
            if (start.Equals(end)) return 0;
            var dict = new Dictionary<string, List<string>>();
            var isExist = false;
            foreach (var gene in bank) {
                if (gene.Equals(end)) isExist = true;
                for (var i = 0; i < gene.Length; i++) {
                    var common = gene.Substring(0, i) + "*" + gene.Substring(i + 1, gene.Length - i - 1);
                    if (!dict.ContainsKey(common)) dict[common] = new List<string>();
                    dict[common].Add(gene);
                }
            }
            if (!isExist) return -1;
            var startSet = new HashSet<string>() { start };
            var endSet = new HashSet<string>() { end };
            var visited = new HashSet<string>();
            var step = 1;
            while (startSet.Count > 0 && endSet.Count > 0) {
                if (startSet.Count > endSet.Count) {
                    var tempSet = startSet;
                    startSet = endSet;
                    endSet = tempSet;
                }
                var nextSet = new HashSet<string>();
                foreach (var cur in startSet) {
                    visited.Add(cur);
                    for (var i = 0; i < cur.Length; i++) {
                        var common = cur.Substring(0, i) + "*" + cur.Substring(i + 1, cur.Length - i - 1);
                        if (!dict.ContainsKey(common) || (dict[common].Count == 1 && dict[common][0].Equals(cur))) continue;
                        var matchedList = dict[common];
                        foreach (var matched in matchedList) {
                            if (endSet.Contains(matched)) return step;
                            if (visited.Contains(matched)) continue;
                            nextSet.Add(matched);
                        }
                    }
                }
                step++;
                startSet = nextSet;
            }
            return -1;
        }
    }
}
