using System;

namespace startup {
    class Program {
        static void Main(string[] args) {
            Week01();
            Console.WriteLine("HelloWorld !!");
        }

        static void Week01() {
            var foo = new week01.Solution();
            foo.ThreeSum(null);
        }
    }
}
