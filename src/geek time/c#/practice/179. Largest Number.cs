using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public string LargestNumber(int[] nums)
        {
            var list = nums.ToList();
            list.Sort(new Comparer());
            if (list[0] == 0) return "0";
            var ans = new StringBuilder();
            foreach (var num in list)
            {
                ans.Append(num);
            }
            return ans.ToString();
        }
        private class Comparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return long.Parse($"{x}{y}") - long.Parse($"{y}{x}") > 0 ? -1 : 1;
            }
        }
    }
}
