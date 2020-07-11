using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public IList<int> CountSmaller(int[] nums) {
            return new int[] { };
        }


        public IList<int> CountSmaller_Self(int[] nums) {
            // 自实现双层循环——超时
            var arr = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++) {
                var j = i + 1;
                var count = 0;
                while (j < nums.Length) {
                    if (nums[j++] < nums[i]) {
                        count++;
                    }
                }
                arr[i] = count;
            }
            return arr;
        }
    }
}
