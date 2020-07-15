using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace week02 {
    public partial class Solution {
        public int[] MaxSlidingWindow(int[] nums, int k) {
            if (nums == null || nums.Length == 0) {
                return nums;
            }
            var result = new int[nums.Length - k + 1];
            // 单独排重使用
            var dict = new Dictionary<int, int>();
            var sortedSet = new SortedSet<int>();
            var j = -k + 1;
            for (var i = 0; i < nums.Length; i++, j++) {
                var cur = nums[i];
                // 进入重复值会更新i为最近的下标
                dict[cur] = i;
                if (j - 1 >= 0 && dict[nums[j - 1]] == j - 1) {
                    dict.Remove(nums[j - 1]);
                    sortedSet.Remove(nums[j - 1]);
                }
                sortedSet.Add(cur);
                if (j >= 0) {
                    result[j] = sortedSet.Max;
                }
            }
            return result;
        }
    }
}
