# 第八周学习总结

这周的主要内容是`位运算`，`布隆过滤器`，`LRU Cache`和`排序算法`。位运算和排序算法基本是大学算法中的劝退知识点，尤其是位运算，当时真的学的很模糊，云里雾里。布隆过滤器和LRU Cache之前没有接触过，通过这次学习掌握了新的数据结构。

## 知识点回顾

### 位运算

位运算的原理我是明白的，但是一些主要的运算定义和特性之前并没有相关的概念，因此在这总结一下几个对我来说比较重要的：

1. 按位异或（相同为0，不同为1）：a ^ b => 0011 ^ 1011 = 1000
2. x ^ 0 = x
3. x ^ 1s = ~x (其中1s = ~0)
4. x ^ (~x) = 1s
5. x ^ x = 0
6. c = a ^ b => a ^ c = b => b ^ c = a
7. x & (~0 << n) 将x最右边的n位清零
8. (x >> n) & 1 获取x的第n位的值
9. x & (1 << n) 获取x的第n位的幂值
10. x | (1 << n) 仅将第n位赋值为1
11. x & (~(1 << n)) 仅将第n位赋值为0
12. x & ((1 << n) - 1) 将x最高位至第n位（含）清零
13. x % 2 == 1 => x & 1 == 1 判断奇数，同理可得 x & 1 == 0 判断偶数
14. x >> 1 => x / 2，同理可得 mid = (left + right) / 2 => mid = (left + right) >> 1
15. x = x & (x - 1) => 清零最低位的1
16. x & -x => 得到最低位的1

