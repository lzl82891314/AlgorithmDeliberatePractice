using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var direct = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 0, -1 },
                new int[] { -1, 0 }
            };
            var current = 0;
            var count = matrix.Length * matrix[0].Length - 1;
            var isCover = new HashSet<string>()
            {
                "0_0"
            };
            var x = 0; var y = 0;
            var result = new List<int>
            {
                matrix[0][0]
            };
            while (count > 0)
            {
                var tempX = x + direct[current][0]; 
                var tempY = y + direct[current][1];
                var key = tempX + "_" + tempY;
                if (!isCover.Contains(key) && tempX >= 0 && tempX < matrix.Length && tempY >= 0 && tempY < matrix[0].Length)
                {
                    x = tempX;
                    y = tempY;
                    result.Add(matrix[x][y]);
                    isCover.Add(key);
                    count--;
                }
                else
                {
                    current = (current + 1) % 4;
                }
            }
            return result;
        }
    }
}
