using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week08 {
    public partial class Solution {
        public IList<string> FindItinerary(IList<IList<string>> tickets) {
            var ans = new List<string>();
            if (tickets.Count == 0) return ans;
            var dict = new Dictionary<string, List<string>>();
            foreach (var ticket in tickets) {
                var from = ticket[0];
                var to = ticket[1];
                if (!dict.ContainsKey(from)) {
                    dict[from] = new List<string>() { to };
                } else {
                    dict[from].Add(to);
                    dict[from].Sort();
                }
            }
            DFS(dict, "JFK", ans);
            ans.Reverse();
            return ans;
        }

        private void DFS(Dictionary<string, List<string>> dict, string current, List<string> ans) {
            while (dict.ContainsKey(current) && dict[current].Count > 0) {
                var dist = dict[current].First();
                dict[current].Remove(dist);
                DFS(dict, dist, ans);
            }
            ans.Add(current);
        }
    }
}
