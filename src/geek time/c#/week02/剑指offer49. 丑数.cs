using System;
using System.Collections.Generic;

namespace week02 {
    public partial class Solution {
        public int NthUglyNumber(int n) {
            var primes = new int[]{ 2, 3, 5};
            var uglySet = new HashSet<long>();
            var heap = new SortedSet<long>();
            uglySet.Add(2); uglySet.Add(3); uglySet.Add(5);
            heap.Add(2); heap.Add(3); heap.Add(5);
            long num = 1;
            for (var i = 1; i < n; i++) {
                num = heap.Min;
                heap.Remove(num);
                foreach(var p in primes) {
                    var cur = num * p;
                    if (!uglySet.Contains(cur)) {
                        heap.Add(cur);
                        uglySet.Add(cur);
                    }
                }
            }
            return (int)num;
        }
    }
}