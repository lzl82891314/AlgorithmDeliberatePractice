using System;
using System.Collections.Generic;
using System.Text;

namespace week05 {
    public partial class Solution {
        public int SubarraySum(int[] nums, int k) {
            // 暴力法
            if (nums == null || nums.Length == 0) return 0;
            var ans = 0;
            for (var i = 0; i < nums.Length; i++) {
                var sum = nums[i];
                if (sum == k) ans++;
                var next = i + 1;
                while (next < nums.Length) {
                    sum += nums[next++];
                    if (sum == k) {
                        ans++;
                    }
                }
            }
            return ans;
        }

        public int SubarraySum_HashTable(int[] nums, int k) {
            // 前缀和 + 哈希表解法
            // 其中精妙的地方在于判断存在sum - k，这和2Sum的题类似
            var sum = 0; var ans = 0;
            var hashMap = new Dictionary<int, int> {
                { 0, 1 }
            };
            foreach (var num in nums) {
                sum += num;
                if (hashMap.ContainsKey(sum - k)) ans += hashMap[sum - k];
                if (hashMap.ContainsKey(sum)) hashMap[sum] += 1;
                else hashMap[sum] = 1;
            }
            return ans;
        }
    }
}
