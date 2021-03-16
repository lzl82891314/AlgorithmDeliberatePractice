using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public int BeautySum(string s)
        {
            var result = 0;
            if (s.Length <= 2) return result;
            // 以子字符串长度为循环体， i表示子字符串的长度
            for (var i = 3; i <= s.Length; i++)
            {
                var left = 0; var right = 0; var nums = new int[26];
                // 滑动窗口
                while (right < s.Length)
                {
                    nums[s[right++] - 'a']++;
                    if (right - left == i)
                    {
                        var max = int.MinValue; var min = int.MaxValue;
                        for (var j = 0; j < nums.Length; j++)
                        {
                            if (nums[j] <= 0) continue;
                            max = Math.Max(max, nums[j]);
                            min = Math.Min(min, nums[j]);
                        }
                        result += max - min;
                        nums[s[left++] - 'a']--;
                    }
                }
            }
            return result;
        }
    }
}
