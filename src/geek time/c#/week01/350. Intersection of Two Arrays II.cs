using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace week01 {
    public partial class Solution {
        public int[] Intersect(int[] nums1, int[] nums2) {
            // 两种解法：
            // 1. 哈希表。 因为题目说了可以结果和原数组顺序随机，因此可以用哈希表存储第一个数组的元素然后遍历第二个数组
            // 2. 排序 + 双指针 

            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums1.Length; i++) {
                if (dict.ContainsKey(nums1[i])) {
                    dict[nums1[i]] += 1;
                } else {
                    dict.Add(nums1[i], 1);
                }
            }

            var result = new List<int>();
            for (var i = 0; i < nums2.Length; i++) {
                if (dict.ContainsKey(nums2[i]) && dict[nums2[i]] > 0) {
                    result.Add(nums2[i]);
                    dict[nums2[i]] -= 1;
                }
            }
            return result.ToArray();
        }

        public int[] Intersect_Sort(int[] nums1, int[] nums2) {
            // 排序
            Array.Sort(nums1);
            Array.Sort(nums2);
            int i, j;
            i = j = 0;
            var result = new List<int>();
            while (i < nums1.Length && j < nums2.Length) {
                if (nums1[i] < nums2[j]) {
                    i++;
                } else if (nums1[i] > nums2[j]) {
                    j++;
                } else {
                    result.Add(nums1[i++]);
                    j++;
                }
            }
            return result.ToArray();
        }
    }
}
