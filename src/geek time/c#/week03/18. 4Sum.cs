using System;
using System.Collections.Generic;

namespace week03 {
    public partial class Solution {
        public IList<IList<int>> FourSum(int[] nums, int target) {
            var list = new List<IList<int>>();
            if (nums == null || nums.Length < 4) {
                return list;
            }
            var a = 0;
            Array.Sort(nums);
            while (a < nums.Length - 3) {
                while (a > 0  && a < nums.Length - 1 && nums[a] == nums[a-1]) {
                    a++;
                }
                for (var b = a + 1; b < nums.Length - 2; b++) {
                    while (b > a + 1 && b < nums.Length - 2 && nums[b] == nums[b-1]) {
                        b++;
                    }
                    var c = b + 1;
                    var d = nums.Length - 1;
                    while (c < d) {
                        var sum = nums[a] + nums[b] + nums[c] + nums[d];
                        if (sum < target) {
                            while (c < d && nums[c++] == nums[c]);
                            continue;
                        }
                        if (sum > target) {
                            while (c < d && nums[d--] == nums[d]);
                            continue;
                        }
                        if (sum == target) {
                            list.Add(new List<int>() { nums[a], nums[b], nums[c], nums[d]});
                            while (c < d && nums[c++] == nums[c]);
                            while (c < d && nums[d--] == nums[d]);
                        }
                    }
                }
                a++;
            }
            return list;
        }
    }
}