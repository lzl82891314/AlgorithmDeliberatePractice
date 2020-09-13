using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week10 {
    public partial class Solution {
        public int[] TopKFrequent(int[] nums, int k) {
            var ans = new List<int>();
            var scans = new Dictionary<int, int>();
            foreach (var num in nums) {
                if (!scans.ContainsKey(num)) scans[num] = 1;
                else scans[num]++;
            }
            var dict = new SortedList<int, List<int>>();
            foreach (var item in scans) {
                if (!dict.ContainsKey(item.Value)) dict.Add(item.Value, new List<int>());
                dict[item.Value].Add(item.Key);
            }
            while (k > 0) {
                var topItem = dict.Last();
                ans.AddRange(topItem.Value);
                dict.Remove(topItem.Key);
                k -= topItem.Value.Count;
            }
            return ans.ToArray();
        }
    }
}
