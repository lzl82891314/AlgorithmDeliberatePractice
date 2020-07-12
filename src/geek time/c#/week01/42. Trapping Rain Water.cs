using System;
using System.Collections.Generic;

public partial class Solution {
    public int Trap(int[] height) {
        // 解法：1. 双指针； 2. 栈
        // 先用双指针求解：
        int left, right, maxLeft, maxRight, total;
        left = maxLeft = maxRight = total = 0;
        right = height.Length - 1;
        
        while (left < right) {
            var hLeft = height[left];
            var hRight = height[right];
            if (hLeft < hRight) {
                if (hLeft < maxLeft) {
                    total += maxLeft - hLeft;
                } else {
                    maxLeft = hLeft;
                }
                left++;
            } else {
                if (hRight < maxRight) {
                    total += maxRight - hRight;
                } else {
                    maxRight = hRight;
                }
                right--;
            }
        }
        return total;
    }

    public int Trap_Stack(int[] height) {
        // 栈的解法和之前的最大矩形面积的题类似，只不过入栈内容是相反的
        // loop 时，将最小的height值的索引入栈，否则出栈计算面积
        var total = 0;
        var stack = new Stack<int>();
        for (var i = 0; i < height.Length; i++) {
            var h = height[i];
            while (stack.Count > 0 && height[stack.Peek()] < h) {
                var cur = stack.Pop();
                if (stack.Count == 0){
                    break;
                }
                var left = stack.Peek();
                var width = i - left - 1;
                var minHeight = Math.Min(height[left], h);
                total += width * (minHeight - height[cur]);
            }
            stack.Push(i);
        }
        return total;
    }
}