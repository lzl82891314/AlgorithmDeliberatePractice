using System;

namespace week08 {
    public partial class Solution {
        public void BubblingSort(int[] nums) {
            if (nums == null || nums.Length == 0) return;
            for (var i = 0; i < nums.Length - 1; i++) {
                for (var j = 0; j < nums.Length - 1 - i; j++) {
                    if (nums[j] > nums[j + 1]) {
                        var temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
        }

        public void SelectingSort(int[] nums) {
            if (nums == null || nums.Length == 0) return;
            for (var i = 0; i < nums.Length - 1; i++) {
                var min = i;
                for (var j = i + 1; j < nums.Length; j++) {
                    if (nums[j] < nums[min]) min = j;
                }
                if (min != i) {
                    var temp = nums[i];
                    nums[i] = nums[min];
                    nums[min] = temp;
                }
            }
        }

        public void InsertingSort(int[] nums) {
            if (nums == null || nums.Length == 0) return;
            for (var i = 0; i < nums.Length - 1; i++) {
                var cur = nums[i + 1]; var j = i;
                while (j >= 0 && cur < nums[j]) nums[j + 1] = nums[j--];
                nums[j + 1] = cur;
            }
        }
    }
}