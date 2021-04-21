using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
    /// <summary>
    /// Heap的本质就是一个接口
    /// 其规定了数据的插入、删除、搜索都是小于等于logN的时间复杂度，具体为：
    /// 1. Find-Max/Find-Min: O(1)
    /// 2. Delete-Max/Delete-Min: O(logN)
    /// 3. Insert: O(logN) OR O(1)
    /// </summary>
    public interface IHeap<T>
    {
        /// <summary>
        /// 比较方法
        /// 由于数据类型为泛型，因此需要一个类型比较的算法
        /// </summary>
        public Func<T, T, bool> Equaler { get; }

        public void Insert(T item);

        public void Remove();

        public T Find();
    }

    public enum HeapType
    {
        Max,
        Min
    }

    /// <summary>
    /// 自定义的二叉堆
    /// 二叉堆是通过【完全二叉树】实现的，而完全二叉树又可以通过数组进行模拟，具体如下：
    /// 对于下标i有如下性质：
    /// 左节点的坐标为：2i+1
    /// 右节点的坐标为：2i+2
    /// 父节点的坐标为：floor((i-1)/2)
    /// </summary>
    public class CustomBinaryHeap : IHeap<int>
    {
        /// <summary>
        /// 由于数组没有扩展性，因此内部直接使用List实现
        /// </summary>
        private readonly IList<int> _data;

        /// <summary>
        /// 是否需要向堆顶移动
        /// 此方法根据_type的不同而不同
        /// </summary>
        private readonly Func<int, int, bool> _needUp;

        /// <summary>
        /// 获取满足Heapify的子节点
        /// </summary>
        private readonly Func<int, int> _getChild;

        /// <summary>
        /// 由于在删除操作发生时不想直接操作List导致性能损耗，
        /// 所以加入一个index指向最后一个元素的位置
        /// </summary>
        private int _lastIndex = -1;

        public CustomBinaryHeap(HeapType type = HeapType.Max)
        {
            _data = new List<int>(10);
            _needUp = (source, target) => type == HeapType.Max ? source > target : source < target;
            _getChild = (index) =>
            {
                var left = GetLeft(index);
                var right = GetRight(index);
                if (left == -1) return -1;
                if (right == -1) return left;
                var leftValue = _data[left];
                var rightValue = _data[right];
                if (type == HeapType.Max)
                {
                    return leftValue > rightValue ? left : right;
                }
                return leftValue < rightValue ? left : right;
            };
        }

        public CustomBinaryHeap(HeapType type, IList<int> initialized) : this(type)
        {
            if (initialized != null && initialized.Any())
            {
                foreach (var item in initialized)
                {
                    Insert(item);
                }
            }

        }

        public Func<int, int, bool> Equaler => (a, b) => a == b;

        public void Insert(int item)
        {
            if (_lastIndex == _data.Count - 1)
            {
                _data.Add(item);
                _lastIndex++;
            }
            else
            {
                _lastIndex++;
                _data[_lastIndex] = item;
            }
            HeapifyUp(_lastIndex);
        }

        public void Remove()
        {
            _data[0] = _data[_lastIndex];
            _data[_lastIndex--] = 0;
            HeapifyDown(0);
        }

        public int Find()
        {
            return _data[0];
        }

        public override string ToString()
        {
            if (_data.Count == 0) return "[]";
            var map = new Dictionary<int, List<int>>();
            for (var i = 0; i <= _lastIndex; i++)
            {
                var level = (int)Math.Round(Math.Sqrt(i), 0);
                if (!map.ContainsKey(level))
                {
                    map.Add(level, new List<int>());
                }
                map[level].Add(_data[i]);
            }
            var builder = new StringBuilder();
            foreach (var item in map)
            {
                builder.AppendLine($"[{string.Join(",", item.Value)}],");
            }
            return $"{builder}";
        }

        private void HeapifyUp(int index)
        {
            var cur = _data[index];
            while (index > 0 && GetParent(index) != -1 && _needUp(cur, _data[GetParent(index)]))
            {
                _data[index] = _data[GetParent(index)];
                index = GetParent(index);
            }
            _data[index] = cur;
        }

        private void HeapifyDown(int index)
        {
            var cur = _data[index];
            while (_getChild(index) != -1 && !_needUp(cur, _data[_getChild(index)]))
            {
                _data[index] = _data[_getChild(index)];
                index = _getChild(index);
            }
            _data[index] = cur;
        }

        private int GetParent(int index)
        {
            if (index == 0) return -1;
            var parent = (index - 1) / 2;
            if (parent < 0 || parent > _lastIndex) return -1;
            return parent;
        }

        private int GetLeft(int index)
        {
            var left = 2 * index + 1;
            if (left < 0 || left > _lastIndex) return -1;
            return left;
        }

        private int GetRight(int index)
        {
            var right = 2 * index + 2;
            if (right < 0 || right > _lastIndex) return -1;
            return right;
        }
    }
}
