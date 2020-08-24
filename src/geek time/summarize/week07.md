# 第七周学习总结

这周的知识点又多又难，加上我这周事情很多，没有抽出很多时间来深入学习这周的知识点，因此很多算法题都没有时间刷，只能先总结这周的知识点，学完之后再反过来补习这周的知识。

这周的主要内容涉及很多，比如字符串匹配的字典树 `Trie树`，解决群组归属问题的数据结构`并查集`，高级搜索算法`剪枝`、`双向BFS`和启发式搜索`A*`，以及最后的平衡二叉树`AVL`和`红黑树`。

上述的这些知识点单独拎出来一个我感觉都够我学习一周来消化的，但是现在时间紧任务重，所以只能课程全部结束后再来过遍数了。

## 知识点回顾

### Trie树

Trie树是字符串模式匹配算法的主要数据结构，在日常的工作中主要用来解决字符串的智能提示功能，比如Google中输入`you`自动匹配`you tube`这样了类似的功能。

其核心是使用了特定的数据结构，将字符串拆分存储到一颗多叉树中，然后以拆分出来的单个字符向下扩展之后的子树。比如`you`就可以拆分出`y`这个字符的分支，然后再向下继续匹配，只到找到最终的结果：

```
            root
        y   ...   z
    yo  yu  yy ...
you ...
```

其中为了加速，可以把每棵树的字符以hashMap的形式存储，加快查找速度。

Trie树的核心功能就是为了加速字符串匹配，在加权之后还能快速匹配出特定字符模式串下的topK个子串，其核心数据结构基本为：

``` C#
public class Trie {
    internal IDictionary<char, Trie> root;
    internal bool isEnd;

    public Trie() {
        root = new Dictionary<char, Trie>();
        isEnd = false;
    }

    /** Inserts a word into the trie. */
    public void Insert(string word) {
        if (string.IsNullOrEmpty(word)) return;
        var node = this;
        foreach (var ch in word) {
            if (!node.root.ContainsKey(ch)) {
                node.root.Add(ch, new Trie());
            }
            node = node.root[ch];
        }
        node.SetEnd();
    }

    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        var node = SearchNode(word);
        return node != null && node.isEnd;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        return SearchNode(prefix) != null;
    }

    private Trie SearchNode(string word) {
        if (string.IsNullOrEmpty(word)) return null;
        var node = this;
        foreach (var ch in word) {
            if (!node.root.ContainsKey(ch)) return null;
            node = node.root[ch];
        }
        return node;
    }

    internal void SetEnd() {
        this.isEnd = true;
    }
}
```

