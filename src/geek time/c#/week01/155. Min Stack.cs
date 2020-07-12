using System;
using System.Collections.Generic;
using System.Text;

namespace week01 {
    public class MinStack {
        // 最小栈解法：
        // 双栈：记录一个最小值栈，每次插入的时候判断最小值入栈，出栈的时候删除最顶端的最小值

        private Stack<int> _stack;
        private Stack<int> _minStack;

        public MinStack() {
            _stack = new Stack<int>();
            _minStack = new Stack<int>();
        }

        public void Push(int x) {
            _stack.Push(x);
            if (_minStack.Count == 0) {
                _minStack.Push(x);
            }
            else {
                _minStack.Push(Math.Min(x, _minStack.Peek()));
            }
        }

        public void Pop() {
            _stack.Pop();
            _minStack.Pop();
        }

        public int Top() {
            return _stack.Peek();
        }

        public int GetMin() {
            return _minStack.Peek();
        }
    }
}
