using System;

namespace week07 {
    public partial class Solution {
        public int ThreeSumClosest(int[] nums, int target) {
            Array.Sort(nums);
            var ans = target + int.MinValue + 1;
            for (var i = 0; i < nums.Length - 2; i++) {
                if (i > 0 && nums[i] == nums[i-1]) continue;
                var left = i + 1; var right = nums.Length - 1;
                while (left < right) {
                    var current = nums[i] + nums[left] + nums[right];
                    if (Math.Abs(target - ans) > Math.Abs(target - current)) ans = current;
                    if (current < target) {
                        while (left < right && nums[left++] == nums[left]) ;
                    } else if (current > target) {
                        while (left < right && nums[right--] == nums[right]) ;
                    } else return current;
                }
            }
            return ans;
        }
    }
}