using System;

namespace RuntimeTest {
    class Program {
        static void Main(string[] args) {
            var foo = new Week01.Solution();
            var result = foo.ThreeSum(null);
            Console.WriteLine(result);
        }
    }
}