有了以上的一些概念和知识点，位运算的题就可以做了。比较典型的是 [191. Number of 1 Bits](https://leetcode.com/problems/number-of-1-bits/)，计算给定二进制数的1的个数，这个题就可以用上述`第15个`特性解决：

``` C#
public int HammingWeight(uint n) {
    var count = 0;
    while (n > 0) {
        n &= n - 1;
        count++;
    }
    return count;
}
```

位运算的知识点大多是理解和多练，只有用多了相关的特定才能熟练掌握和使用。其位运算最经典的题目就是N皇后问题，这个题由于目前时间有限我还顾不上学习，之后了解位运算解法之后回来补齐。

### 布隆过滤器

布隆过滤器对我来说是一个全新的`数据结构`，其主要功能是可以`快速地判定一个值是否不存在`，其通过`向量 + 二进制数组`实现，主要原理是将一个值映射为多个哈希表中的向量存入哈希表中，当有一个数据进入时可以通过映射快速判断其是否在布隆过滤器中。其优点是`时间和空间复杂度远远高于一般算法`，但是也有相应的缺点就是`存在误识别率并且删除困难`。其主要的实现原理如下图所示：

![Bloom Filter Principle](https://github.com/lzl82891314/AlgorithmDeliberatePractice/blob/master/src/geek%20time/summarize/resource/bloom_filter.png)

布隆过滤器只能`100%判定不存在`，而`判定存在则有一定误差`，其误差的大小主要依赖于映射函数的编写。其代码实现为：

``` C#
public class BloomFilter {
    private BitArray bitArray;
    private int size;
    private int hashNum;

    public BloomFilter(int size, int hashNum) {
        this.size = size;
        this.hashNum = hashNum;
        this.bitArray = new BitArray(this.size);
    }
    public void Add(string data) {
        for (var i = 1; i <= this.hashNum; i++) {
            var result = Hash(data, i) % this.size;
            this.bitArray[result] = true;
        }
    }
    public string LookUp(string data) {
        for (var i = 1; i <= this.hashNum; i++) {
            var result = Hash(data, i) % this.size;
            if (!this.bitArray[result]) return "Nope";
        }
        return "Probably";
    }
    private int Hash(string data, int seed) {
        // to be implement ...
        var code = 0;
        return code;
    }
}
```

布隆过滤器的主要业务场景是可以在缓存之前再加一个布隆过滤器，这样当一个数据进入时就可以快速地判断这个值是否存在缓存中，从而加速缓存读取，也可以在分布式集群中作为资源的定位器。

### LRU Cache

LRU是最近最少使用的缩写`Least Recently Used`，是众多缓存替换算法中的一种，也是面试最长考的一种。其原理也很简单，缓存数据以类似栈的形式存储，当新加入的缓存会存入缓存池的最顶部，当超出缓存容量时，缓存池最底部的数据将会被删除，访问一个缓存池中的数据也会被重新放入缓存池的顶部。其实现主要使用`双向链表 + 哈希表`：

``` C#
public class LRU_Cache {
    // 其中Node是一个双向链表，代码很简单，就不多说了
    private Dictionary<int, Node> cache;
    private Node dummyHead;
    private Node dummyTail;
    private int size;
    private int capacity;

    public LRU_Cache(int capacity) {
        this.capacity = capacity;
        this.dummyHead = new Node();
        this.dummyTail = new Node();
        this.dummyHead.next = this.dummyTail;
        this.dummyTail.pre = this.dummyHead;
        this.cache = new Dictionary<int, Node>();
    }

    public int Get(int key) {
        if (!this.cache.ContainsKey(key)) return -1;
        var node = this.cache[key];
        MoveToHead(node);
        return node.val;
    }

    public void Put(int key, int value) {
        if (this.cache.ContainsKey(key)) {
            this.cache[key].val = value;
            MoveToHead(this.cache[key]);
            return;
        }
        AddToHead(new Node(key, value));
    }

    private void MoveToHead(Node node) {
        node.pre.next = node.next;
        node.next.pre = node.pre;
        node.pre = this.dummyHead;
        node.next = this.dummyHead.next;
        this.dummyHead.next.pre = node;
        this.dummyHead.next = node;
    }

    private void AddToHead(Node node) {
        node.pre = this.dummyHead;
        node.next = this.dummyHead.next;
        this.dummyHead.next.pre = node;
        this.dummyHead.next = node;
        this.cache.Add(node.key, node);
        if (this.size == this.capacity) RemoveTail();
        this.size++;
    }

    private void RemoveTail() {
        var node = this.dummyTail.pre;
        this.dummyTail.pre = node.pre;
        node.pre.next = this.dummyTail;
        this.cache.Remove(node.key);
        this.size--;
    }
}
```

和布隆过滤器一样，这是一个高级的数据结构，并没有复杂的算法逻辑。

### 排序算法

排序算法种类很多，并且其本身也有很多种维度进行划分，主要的维度有：

1. 排序方式：可以分为`比较排序`和`非比较排序`，常见的排序算法都是比较排序，非比较排序主要有：桶排序、计数排序和基数排序
2. 是否稳定：排序算法的稳定性指的是：经过排序后的数据内部的相对顺序是否会发生改变，比如[1, 3, 3, 2]这个数组排序后为[1, 2, 3, 3]，结果中的`两个3的相对位置不变`的算法称为`稳定排序算法`
3. 时间复杂度：排序基于时间复杂度可以大致分为：`O(n^2)的初级排序算法`、`O(logn)的高级排序算法`以及`O(n)的线性排序算法`
4. 内存消耗：常把不需要额外内存消耗的排序算法称为`原地排序算法`

多种排序算法的比较示意图如下：

![Sorting Algorithm](https://github.com/lzl82891314/AlgorithmDeliberatePractice/blob/master/src/geek%20time/summarize/resource/sort.png)

初级排序算法主要有三个：`选择排序`、`插入排序`和`冒泡排序`，其代码实现如下：

``` C#
public void BubblingSort(int[] nums) {
    if (nums == null || nums.Length == 0) return;
    for (var i = 0; i < nums.Length - 1; i++) {
        for (var j = 0; j < nums.Length - 1 - i; j++) {
            if (nums[j] > nums[j + 1]) {
                var temp = nums[j];
                nums[j] = nums[j + 1];
                nums[j + 1] = temp;
            }
        }
    }
}

public void SelectingSort(int[] nums) {
    if (nums == null || nums.Length == 0) return;
    for (var i = 0; i < nums.Length - 1; i++) {
        var min = i;
        for (var j = i + 1; j < nums.Length; j++) {
            if (nums[j] < nums[min]) min = j;
        }
        if (min != i) {
            var temp = nums[i];
            nums[i] = nums[min];
            nums[min] = temp;
        }
    }
}

public void InsertingSort(int[] nums) {
    if (nums == null || nums.Length == 0) return;
    for (var i = 0; i < nums.Length - 1; i++) {
        var cur = nums[i + 1]; var j = i;
        while (j >= 0 && cur < nums[j]) nums[j + 1] = nums[j--];
        nums[j + 1] = cur;
    }
}
```

相较于初级排序算法，`快速排序`、`归并排序`和`堆排序`是三个高级排序算法，因为其时间复杂度升级到了`O(logn)`，其三种排序算法都使用到了分治的思想，将大问题简化最终合并求解。

此外，还有几种线性排序算法，其时间复杂度可以到`O(n)`级别，但是他们不是基于比较的排序算法，因此只能处理int等数字类型。常见的线性排序算法有`桶排序`、`计数排序`和`基数排序`。