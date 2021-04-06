using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public bool Find132pattern(int[] nums)
        {
            if (nums.Length < 3) return false;
            for (var len = 3; len <= nums.Length; len++)
            {
                for (var left = 0; left <= nums.Length - len; left++)
                {
                    var right = left + len - 1;
                    for (var i = left + 1; i < right; i++)
                    {
                        if (nums[left] < nums[right] && nums[right] < nums[i])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
