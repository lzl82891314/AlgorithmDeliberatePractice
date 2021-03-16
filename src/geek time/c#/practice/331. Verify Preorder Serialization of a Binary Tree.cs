using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public bool IsValidSerialization(string preorder)
        {
            var treeFactors = preorder.Split(',');
            var isCovers = new int[treeFactors.Length];
            if (Validate(treeFactors, isCovers, 0))
            {
                foreach (var cover in isCovers)
                {
                    if (cover == 0) return false;
                }
                return true;
            }
            return false;
        }

        private bool Validate(string[] treeFactors, int[] isCovers, int curIndex)
        {
            if (curIndex >= treeFactors.Length) return false;
            isCovers[curIndex] = 1;
            if (treeFactors[curIndex] == "#") return true;
            var left = Validate(treeFactors, isCovers, curIndex + 1);
            var rightIndex = curIndex + 2;
            while (rightIndex < treeFactors.Length && isCovers[rightIndex] == 1) rightIndex++;
            return left && Validate(treeFactors, isCovers, rightIndex);
        }
    }
}
