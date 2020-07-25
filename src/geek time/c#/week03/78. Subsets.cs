using System;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        private IList<IList<int>> list_78 = new List<IList<int>>() { new List<int>() };
        public IList<IList<int>> Subsets(int[] nums) {
            if (nums == null || nums.Length == 0) return list_78;
            BackTrackingSubsets(nums, new List<int>(), 0);
            return list_78;
        }
        private void BackTrackingSubsets(int[] nums, List<int> list, int level) {
            if (nums.Length == level) {
                list_78.Add(new List<int>(list));
                return;
            }
            BackTrackingSubsets(nums, list, level + 1);
            list.Add(nums[level]);
            BackTrackingSubsets(nums, list, level + 1);
            list.RemoveAt(list.Count - 1);
        }
    }
}