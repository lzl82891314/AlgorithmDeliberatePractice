using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week08 {
    public partial class Solution {
        public IList<IList<int>> FindSubsequences(int[] nums) {
            var ans = new List<IList<int>>();
            if (nums.Length == 0) return ans;
            var visited = new HashSet<string>();
            for (var i = 0; i < nums.Length - 1; i++) {
                Backtracking(nums, i, new List<int>() { nums[i] }, ans, visited);
            }
            return ans;
        }
        private void Backtracking(int[] nums, int index, List<int> list, List<IList<int>> ans, HashSet<string> visited) {
            for (var i = index + 1; i < nums.Length; i++) {
                if (nums[i] >= nums[index]) {
                    list.Add(nums[i]);
                    var key = string.Join('_', list);
                    if (!visited.Contains(key)) {
                        ans.Add(new List<int>(list));
                        visited.Add(key);
                    }
                    Backtracking(nums, i, list, ans, visited);
                    list.Remove(nums[i]);
                }
            }
        }
    }
}
