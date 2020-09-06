# 第九周学习总结

本周是全系列课程的最后一周，内容也不多，只包括两部分`高级DP`和`字符串算法`。

## 知识点回顾

### 高级DP

所谓高级DP，其实就是多普通DP问题的一种升级，考虑的维度可能是三维，并且dp方程很难定义，所以这节的新内容其实不多，多的都是解题技巧，这周的知识点就是多练。

> Practice makes perfect

比较经典的题目是[72. Edit Distance](https://leetcode.com/problems/edit-distance/)。这个题其实dp的代码一点都不难，难的其实是如何想到这种dp的思想。因此这个题会引出一个dp解题的技巧：遇到字符串匹配等相关的问题，需要对dp进行升维，使用一个二维dp数组分别表示两个字符串dp[i, j]，i和j分别表示两个字符串子串的相关逻辑，比如此题就是子串中最小的编辑距离，这个题的思路和第一次学dp时做最长公共子序列的题类似，因此此题代码如下：

``` C#
public int MinDistance(string word1, string word2) {
    // 这里需要一个技巧，需要将空串考虑进去，因此dp的长度需要+1，第一位表示两个字符串的空串
    var dp = new int[word1.Length + 1, word2.Length + 1];
    for (var i = 1; i <= word1.Length; i++)
        // dp[i, 0]就表示word1的各个子串到空字符串的编辑距离，即字符串长度就是编辑距离
        dp[i, 0] = i;
    for (var j = 1; j <= word2.Length; j++)
        // 同上
        dp[0, j] = j;
    for (var i = 1; i <= word1.Length; i++) {
        for (var j = 1; j <= word2.Length; j++) {
            if (word1[i - 1] == word2[j - 1])
                // 如果最后一位相同，即可以理解为`约分`的概念，两个同时删除最后一位判定前面的长度
                dp[i, j] = dp[i - 1, j - 1];
            else
                // 如果不相等，则需要分别获取word1编辑、word2编辑，或者word1 和 word2编辑的最小值并且加一次编辑
                dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1])) + 1;
        }
    }
    return dp[word1.Length, word2.Length];
}
```

而除了这个编辑距离的问题，还有一个问题比较经典[32. Longest Valid Parentheses](https://leetcode.com/problems/longest-valid-parentheses/)，求一个括号字符串的最长有效括号数：

``` C#
public int LongestValidParentheses(string s) {
    // 思路：创建dp数组，表示dp[i]表示对应s[0..i]的子串的最长有效括号数
    // 可以发现，当s[i] == "("时，完全无需考虑这种情况，因此光靠左括号无法满足有效括号的情况，因此左括号为0
    // 当s[i] == ")"时，此时需要考虑两种不同的情况：
    // 1. 当s[i - 1] == "("时，即可以直接求dp[i] = dp[i - 2] + 2，其实dp[i - 2]表示这一对有效括号之前的最大有效括号
    // 2. 当s[i - 1] == ")"时，说明此时之前的子串刚好是一个有效括号，这时候就需要找到子串中有效括号之前的第一个字符，如果是"("则刚好和当前的i匹配成为有效括号，因此dp[i] = dp[i - dp[i - 1] - 2] + dp[i - 1] + 2;
    // 其中，dp[i - 1] - 2就表示的是上述子串有效括号之前的第一个字符
    int ans = 0;
    if (s.Length < 2) return ans;
    var dp = new int[s.Length];
    dp[0] = 0; dp[1] = s[0] == '(' && s[1] == ')' ? 2 : 0;
    if (dp[1] == 2) ans = 2;
    for (var i = 2; i < s.Length; i++) {
        if (s[i] == '(') continue;
        if (s[i - 1] == '(')
            dp[i] = dp[i - 2] + 2;
        else if (i - dp[i - 1] - 1 >= 0 && s[i - dp[i - 1] - 1] == '(')
            dp[i] = dp[i - 1] + 2 + (i - dp[i - 1] - 2 >= 0 ? dp[i - dp[i - 1] - 2] : 0);
        ans = Math.Max(ans, dp[i]);
    }
    return ans;
}
```

从上两个题可以看到，之前从来没有处理过这么复杂的dp方程组，其中各种计算的逻辑很绕很难理解。高级DP的问题DP的定义很难理解，并且维度都是多维，因此只能靠多做多练来让自己掌握。

### 字符串算法

字符串的相关算法其实日常工作中用到的很多，我在当前公司面试的时候就考到过字符串的相关问题，是用KMP等模板匹配算法进行字符串进行匹配的。

字符串有一个前置的概念，就是java和c#中字符串都是不可变量，即每次做字符串操作时，其实是创建了一个新的字符串并且把引用地址赋值过去，这也是字符串相关性能的考察点。

字符串的相关算法考点比较杂，基础的知识比如`字符串基础`、`字符串操作`、`异位词`和`回文字`等问题。题目杂并且多，我并没有全部做完，因此这里只拿一个比较经典的字符串和DP结合的问题重点举例[5. Longest Palindromic Substring](https://leetcode.com/problems/longest-palindromic-substring/)。

``` C#
public string LongestPalindrome(string s) {
    // 思路：定义dp[i, j] = boolean，表示s[i...j]是不是回文串
    // 因此dp[i, j] = dp[i + 1, j - 1] && s[i] == s[j]
    var ans = string.Empty;
    var dp = new bool[s.Length, s.Length];
    for (var i = s.Length - 1; i >= 0; i--) {
        for (var j = i; j < s.Length; j++) {
            // 注意这里的j - i < 2的顺序很重要，写在前面试为了避免空串或者1个字符的情况导致的数组越界问题
            dp[i, j] = s[i] == s[j] && (j - i < 2 || dp[i + 1, j - 1]);
            if (dp[i, j] && j - i + 1 > ans.Length)
                ans = s.Substring(i, j - i + 1); 
        }
    }
    return ans;
}
```