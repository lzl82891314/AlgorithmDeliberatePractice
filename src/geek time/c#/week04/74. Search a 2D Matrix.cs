using System;

namespace week04 {
    public partial class Solution {
        public bool SearchMatrix(int[][] matrix, int target) {
            if (matrix.Length == 0 || matrix[0].Length == 0) return false;
            var left = 0; var right = matrix.Length - 1;
            var searchArray = new int[0];
            while (left <= right) {
                var mid = left + (right - left) / 2;
                var cur = matrix[mid][0];
                if (cur == target) return true;
                else if (cur < target) {
                    if (mid < matrix.Length - 1 && target < matrix[mid + 1][0] || mid == matrix.Length - 1) {
                        searchArray = matrix[mid];
                        break;
                    }
                    else left = mid + 1;
                } else {
                    if (mid > 0 && target > matrix[mid - 1][0]) {
                        searchArray = matrix[mid - 1];
                        break;
                    }
                    else if (mid == 0) return false;
                    else right = mid - 1;
                }
            }
            left = 0; right = searchArray.Length - 1;
            while (left <= right) {
                var mid = left + (right - left) / 2;
                var cur = searchArray[mid];
                if (cur == target) return true;
                else if (cur < target) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
            return false;
        }
    }
}