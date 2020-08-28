using System;
using System.Collections.Generic;
using System.Text;

namespace week08 {
    public partial class Solution {
        public bool JudgeCircle(string moves) {
            var directionX = new int[] { 1, -1, 0, 0 };
            var directionY = new int[] { 0, 0, -1, 1 };
            var dict = new Dictionary<char, int>() { { 'U', 0 }, { 'D', 1 }, { 'L', 2 }, { 'R', 3 } };
            var x = 0; var y = 0;
            for (var i = 0; i < moves.Length; i++) {
                x += directionX[dict[moves[i]]];
                y += directionY[dict[moves[i]]];
            }
            return x == 0 && y == 0;
        }
    }
}
