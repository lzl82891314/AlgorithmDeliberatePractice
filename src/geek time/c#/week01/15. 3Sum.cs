using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week01 {
    public partial class Solution {
        public IList<IList<int>> ThreeSum(int[] nums) {
            // 两端夹逼
            Array.Sort(nums);
            HashSet<IList<int>> result = new HashSet<IList<int>>();
            for(var k = 0; k < nums.Length - 2; k++) {
                // 如果nums[k] > 0说明之后的所有值都是正数不可能出现三个正数相加为0的情况，因此直接跳出循环
                if (nums[k] > 0) {
                    break;
                }
                // 排重
                if (k > 0 && nums[k] == nums[k - 1]) {
                    continue;
                }
                var i = k + 1;
                var j = nums.Length - 1;
                while (i < j) {
                    var sum = nums[i] + nums[j] + nums[k];
                    if (sum < 0) {
                        // 排重
                        while (i < j && nums[i] == nums[++i]) ;
                    } else if (sum > 0) {
                        while (i < j && nums[j] == nums[--j]) ;
                    } else {
                        result.Add(new int[] { nums[k], nums[i], nums[j] });
                        while (i < j && nums[i] == nums[++i]) ;
                        while (i < j && nums[j] == nums[--j]) ;
                    }
                }
            }
            return result.ToList();
        }
    }
}