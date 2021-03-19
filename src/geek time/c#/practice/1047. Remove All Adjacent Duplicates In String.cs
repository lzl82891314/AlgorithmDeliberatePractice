using System;
using System.Collections.Generic;
using System.Text;

namespace practice
{
    public partial class Solution
    {
        public string RemoveDuplicates(string S)
        {
            if (S.Length == 1) return S;
            var stack = new Stack<char>();
            foreach (var ch in S)
            {
                if (stack.Count > 0 && stack.Peek() == ch) stack.Pop();
                else stack.Push(ch);
            }
            var newS = new char[stack.Count];
            for (var i = newS.Length - 1; i >= 0; i--)
                newS[i] = stack.Pop();
            return new string(newS);
        }

        public string RemoveDuplicates_Self(string S)
        {
            if (S.Length == 1) return S;
            var chs = new List<char>();
            for (var i = 0; i < S.Length; i++)
            {
                if (i != S.Length -1 && S[i] == S[i + 1])
                {
                    i++;
                    continue;
                }
                chs.Add(S[i]);
            }
            var newS = new string(chs.ToArray());
            var needRec = false;
            for (var i = 0; i < newS.Length - 1; i++)
            {
                if (newS[i] == newS[i + 1])
                {
                    needRec = true;
                    break;
                }
            }
            return needRec ? RemoveDuplicates(newS) : newS;
        }
    }
}
