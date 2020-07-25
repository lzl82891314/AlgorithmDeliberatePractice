using System;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        private IList<IList<int>> list_46 = new List<IList<int>>();
        public IList<IList<int>> Permute(int[] nums) {
            if (nums == null || nums.Length == 0) return list_46;
            BackTrackingPermute(nums, new HashSet<int>());
            return list_46;
        }
        private void BackTrackingPermute(int[] nums, HashSet<int> hashSet) {
            if (hashSet.Count == nums.Length) {
                list_46.Add(new List<int>(hashSet));
                return;
            }
            for (var i = 0; i < nums.Length; i++) {
                if (hashSet.Contains(nums[i])) continue;
                hashSet.Add(nums[i]);
                BackTrackingPermute(nums, hashSet);
                hashSet.Remove(nums[i]);
            }
        }
    }
}