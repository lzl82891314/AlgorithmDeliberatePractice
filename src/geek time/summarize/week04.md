# 第四周学习总结

这周由于工作问题，只有周天很少的时间能学习课程，因此最终的算法作业题只能刷一部分，下周会把剩余的都补上。

## 知识点回顾

本周的主要内容是递归遍历的后续`广度优先搜索`和`深度优先搜索`两个非常经典的图遍历算法。之后开始学习了`二分查找`和`贪心算法`。

### 广度优先和深度优先

所谓的搜索其实就是图的遍历算法，其中最基础的搜索算法就是广度优先和深度优先搜索。

#### 深度优先搜索

对于深度优先搜索之前在做树的遍历的时候其实已经用过很多了，是一种`递归遍历算法`，其逻辑就是分别递归遍历节点的子节点，只到一个节点为空或者被访问过，其遍历的顺序和树的先序遍历相同，代码模板和递归的代码模板也十分相似：

``` C#
private void DFS(Node node, HashSet<Node> visited) {
    // 递归终止条件
    if (node == null || visited.Contains(node)) return;

    // 处理当前层逻辑
    visited.Add(node);
    // ...

    // 下钻
    foreach(var item in node.Children) {
        DFS(item, visited);
    }
}
```

此外，DFS也有一种非递归写法，即把递归的模式拆解为使用Stack记录每次遍历的内容存入stack，其实现类似于BFS，就不多写了。

#### 广度优先搜索

之前在学习中或者是项目中对广度优先搜索用的不是很多，所以刚开始的时候我对广度优先搜索的概念都有些模糊。其遍历方式类似于人脑对树的遍历方式，是按层遍历的，其遍历过程需要一个Queue来处理下钻的逻辑，因此广度优先搜索`不是递归遍历算法`。使用一维数组存储二叉树的方式即为广度优先搜索。其代码模板如下：

``` C#
private void BFS(Node node) {
    var queue = new Queue<Node>();
    queue.Enqueue(node);
    while (queue.Length > 0) {
        var cur = queue.Dequeue();
        // 处理逻辑
        visited.Add(cur);
        // ...

        // 将后续的节点存入queue中
        foreach(var child in cur.Children) {
            queue.Enqueue(child);
        } 
    }
}
```

### 贪心算法

我在之前的工作学习中完全没有重视过贪心算法，当时觉得贪心算法完全没有什么帮助，每次选最好的就行。但是上了课之后才发现是自己目光短浅了。

> 贪心算法的适用性不是很高，但是如果一个问题能够用贪心算法解决，那么贪心算法一定是解决此问题的最好算法。

一般来说，贪心算法都用来解决一些大型问题的子问题，并且贪心算法大部分时间都是和动态规划一起比较的：

* 贪心算法：选择局部最优解，没有记录之前的结果，因此无法回溯
* 动态规划：统计记录以前的结果综合计算全局最优解

一般，贪心算法在处理具体问题的时候都是很有技巧性的，比如[55. Jump Game](https://leetcode.com/problems/jump-game/)就是需要从后向前贪心，而这个问题的升级版[45. Jump Game II](https://leetcode.com/problems/jump-game-ii/)技巧性就更强了，其通过记录每次最大值的方式优化双重循环为单层。因此，贪心算法的题做起来并没有很容易。

### 二分查找

二分查找的逻辑很简单，每次查询中间的值，然后依次左右移动，最终可以将O(N)的算法优化到O(logN)，但对应的限制就是数组需要具有`单调性`。

``` C#
private int BinarySearch(int[] nums, int target) {
    var left = 0; var right = nums.Length - 1;
    while (left <= right) {
        var mid = left + (right - left) / 2;
        if (nums[mid] == target) return mid;
        else if (nums[mid] < target) left = mid + 1;
        else right = mid - 1;
    }
    return mid;
}
```

其中，关于作业寻找半有序数组的分界点问题如下：

``` C#
public int FindIndex(int[] nums) {
    if (nums == null || nums.Length == 0) return 0;
    // nums = [3, 4, 5, 1, 2]
    var left = 0; var right = nums.Length - 1; var leftValue = nums[left];
    while (left <= right) {
        var mid = left + (right - left) / 2;
        var cur = nums[mid];
        if (cur < nums[mid-1] && cur < nums[mid+1]) return mid; // return 3
        if (cur > leftValue) {
            // 说明当前值在左侧部分，需要移动left为mid
            left = mid + 1;
        } else {
            // 说明当前值在右侧部分，需要移动right为mid
            right = mid - 1;
        }
    }
    return -1;
}
```