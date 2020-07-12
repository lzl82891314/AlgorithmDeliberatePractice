using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public partial class Solution {
        public bool IsValid(string s) {
            var stack = new Stack<char>();
            foreach (var c in s) {
                if (c == '(' || c == '{' || c == '[') {
                    stack.Push(c);
                    continue;
                }
                if (stack.Count == 0) {
                    return false;
                }
                if (!IsCompared(stack.Pop(), c)) {
                    return false;
                }
            }
            return stack.Count == 0;
        }

        private bool IsCompared(char left, char right) {
            if (left == '[')
                return right == ']';
            if (left == '{')
                return right == '}';
            if (left == '(')
                return right == ')';
            return false;
        }
    }
}