Trie树的主要题目就是[212. 单词搜索 II](https://leetcode-cn.com/problems/word-search-ii/)，这个题目中，需要创建Trie树来索引每个单词的startWith部分，从而加快搜索速度。其次主要逻辑使用DFS完成即可。因此主要解题思路以及伪代码如下：

``` C#
public IList<string> FindWords(char[][] board, string[] words) {
    // 通过单词列表构建Trie树
    var trie = new Trie();
    foreach (var word in words)
        trie.Insert(word);
    
    // 然后以每个单词为起点做带回溯的DFS
    for (var i = 0; i < board.Length; i++) {
        for (var j = 0; j < board[0].Length; j++) {
            BackTracking(board, i, j, "", new HashSet<string>());
        }
    }
}

private void BackTracking(char[][] board, int x, int y, string current, HashSet<string> visited) {
    current += board[x][y];
    if (!trie.StartWith(current)) return;
    visited.Add(x + "_" + y);
    if (trie.Search(current)) ans.Add(current);
    for (var i = 0; i < directionX.Length; i++) {
        var newX = x + directionX[i]; var newY = y + directionY[i];
        var key = newX + "_" + newY;
        if (newX >= 0 && newX < board.Length && newY >= 0 && newY < board[0].Length && !visited.Contains(key)) {
            visited.Add(key);
            BackTracking(board, newX, newY, current, visited);
            visited.Remove(key);
        }
    }
}
```

从上述的计算逻辑可以得出，使用Trie树 + BackTracking的方式解题的时间复杂度为：O(m^2*n^2)， 其中的n是board的行数，m是列数。

### 并查集

并查集是我之前几乎没有接触过的数据结构，其特点是：可以计算出几个节点的共同父亲节点，并且可以合并多个群组为一个。因此并查集的数据结构接口也很简单：

``` C#
public interface IUnionFind {
    // 查找一个节点p的父亲节点
    int Find(int p);
    // 合并一个节点p和一个节点q
    void Union(int p, int q);
}
```

其代码实现也很简单：

``` C#
public class UnionFind {
    private int count = 0;
    private int[] parent;

    public UnionFind(int n) {
        count = n;
        parent = new int[n];
        for (int i = 0; i < parent.Length; i++)
            // 初始状态，所有的节点都指向自己
            parent[i] = i;
    }

    public int Find(int p) {
        // 只有指向自己的节点是父亲节点
        while (p != parent[p]) {
            // 此操作即找到了p的父亲节点，又将p向上合并至父亲的父亲节点，从而做到降低链表的长度             
            parent[p] = parent[parent[p]];
            p = parent[p];
        }
        return p;
    }

    public void Union(int p, int q) {
        // 合并两个节点即合并两个节点的父亲节点
        int rootP = Find(p);
        int rootQ = Find(q);
        if (rootP == rootQ) return;
        // 如果两个节点的父亲节点不同，则将其中随机的一个指向另一个即可
        parent[rootP] = rootQ;
        // 合并之后，并查集中的分支数量会减少
        count--;
    }
}
```

### 高级搜索

所谓高级搜索，就是区别于普通的搜索进行一些`智能化`的操作。普通的搜索算法比如DFS和BFS，都是`傻搜`模式，在给定的范围内枚举各种结果，其利用的就是计算机处理重复问题的能力。

相较于一般的搜索，高级搜索主要分为一下几种：

1. 对中间结果进行一些判断，从而删除不需要的中间结果 —— 剪枝
2. 相较于从单独的一遍搜索改为从两端向中间逼近，并且每次只处理扩散范围小的那边 —— 双向BFS
3. 对搜索的存储数据结构由队列改为优先队列，分别计算各个待选数据的优先级进行按优先级搜索 —— 启发式搜索A*

上述的这些方法都是为了加速搜索的时间复杂度。

1. 对于剪枝：直接删除不需要的中间结果，比如斐波那契数列的递归写法，如果通过哈希表进行剪枝，则直接可以将O(n^2)的时间复杂度优化到O(n)
2. 对于双向BFS：由于BFS的搜索是扩散式的，理论来说，层次越深，需要遍历到的中间节点就越多，因而使用双向BFS则可以降低BFS扩散的成本，从而提速
3. 对于启发式搜索：比如迷宫问题，从左上角到右下角的问题中`曼哈顿距离越小`，则说明点的优先级越高，应该优先计算

二维矩阵中的曼哈顿距离为： |x1 - x2| + |y1 - y2|

关于双向BFS，可以通过[127. Word Ladder](https://leetcode.com/problems/word-ladder/)来详细说明。这个题中，正常的BFS解法是将beginWord存入一个queue中做BFS，而在双向BFS中，beginWord和endWord可以分别存入哈希表中，然后每次向内逼近，最终计算step即可。解题的伪代码如下：

``` C#
public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
    // 初始化资源，包括两个哈希表，一个visited，和一个wordDictionary，以便BFS使用
    var beginSet = new HashSet<string>() { beginWord };
    var endSet = new HashSet<string>() { endSet };
    var visited = new HashSet<string>() { beginWord, endWord };
    // 对这个dict的初始化省略
    var dict = new Dictionary<string, List<string>>();
    var step = 1;
    while (beginSet.Count != 0 && endSet.Count != 0) {
        // 双向BFS模板，每次只需要扩散数量小的集合，尽可能地减少扩散数量
        if (beginSet.Count > endSet.Count) {
            swap(beginSet, endSet);
        }

        var nextSet = new HashSet<string>();
        foreach (var current in beginSet) {
            for (var i = 0; i < current.Length, i++) {
                // 计算commonWord
                var commonWord = getCommonWord(current);
                var matchedList = dict[commonWord];
                foreach (var matchedWord in matchedList) {
                    // 如果另一端集合中存在匹配到的值，则直接返回
                    if (endSet.Contains(matchedWord)) return step + 1;
                    // 否则将扩展的值存入beginSet中
                    nextSet.Add(matchedWord); visited.Add(matchedWord);
                }
            }
        }
        beginSet = nextSet; step++;
    }
    return 0;
}
```

通过上个题，可以大概总结一下双端BFS的代码模板：

``` C#
public void DoubleEndedBFS(string start, string end) {
    var startSet = new HashSet<string>() { start };
    var endSet = new HashSet<string>() { endSet };
    var ans = 1;
    while (startSet.Count != 0 && endSet.Count != 0) {
        if (startSet.Count > endSet.Count) {
            swap(startSet, endSet);
        }
        var nextSet = new HashSet<string>();
        foreach (var current in beginSet) {
            if (endSet.Contains(current)) return ans + 1;
            nextSet.Add(newCurrent);
        }
        ans++;
        beginSet = nextSet;
    }
}
```

### 平衡二叉树

平衡二叉树是对二叉搜索树的一种改进，因为二叉搜索树存在一个问题：

> 当插入的节点每次都比上一次的小时，二叉搜索树会退化成一个链表

因此为了解决这个问题，出现了平衡二叉树——AVL。AVL有以下定义：左右子树的平衡因子的范围是-1， 0，1。所谓平衡因子，即为左右子树高度的差值。只有差值在1以内才是一个棵AVL树。

而让一棵树保持是一棵AVL树的操作就是对树的`左旋`和`右旋`操作。这两个操作在以前看红黑树的时候了解过，基本看的云里雾里不知所云。但是现在加入了前置知识点的内容就可以很清晰的理解了：左右旋操作就是为了让已经失去平衡的树`保持平衡的前提下`依然是`二叉搜索树`。有了这个概念，我也是第一次看懂了树左右旋本质原理。

但是AVL树的平衡条件太苛刻了，几乎每次插入操作都要对树进行左右旋调整，并且最主要的一点，它需要额外的空间存储当前树的高度，因此引入了近似平衡二叉树：红黑树。

红黑树是对AVL树的一种改进，其在AVL树的基础上规定了一些逻辑：

1. 平衡因子由差值为1改为了差值小于2倍，从而大大减少每次插入操作的左右旋操作
2. 每个节点都是由红色和黑色两种颜色组成
3. 根节点和所有叶子节点为黑色
4. 两个红色的节点不能相邻
5. 从任意节点到其每个叶子节点的所有路径中的黑色节点数量相同

本周的内容有难度，并且最近我因为工作生活有很多事没法抽出很多时间学习，因此本周的习题内容只做到剪枝的部分，之后我会将其余的内容一一补齐。