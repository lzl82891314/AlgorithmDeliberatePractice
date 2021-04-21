using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            if (nums.Length == 0) return;
            var p = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[p] = nums[i];
                    p++;
                }
                if (i != p)
                {
                    nums[i] = 0;
                }
            }
        }
    }
}
