using System;

namespace week06 {
    public partial class Solution {
        public int LeastInterval(char[] tasks, int n) {
            var taskCount = new int[26];
            foreach (var task in tasks) 
                taskCount[task - 'A'] += 1;
            Array.Sort(taskCount);
            var maxTask = taskCount[25] - 1; var slots = maxTask * n;
            for (var i = 24; i >= 0; i--) {
                if (taskCount[i] == 0) break;
                // 每次停顿所产生的的slot最多只能放 maxTask - 1这么多个值，所以如果一个task数量和maxTask一样多，那只能占用
                // maxTask - 1个slot，剩下的就要后续补上，因此这里要做一个Math.Min的判断
                slots -= Math.Min(taskCount[i], maxTask);
            }
            return slots > 0 ? slots + tasks.Length : tasks.Length;
        }
    }
}
