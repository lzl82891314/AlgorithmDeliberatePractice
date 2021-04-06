namespace practice
{
    public partial class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            // 快慢指针
            // 此题是【26. 删除有序数组中的重复项 】的升级，26题使用的是单指针解决
            // 此题就应该使用快慢指针
            // slow指向当前的字段，fast指向slow+2确定是否是重复的字段
            if(nums.Length <= 2) return nums.Length;
            var slow = 0;
            var fast = slow + 2;
            while (fast < nums.Length)
            {
                if (nums[slow] != nums[fast])
                {
                    nums[slow++ + 2] = nums[fast];
                }
                fast++;
            }
            return slow + 2;
        }
    }
}
