using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public bool ValidMountainArray(int[] A) {
            for (var i = 1; i < A.Length - 1; i++) {
                if (A[i] > A[i - 1] && A[i] > A[i + 1]) {
                    if (IsIncrease(i - 1, A) && IsDecrease(i + 1, A)) {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsIncrease(int i, int[] A) {
            if (i - 1 < 0) {
                return true;
            }
            return A[i] > A[i - 1] && IsIncrease(i - 1, A);
        }

        private bool IsDecrease(int i, int[] A) {
            if (i > A.Length - 2) {
                return true;
            }
            return A[i] > A[i + 1] && IsDecrease(i + 1, A);
        }
    }
}
