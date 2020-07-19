using System;
using System.Collections.Generic;

namespace week02 {
    public partial class Solution {
        public int[] TwoSum(int[] nums, int target) {
            var dict = new Dictionary<int, int>();
            var list = new List<int>();
            for (var i = 0; i < nums.Length; i++) {
                if (dict.ContainsKey(target - nums[i])) {
                    list.Add(dict[target - nums[i]]);
                    list.Add(i);
                    break;
                }
                dict.TryAdd(nums[i], i);
            }
            return list.ToArray();
        }
    }
}