public partial class Solution {
    public int RemoveDuplicates(int[] nums) {
        // 此题类同于 move zero
        if (nums == null || nums.Length == 0) {
            return 0;
        }
        var count = nums.Length;
        var p = 0;
        for (var i = 1; i < nums.Length; i++) {
            if (nums[p] != nums[i]) {
                nums[++p] = nums[i];
            }
        }
        return ++p;
    }
}