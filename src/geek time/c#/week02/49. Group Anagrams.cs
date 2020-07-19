using System;
using System.Collections.Generic;
using System.Linq;

namespace week02 {
    public partial class Solution {
        public IList<IList<string>> GroupAnagrams(string[] strs) {
            // 这是自己实现的一个排序版本
            // 官方题解中介绍了另一个解法：计数分类，意思就是for循环每次对每个字符串出现的字符做一次拼接然后插入哈希表中，
            // 然后将生成的字符串和哈希表的key作对比计算，如：1a2b0c......0z这样的串，这样做的好处是每次的哈希串长度固定，
            // 且时间复杂度优于排序
            var result = new List<IList<string>>();
            if (strs == null || strs.Length == 0) {
                return result;
            }
            var dict = new Dictionary<string, IList<string>>();
            foreach(var item in strs) {
                var source = new string(item.OrderBy(c => c).ToArray());
                if (dict.ContainsKey(source)) {
                    dict[source].Add(item);
                } else {
                    var groupList = new List<string>();
                    groupList.Add(item);
                    dict[source] = groupList;
                }
            }
            foreach(var item in dict) {
                result.Add(item.Value);
            }
            return result;
        }
    }
}