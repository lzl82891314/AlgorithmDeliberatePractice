using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var numberStack = new Stack<int>();
            var operatorStack = new Stack<char>();
            var i = -1;
            while (++i < s.Length)
            {
                var ch = s[i];
                if (ch == ' ') continue;
                if (char.IsDigit(ch))
                {
                    var num = ch - '0';
                    while (i + 1 < s.Length && char.IsDigit(s[i + 1]))
                    {
                        num *= 10;
                        num += s[++i] - '0';
                    }
                    if (operatorStack.Count == 0) numberStack.Push(num);
                    else
                    {
                        var op = operatorStack.Pop();
                        if (op == '+' || op == '-')
                        {
                            numberStack.Push(op == '+' ? num : -num);
                        }
                        else
                        {
                            var pre = numberStack.Pop();
                            numberStack.Push(op == '*' ? pre * num : pre / num);
                        }
                    }
                }
                else
                {
                    operatorStack.Push(ch);
                }
            }
            var result = numberStack.Pop();
            while (numberStack.Count > 0)
            {
                result += numberStack.Pop();
            }
            return result;
        }
    }
}
