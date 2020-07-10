using System;

namespace startup {
    class Program {
        static void Main(string[] args) {
            Week01();
        }

        static void Week01() {
            var foo = new week01.Solution();
            foo.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 }).Show();
            foo.ClimbingStairs(10).Show();
        }
    }
}
