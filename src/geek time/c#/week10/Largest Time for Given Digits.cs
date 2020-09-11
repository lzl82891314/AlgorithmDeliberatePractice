using System;
using System.Collections.Generic;
using System.Text;

namespace week10 {
    public partial class Solution {
        public string LargestTimeFromDigits(int[] arr) {
            var x = -1; var y = -1; var maxHour = -1;
            for (var i = 0; i < arr.Length - 1; i++)
                for (var j = i + 1; j < arr.Length; j++) {
                    var cur = arr[i] * 10 + arr[j];
                    if (cur / 24 >= 1) continue;
                    if (cur > maxHour) {
                        x = i; y = j;
                        maxHour = cur;
                    }
                }
            if (maxHour == -1) return "";
            var a = -1; var b = -1; var maxMinue = -1;
            for (var i = 0; i < arr.Length; i++) {
                if (i == x || i == y) continue;
                if (a == -1) a = i;
                else if (b == -1) b = i;
            }
            var temp1 = arr[a] * 10 + arr[b];
            var temp2 = arr[b] * 10 + arr[a];
            if (temp1 / 60 < 1 && (temp1 >= temp2 || temp2 / 60 >= 1)) maxMinue = temp1;
            if (temp2 / 60 < 1 && (temp1 <= temp2 || temp1 / 60 >= 1)) maxMinue = temp2;
            if (maxMinue == -1) return "";
            var hour = maxHour == 0 ? "00" : maxHour.ToString();
            var minue = maxMinue == 0 ? "00" : maxMinue.ToString();
            return $"{hour}:{minue}";
        }
    }
}
