namespace week04 {
    public partial class Solution {
        public bool CanJump(int[] nums) {
            if (nums == null || nums.Length == 0) return false;
            var ans = false;
            var destination = nums.Length - 1;
            for (var i = nums.Length - 1; i >= 0; i--) {
                if (nums[i] + i >= destination)
                    destination = i;
                ans = nums[i] + i >= destination;
            }
            return ans;
        }
    }
}