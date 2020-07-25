namespace week03 {
    public partial class Solution {
        public int MajorityElement(int[] nums) {
            var candidate = 0;
            var num = 0;
            foreach(var n in nums) {
                if (candidate == 0) {
                    num = n;
                    candidate++;
                } else {
                    candidate = num == n ? candidate + 1 : candidate - 1;
                }
            }
            return num;
        }
    }
}