using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        private int[] _nums = new int[16];
        public bool CheckPowersOfThree_BySelf(int n)
        {
            if (n == 1) return _nums[0] == 0;
            if (n == 3) return _nums[1] == 0;
            var left = 0; var right = 15;
            while (left <= right)
            {
                var mid = (left + right) >> 1;
                if ((int)Math.Pow(3, mid) == n) return _nums[mid] == 0;
                else if ((int)Math.Pow(3, mid) < n && (int)Math.Pow(3, mid + 1) > n)
                {
                    if (_nums[mid] == 1) return false;
                    _nums[mid] = 1;
                    return CheckPowersOfThree_BySelf(n - (int)Math.Pow(3, mid));
                }
                else if ((int)Math.Pow(3, mid) > n) right = mid;
                else left = mid;
            }
            return false;
        }

        public bool CheckPowersOfThree(int n)
        {
            if (n == 1) return true;
            if (n % 3 == 0) return CheckPowersOfThree(n / 3);
            if (n % 3 == 1) return CheckPowersOfThree((n - 1) / 3);
            return false;
        }
    }
}
