using System;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        private IList<IList<int>> list_47 = new List<IList<int>>();
        public IList<IList<int>> PermuteUnique(int[] nums) {
            if (nums == null || nums.Length == 0) return list_47;
            Array.Sort(nums);
            BackTrackingPermuteUnique(nums, new List<int>(), new HashSet<int>());
            return list_47;
        }
        private void BackTrackingPermuteUnique(int[] nums, List<int> list, HashSet<int> hashSet) {
            if (list.Count == nums.Length) {
                list_47.Add(new List<int>(list));
                return;
            }
            for (var i = 0; i < nums.Length; i++) {
                if (hashSet.Contains(i)) continue;
                if (i > 0 && nums[i] == nums[i - 1] && hashSet.Contains(i - 1)) break;
                hashSet.Add(i);
                list.Add(nums[i]);
                BackTrackingPermuteUnique(nums, list, hashSet);
                hashSet.Remove(i);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}