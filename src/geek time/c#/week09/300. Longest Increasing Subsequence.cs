using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week09 {
    public partial class Solution {
        public int LengthOfLIS(int[] nums) {
            if (nums.Length == 0) return 0;
            var list = new List<int> { nums[0] };
            for (var i = 1; i < nums.Length; i++) {
                if (nums[i] == list.Last()) continue;
                else if (nums[i] > list.Last()) list.Add(nums[i]);
                else {
                    var left = 0; var right = list.Count - 1; var pos = 0;
                    while (left <= right) {
                        var mid = (left + right) >> 1;
                        if (list[mid] < nums[i]) {
                            left = mid + 1;
                            pos = left;
                        } else right = mid - 1;
                    }
                    list[pos] = nums[i];
                }
            }
            return list.Count;
        }
    }
}
